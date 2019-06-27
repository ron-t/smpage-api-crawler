using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineFacebookDataCollection
{
    class DbTasks
    {
        public async static Task<int> SavePostAsync(Post post)
        {
            int numSaved = 0;

            using (var db = new Model1())
            {
                try
                {
                    db.Posts.Add(post);
                    numSaved = await db.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    HandleDbException(ex);
                } 
            }

            return numSaved;
        }

        public static int SaveLikes(List<Like> likes)
        {
            int numSaved = 0;

            using (var db = new Model1())
            {
                try
                {
                    //chunk in 10s
                    for (int i = 0; i < likes.Count; i += 10)
                    {
                        db.Likes.AddRange(likes.Skip(i).Take(10));
                        numSaved += db.SaveChanges();
                    }
                }
                catch (DbUpdateException ex)
                {
                    HandleDbException(ex);
                } 
            }

            return numSaved;
        }

        public static DateTime GetOldestPost()
        {
            using (var db = new Model1())
            {
                var post = db.Posts.Where(p => p.InReplyToPostId == null).OrderBy(p => p.CreatedTime).FirstOrDefault();

                if (post != null)
                    return post.CreatedTime;
                else
                    return DateTime.UtcNow; 
            }
        }

        public static Post GetPost(string id)
        {
            using (var db = new Model1())
            {
                return db.Posts.FirstOrDefault(p => p.PostId == id);
            }
        }

        private static void HandleDbException(DbUpdateException ex)
        {
            if (ex.InnerException != null && ex.InnerException.InnerException != null)
            {
                System.Data.SqlClient.SqlException sqlEx = ex.InnerException.InnerException as System.Data.SqlClient.SqlException;

                if (sqlEx != null)
                {
                    switch (sqlEx.Number)
                    {
                        case 2627:  // Unique constraint error
                            //MainForm.LogOutput("**********" + sqlEx.Message);
                            break;
                        case 547:   // Constraint check violation
                        case 2601:  // Duplicated key row error

                        default:
                            throw ex;
                    }
                }
            }

        }
    }
}
