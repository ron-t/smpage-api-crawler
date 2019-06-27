using Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineFacebookDataCollection
{
    class DataCollectionTasks
    {
        //TODO:
        // parameterise:
        //      sleep duration
        //      logging/output level

        #region notes
        //comments.filter(stream) gets all comments in a 'flat' format. We can use the comment's .parent to get which comment (if any) it was in reply to

        //posts?fields=message,id,created_time,from,status_type,story,link,name,type,shares,properties,
        //  comments.limit(100).filter(stream){
        //      message,from,parent,id
        //  },
        //  likes.limit(100)

        //if a post is not by AirNz and AirNZ's involvement isn't clear from the "story"
        //it means AirNZ was tagged/mentioned in the post (data availble in message_tags).
        //hence the post is appearing in /AirNewZealand/tagged/

        /*
        id (PostId)
        (InReplyToPostId) - is a comment replying to a post
        (InReplyToCommentId) - is a comment replying to a comment
        created_time
        from (UserId, UserName)
        message
        status_type (StatusType)
        type
        story
        link
        name (PostName) [title of post]
        shares (NumShares)
        likes (NumLikes) + relationship
        comments (NumComments)
        properties (VideoLength)
                
        */
        #endregion

        //Use the Graph API explorer to construct the query string (https://developers.facebook.com/tools/explorer)
        //internal const string MASTER_QUERY = "/AirNewZealand/feed?fields=message,id,created_time,from,status_type,story,link,name,type,shares,properties"
        //                                    + ",comments.limit(100).summary(true).filter(stream){message,from,parent,id,created_time,comment_count,like_count,likes.limit(100)}"
        //                                    + ",likes.limit(100).summary(true){id, name}";

        // 2016-11-23 use this for getting posts and comments only (no likes)
        internal const string MASTER_QUERY = "/JetstarAustralia/feed?fields=message,id,created_time,from,status_type,story,link,name,type,shares,properties,comments.limit(100).summary(true).filter(stream){message,from,parent,id,created_time,comment_count,like_count}";

        private static TimeSpan FiveSeconds = new TimeSpan(0, 0, 5);
        private static TimeSpan ThirtySeconds = new TimeSpan(0, 0, 30);

        internal async static Task GetPageData(string query, int numToProcess, string userAccessToken, CancellationToken cancelToken)
        {
            int processedPostsCount = 0;
            try
            {
                do
                {
                    var fb = new FacebookClient(userAccessToken);
                    //chance to cancel before looping
                    if (cancelToken.IsCancellationRequested) { break; }

                    // hack for Twitter-FB-IB (1 year of posts) project: query += "&since=" + MainForm.DateTimeToUnixTimestamp(new DateTime(2015,09,01));
                    dynamic postsResult = fb.Get(query);

                    //process single post
                    var data = postsResult.data;
                    if(data == null)
                    {
                        data = new JsonArray(1);
                        data.Add(postsResult);
                    }

                    //process post array
                    if (data != null && data.Count > 0)
                    {
                        var posts = (JsonArray)data;

                        int numInBatch = 0;
                        foreach (dynamic p in posts)
                        {
                            processedPostsCount++;
                            numInBatch++;

                            try
                            {
                                Post post = CreatePostFromJson(p);

                                StringBuilder sb = new StringBuilder(Environment.NewLine);
                                sb.AppendFormat("\t----- PROCESSING #{0} of {1} [batch: {2}/{3}]-----", processedPostsCount, numToProcess, numInBatch, posts.Count); sb.AppendLine();
                                sb.AppendFormat("\tfrom  : {0} (postid: {1})", post.UserName, post.PostId); sb.AppendLine();
                                sb.AppendLine("\tmsg     :" + ShortenText(post.Message));
                                sb.AppendLine("\tcreated : " + post.CreatedTime);
                                sb.AppendFormat("\tlikes : {0} || comments : {1} || shares {2}", post.NumLikes, post.NumComments, post.NumShares); sb.AppendLine();
                                sb.Append("\t-------------------------------------------------");
                                MainForm.LogOutput(sb.ToString());

                                Task<int> savePostAsyncResult = DbTasks.SavePostAsync(post);

                                // *** disable getting likes .
                                // *** 2016-11-23
                                //Task<int> likesFromPostResult = Task.Run<int>(() => ProcessLikesFromPost(post, p as object, cancelToken));
                                Task<int> commentsResult = Task.Run<int>(() => ProcessComments(post, p as object)); //not cancellable

                                #region unused
                                //int[] results = await Task.WhenAll(
                                //    DbTasks.SavePostAsync(post) //save post to db async
                                //    , Task.Run<int>(() => ProcessLikesFromPost(post, p as object, cancelToken)) //process likes async
                                //    , Task.Run<int>(() => ProcessComments(post, p as object)) //process comments async
                                //    );
                                #endregion
                                int numPosts = await savePostAsyncResult;

                                // *** disable getting likes .
                                // *** 2016-11-23
                                int numComments = await commentsResult; //when comments complete
                                if (!cancelToken.IsCancellationRequested)
                                {
                                    MainForm.UpdateCommentNext(""); //all comments were processed successfully
                                }

                                int numLikes = -1;
                                //int numLikes = await likesFromPostResult; //when likes complete
                                //if (!cancelToken.IsCancellationRequested)
                                //{
                                //    MainForm.UpdateLikeNext(""); //all likes were processed successfully
                                //}

                                MainForm.LogOutput(string.Format("#{0} ({1}-{2}) processed with {3} comments and {4} likes", processedPostsCount, post.UserName, post.PostId, numComments, numLikes));
                            }
                            catch (FacebookApiException ex)
                            {
                                if (ex is FacebookOAuthException)
                                {

                                }
                                if (ex is FacebookApiLimitException)
                                {
                                    //this has never been encounted.
                                }

                                // handle all exceptions the same way anyway :(
                                StringBuilder msg = new StringBuilder(ex.Message);
                                msg.AppendLine();

                                try
                                {
                                    var debug = AuthTasks.DebugTokenAsync(App.AppToken, userAccessToken);
                                    //{ "data": { "app_id": 138483919580948, "application": "Social Cafe", "expires_at": 1352419328, "is_valid": true, "issued_at": 1347235328, "scopes": [ "email", "publish_actions" ], "user_id": 1207059 } }

                                    bool isValid = debug.is_valid;
                                    DateTime expiresDateTime = DateTimeConvertor.FromUnixTime(debug.expires_at);

                                    msg.AppendFormat("UserAccessToken valid [{0}], expires at [{1}-{2}]", isValid, expiresDateTime.ToShortDateString(), expiresDateTime.ToShortTimeString());
                                    msg.AppendLine();

                                    if (debug.error != null)
                                    {
                                        var error = debug.error;
                                        msg.AppendFormat("    ERRORS: code [{0}] subcode[{1}] message [{2}]", error.code, error.subcode, error.message);
                                        msg.AppendLine();
                                    }
                                    else
                                        msg.AppendLine("    No token errors");
                                }
                                catch (Exception tokenDebugEx)
                                {
                                    MainForm.LogOutput("  Error trying to debug UserAccessToken: " + tokenDebugEx.Message);
                                }

                                msg.Append("Sleeping for 30 seconds then continuing");
                                MainForm.LogOutput(msg.ToString());

                                Delay(ThirtySeconds);
                            }
                        }
                    }

                    query = postsResult.paging != null ? postsResult.paging.next : null;

                    //chance to cancel after each post
                    if (cancelToken.IsCancellationRequested) { break; }
                    if (query != null) { Delay(FiveSeconds); }

                } while (query != null && !cancelToken.IsCancellationRequested && processedPostsCount < numToProcess);

                if (cancelToken.IsCancellationRequested)
                {
                    MainForm.LogOutput("***** CANCELLED *****");
                }
                else
                {
                    MainForm.LogOutput(processedPostsCount + " posts processed. No more posts left");
                }
            }
            catch (Exception ex)
            {
                MainForm.LogOutput(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private static void Delay(TimeSpan time)
        {
            Thread.Sleep(time); //used a synchronous block to force actual delay.
        }

        private static string ShortenText(string s)
        {
            if (s == null)
            {
                return "null";
            }

            s = s.Replace("\n", " ");
            if (s.Length > 80)
            {
                return s.Substring(0, 40) + "..." + s.Substring(s.Length - 40, 40);
            }
            else return s;

        }

        private static Post CreateCommentPostFromJson(Post post, dynamic json)
        {
            Post comment = CreatePostFromJson(json);

            comment.InReplyToPostId = post.PostId;
            comment.NumComments = json.comment_count;
            comment.NumLikes = json.like_count;

            var parent = json.parent;
            if (parent != null)
            {
                comment.InReplyToCommentId = parent.id;
            }

            return comment;
        }

        private static Post CreatePostFromJson(dynamic json)
        {
            Post post = new Post();

            if (json.id == null)
                return null; //there's no valid post here
            else
                post.PostId = json.id;

            post.Message = json.message;
            post.CreatedTime = Facebook.DateTimeConvertor.FromIso8601FormattedDateTime(json.created_time);

            if (json.from != null)
            {
                post.UserId = long.Parse(json.from.id);
                post.UserName = json.from.name;
            }

            post.StatusType = json.status_type;
            post.Type = json.type;
            post.Story = json.story;
            post.Link = json.link;
            post.PostName = json.name;

            //if a post has been shared, 'shares.count' exists:
            //"shares": {
            //        "count": 46
            //      }
            if (json.shares != null)
                post.NumShares = json.shares.count ?? 0;

            //where status_type == "added_video" (shared videos don't apply)
            //there should be a properties object[] with length:
            //"properties": [
            //        {
            //          "name": "Length",
            //          "text": "01:28"
            //        }
            if (json.properties != null && json.type == "video")
                post.VideoLength = json.properties[0].text;

            var likes = json.likes;
            if (likes != null && likes.summary != null)
                post.NumLikes = likes.summary.total_count ?? 0;

            var comments = json.comments;
            if (comments != null && comments.summary != null)
                post.NumComments = comments.summary.total_count ?? 0;

            return post;
        }

        private static int ProcessLikes(string postId, dynamic likes, CancellationToken cancelToken)
        {
            return ProcessLikes(postId, likes, cancelToken, isComment: false);
        }

        private static int ProcessLikes(string postId, dynamic likes, CancellationToken cancelToken, bool isComment)
        {
            int numProcessed = 0;
            int numDupes = 0;

            while (likes != null && likes.data != null && likes.data.Count > 0)
            {
                var LikesList = new List<Like>(100);

                foreach (var l in likes.data)
                {
                    Like like = new Like();
                    like.LikedPostId = postId;

                    like.UserId = long.Parse(l.id);
                    like.Username = l.name;

                    LikesList.Add(like);
                }

                int i = DbTasks.SaveLikes(LikesList); //synchronous
                numProcessed += i;
                numDupes += LikesList.Count - i;

                if (!isComment)
                    MainForm.LogOutput(string.Format("\t{0} new likes saved; {1} already in db.", numProcessed, numDupes));

                //paging and chance to cancel
                if (likes.paging != null && likes.paging.next != null)
                {
                    var query = likes.paging.next;

                    if (!isComment)
                        MainForm.UpdateLikeNext(query); //set up next query before cancelling

                    if (!cancelToken.IsCancellationRequested)
                    {
                        Delay(FiveSeconds);

                        var fb = new FacebookClient(); //no accesstoken needed as it's included in the query string
                        likes = fb.Get(query);
                    }
                    else
                    {
                        likes = null;
                    }
                }
                else
                {
                    likes = null;
                }
            }

            return numProcessed;
        }

        internal static void ProcessLikesFromQuery(string query, CancellationToken cancelToken, string userAccessToken)
        {
            var postId = GetPostIdFromQuery(query);

            if (string.IsNullOrWhiteSpace(postId))
            {
                MainForm.LogOutput(string.Format("  Error with query = {0} ; PostId matched = {1}", query, postId));
            }
            else
            {
                MainForm.LogOutput(string.Format(" Processing likes for {0}", postId));

                var fb = new FacebookClient(); //no accesstoken needed as it's included in the query string
                if(!string.IsNullOrEmpty(userAccessToken))
                {
                    fb.AccessToken = userAccessToken;
                }

                var likes = fb.Get(query);
                ProcessLikes(postId, likes, cancelToken);
            }
        }

        private static int ProcessLikesFromPost(Post post, dynamic json)
        {
            return ProcessLikesFromPost(post, json, new CancellationToken(canceled: false));
        }

        private static int ProcessLikesFromPost(Post post, dynamic json, CancellationToken cancelToken)
        {
            var isPostAComment = (post.InReplyToPostId != null);
            int numProcessed = 0;

            if (post.NumLikes > 0)
            {
                var likes = json.likes;
                numProcessed += ProcessLikes(post.PostId, likes, cancelToken, isComment: isPostAComment);
            }

            return numProcessed;
        }

        internal static void ProcessCommentsFromQuery(string query, string userAccessToken)
        {
            var postId = GetPostIdFromQuery(query);

            if (string.IsNullOrWhiteSpace(postId))
            {
                MainForm.LogOutput(string.Format("  Error with query = {0} ; PostId matched = {1}", query, postId));
            }
            else
            {
                var post = DbTasks.GetPost(postId);

                if (post != null)
                {
                    MainForm.LogOutput(string.Format(" Processing comments for {0}", postId));

                    var fb = new FacebookClient(); //no accesstoken needed as it's included in the query string
                    if (!string.IsNullOrEmpty(userAccessToken))
                    {
                        fb.AccessToken = userAccessToken;
                    }

                    var comments = fb.Get(query);
                    ProcessComments(post, comments);
                }
                else
                    MainForm.LogOutput(string.Format("Post with id {0} not found. Unable to get comments.", postId));
            }
        }

        private static int ProcessComments(Post post, dynamic json)
        {
            var isComment = post.InReplyToPostId != null;

            int numProcessed = 0;
            int numDupes = 0;
            int numLikes = 0;

            if (post.NumComments > 0)
            {
                var comments = json.comments ?? json.data;
                using (var db = new Model1())
                {
                    while (comments != null && comments.data != null && comments.data.Count > 0)
                    {
                        foreach (var commentJson in comments.data)
                        {
                            Post commentPost = CreateCommentPostFromJson(post, commentJson);

                            if (!db.Posts.Any(x => x.PostId == commentPost.PostId))
                            {
                                Task<int> i = DbTasks.SavePostAsync(commentPost); //synchronous use
                                numProcessed += i.Result;
                            }
                            else
                                numDupes++;

                            if (commentPost.NumLikes > 0)
                                numLikes += ProcessLikesFromPost(commentPost, commentJson);

                        }

                        MainForm.LogOutput(string.Format("\t{0} new comments saved; {1} comments already in db; {2} comment-likes saved", numProcessed, numDupes, numLikes));

                        //paging and chance to cancel
                        if (comments.paging != null && comments.paging.next != null)
                        {
                            var query = comments.paging.next;

                            if (!isComment)
                                MainForm.UpdateCommentNext(query); //set up next query before cancelling

                            Delay(FiveSeconds);

                            var fb = new FacebookClient(); //no accesstoken needed as it's included in the query string
                            comments = fb.Get(query);
                        }
                        else
                        {
                            comments = null;
                        }
                    }
                }
            }

            return numProcessed;
        }

        private static string GetPostIdFromQuery(string query)
        {
            string postId = "";

            if (!string.IsNullOrWhiteSpace(query))
            {
                var matches = Regex.Match(query, @"https?://graph.facebook.com/(v\d.+/)?(.+)/(likes|comments)\?.+");

                if (matches.Success)
                {
                    postId = matches.Result("$2");

                    if (postId == "$2")
                    {
                        postId = "";
                    }
                }
            }

            return postId;
        }

    }
}
