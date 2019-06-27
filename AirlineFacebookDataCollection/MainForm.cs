using AirlineFacebookDataCollection.Properties;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineFacebookDataCollection
{
    public partial class MainForm : Form
    {
        private string UserAccessToken = null;
        private string AppAccessToken = null;

        private CancellationTokenSource GetUserDataCancellationTokenSource = new CancellationTokenSource();
        private CancellationTokenSource ProcessNextLikeCancellationTokenSource = new CancellationTokenSource();

        private static MainForm current;

        delegate void SetTextCallback(string text);
        delegate void SetDateTimeCallback(DateTime date);
        delegate void SetTextColorCallback(string text, Color color);

        public MainForm()
        {
            InitializeComponent();

            QueryStringTextbox.Text = DataCollectionTasks.MASTER_QUERY;

            button2.ContextMenuStrip = contextMenuStrip1;

            //temp
            current = this;

            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(SaveToken);

            if (!string.IsNullOrEmpty(Settings.Default.UserAccessToken))
            {
                UserAccessToken = Settings.Default.UserAccessToken;
                UserAccessTokenTextbox.Text = UserAccessToken;

                tabControl1.SelectedIndex = 1;
            }
            //TODO: if there's a token then check if it's expired - renew/reauth if so
            else
            {
                string OAuthURL = @"https://www.facebook.com/dialog/oauth"
                                    + "?client_id=" + App.AppId
                                    + "&client_secret=" + App.AppSecret
                                    + "&redirect_uri=https://www.facebook.com/connect/login_success.html"
                                    + "&response_type=token"
                                    ;

                webBrowser1.Navigate(OAuthURL);
            }

            if (!string.IsNullOrEmpty(Settings.Default.AppAccessToken))
            {
                AppAccessToken = Settings.Default.AppAccessToken;
            }
            else
            {
                AppAccessToken = AuthTasks.GetAppAccessToken();
            }
            App.AppToken = AppAccessToken;
            AppAccessTokenTextbox.Text = AppAccessToken;

            Facebook.FacebookClient.DefaultVersion = "v2.5";
            AppendLineToOutput("Using " + Facebook.FacebookClient.DefaultVersion + " of Graph API");

            try { UpdateUntilDateTimePicker(DbTasks.GetOldestPost()); } //need to make this async so it doesn't freeze the initial start up
            catch (Exception ex) { AppendLineToOutput(ex.Message, Color.Red); }

        }

        void SaveToken(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser wb = ((WebBrowser)sender);
            if (wb.Document != null && wb.Url.AbsoluteUri.Contains("access_token"))
            {
                UserAccessToken = AuthTasks.GetUserAccessToken(wb.Url.AbsoluteUri);
                UserAccessTokenTextbox.Text = UserAccessToken;

                //get a long-term token
                UserAccessToken = AuthTasks.GetLongTermUserAccessToken(UserAccessToken);
                UserAccessTokenTextbox.Text = UserAccessToken;
            }
        }

        private async void CheckTokenBtn_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                var data = AuthTasks.DebugTokenAsync(AppAccessToken, UserAccessToken);
                //{ "data": { "app_id": 138483919580948, "application": "Social Cafe", "expires_at": 1352419328, "is_valid": true, "issued_at": 1347235328, "scopes": [ "email", "publish_actions" ], "user_id": 1207059 } }

                try
                {
                    string app = data.application;
                    DateTime expiresDateTime = Facebook.DateTimeConvertor.FromUnixTime(data.expires_at);

                    AppendLineToOutput(string.Format("UserAccessToken obtained for \"{0}\" app and expires at {1} {2}", app, expiresDateTime.ToShortDateString(), expiresDateTime.ToShortTimeString()));
                    if(data.error != null)
                    {
                        var error = data.error;
                        AppendLineToOutput(string.Format("    ERRORS: code [{0}] subcode[{1}] message [{2}]", error.code, error.subcode, error.message));
                    }
                }
                catch (Exception ex)
                {
                    AppendLineToOutput(string.Format("No token obtained (error: {0})", ex.Message));
                }

                var msg = "AppAccessToken obtained";
                if (AppAccessToken == null) { msg = "No " + msg; }
                AppendLineToOutput(msg);
            });
        }

        private async void GetUserDataBtn_Click(object sender, EventArgs e)
        {
            try
            {
                GetUserDataBtn.Enabled = false;
                CancelGetUserDataBtn.Enabled = true;
                GetUserDataCancellationTokenSource = new CancellationTokenSource();

                string query = QueryStringTextbox.Text;
                query += "&limit=" + QueryPostLimitUpdown.Value; //Using 100 can cause a server error on API calls - "Please reduce the amount of data you're asking for, then retry your request"

                query += "&until=" + DateTimeToUnixTimestamp(UntilDatetimepicker.Value);

                AppendLineToOutput("Collecting query = " + query);

                //even though  the method is async, running it in a task speeds up
                //this method's return to the UI
                await Task.Run(() => DataCollectionTasks.GetPageData(query
                    , Convert.ToInt32(NumPostsToProcessUpdown.Value)
                    , UserAccessToken
                    , GetUserDataCancellationTokenSource.Token)); 

                GetUserDataBtn.Enabled = true;
                CancelGetUserDataBtn.Enabled = false;

                ProcessNextLikeButton.Enabled = !string.IsNullOrEmpty(LikesNextTextbox.Text);
                ProcessNextCommentButton.Enabled = !string.IsNullOrEmpty(CommentsNextTextbox.Text);
            }
            catch (TaskCanceledException ex)
            {
                //this happens when a task is cancelled before it is started
                AppendLineToOutput("Unhandled exception: " + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        #region temp for debugging
        internal static void UpdateLikeNext(string s)
        {
            current.UpdateLikeNextTextbox(s);
        }

        private void UpdateLikeNextTextbox(string s)
        {
            if (CommentsNextTextbox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(UpdateLikeNextTextbox);
                this.Invoke(d, s);
            }
            else
            {
                LikesNextTextbox.Text = s;
            }
        }

        internal static void UpdateCommentNext(string s)
        {
            current.UpdateCommentNextTextbox(s);
        }
        
        private void UpdateCommentNextTextbox(string s)
        {
            if(CommentsNextTextbox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(UpdateCommentNextTextbox);
                this.Invoke(d, s);
            }
            else
            {
                CommentsNextTextbox.Text = s;
            }
        }

        private void UpdateUntilDateTimePicker(DateTime d)
        {
            if(UntilDatetimepicker.InvokeRequired)
            {
                SetDateTimeCallback dt = new SetDateTimeCallback(UpdateUntilDateTimePicker);
                this.Invoke(dt, d);
            }
            else
                UntilDatetimepicker.Value = d;
        }
        #endregion
        internal static void LogOutput(string s)
        {
            current.AppendLineToOutput(s, Color.DarkRed);
        }

        #region Output textbox
        private void AppendLineToOutput(string text, Color color)
        {
            if (OutputTextbox.InvokeRequired)
            {
                SetTextColorCallback d = new SetTextColorCallback(AppendLineToOutput);
                this.Invoke(d, new object[] { text, color });
            }
            else
            {
                OutputTextbox.SelectionStart = OutputTextbox.TextLength;
                OutputTextbox.SelectionLength = 0;

                OutputTextbox.SelectionColor = color;

                OutputTextbox.AppendText("[" + System.DateTime.Now.ToString("dd/MM HH:mm:ss") + "] " + text + Environment.NewLine);

                OutputTextbox.SelectionColor = OutputTextbox.ForeColor;

                if (!this.ContainsFocus)
                {
                    OutputTextbox.ScrollToCaret();
                }

                Console.Out.WriteLine("[" + System.DateTime.Now.ToString() + "] " + text);
            }
        }

        internal void AppendLineToOutput(string text)
        {
            AppendLineToOutput(text, Color.Black);
        }
        #endregion

        #region TESTING stuff
        private /*async*/ Task DoStuff(string num, CancellationToken cancellationToken, IProgress<DataCollectionProgress> progress)
        {
            
            //await Task.Run(() =>
            //{
                try
                {
                    System.Threading.Thread.Sleep(1000);
                    cancellationToken.ThrowIfCancellationRequested();

                    if (progress != null)
                        progress.Report(new DataCollectionProgress { Name = num, Status = "1 out of 2 done" });

                    System.Threading.Thread.Sleep(1000);
                    cancellationToken.ThrowIfCancellationRequested();

                    if (progress != null)
                        progress.Report(new DataCollectionProgress { Name = num, Status = "2 out of 2 done" });
                }
                catch (OperationCanceledException ex)
                {
                    progress.Report(new DataCollectionProgress { Name = num, Status = ex.Message });
                }

            //}, cancellationToken);
                return Task.FromResult(0);
        }

        private async void TestingButton_Click(object sender, EventArgs e)
        {

            //System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            //Console.Out.WriteLine(myAssembly.FullName);

            //App a = new App();
            //a.ass();

            ctTESTING = new CancellationTokenSource();

            var progress = new Progress<DataCollectionProgress>(update =>
            {
                AppendLineToOutput(
                    string.Format("{0} | {1}", update.Name, update.Status), Color.HotPink);
            });

            AppendLineToOutput(ctTESTING.IsCancellationRequested.ToString());

            try
            {
                await Task.WhenAll(
              Task.Run(() => DoStuff("one", ctTESTING.Token, progress)),
              Task.Run(() => DoStuff("two", (new CancellationTokenSource()).Token, progress)),
              Task.Run(() => DoStuff("three", (new CancellationTokenSource()).Token, progress))
            );

                //await Task.Run(() => DoStuff("one", ct.Token, progress));
                //await   Task.Run(() => DoStuff("two", (new CancellationTokenSource()).Token, progress));
                //await Task.Run(() => DoStuff("three", (new CancellationTokenSource()).Token, progress));
            }
            catch (TaskCanceledException ex)
            {
                //this happens when a task is cancelled before it is started
                AppendLineToOutput("Unhandled exception: " + ex.Message + Environment.NewLine + ex.StackTrace);
            }

            AppendLineToOutput("end of button code");

        }
        CancellationTokenSource ctTESTING = new CancellationTokenSource();
        private void button1_Click(object sender, EventArgs e)
        {
            ctTESTING.Cancel();
            AppendLineToOutput(ctTESTING.IsCancellationRequested.ToString());
        }
        #endregion

        private void CancelGetUserDataBtn_Click(object sender, EventArgs e)
        {
            if (GetUserDataCancellationTokenSource != null)
            {
                GetUserDataCancellationTokenSource.Cancel();
                AppendLineToOutput("Cancelling GetUserData task after current post and likes are processed (comments will continue).");                
            }
            else
                AppendLineToOutput("GetUserDataCancellationToken is null. Cannot cancel.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AppendLineToOutput("Attempting to delete and recreate database synchronously");
            AppendLineToOutput("...");

            if(Model1.RecreateDatabase())
            {
                AppendLineToOutput("Database deleted and created", Color.DarkMagenta);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button2.Click += button2_Click;
            button2.ForeColor = Color.Black;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            button2.Click -= button2_Click;
            button2.ForeColor = Color.Gray;
        }
        public static long DateTimeToUnixTimestamp(DateTime dateTime)
        {
            return Convert.ToInt64((dateTime - new DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc)).TotalSeconds);
        }

        private async void label5_Click(object sender, EventArgs e)
        {
            //use if invokeneeded etc.
            await Task.Run(() => {
                UpdateUntilDateTimePicker(DbTasks.GetOldestPost()); //include the oldest post to 'retry' in case it didn't finish processing entirely
            });
        }

        private async void ProcessNextLikeButton_Click(object sender, EventArgs e)
        {
            ProcessNextLikeButton.Enabled = false;

            try
            {
                ProcessNextLikeCancellationTokenSource = new CancellationTokenSource();
                await Task.Run(() => DataCollectionTasks.ProcessLikesFromQuery(LikesNextTextbox.Text, ProcessNextLikeCancellationTokenSource.Token, UserAccessToken));
                AppendLineToOutput("Process likes completed.");
            }
            catch (Exception ex)
            {
                AppendLineToOutput(ex.Message);
            }

            ProcessNextLikeButton.Enabled = true;
        }

        private async void ProcessNextCommentButton_Click(object sender, EventArgs e)
        {
            ProcessNextCommentButton.Enabled = false;

            try
            {
                await Task.Run(() => DataCollectionTasks.ProcessCommentsFromQuery(CommentsNextTextbox.Text, UserAccessToken));
                AppendLineToOutput("Process comments completed.");
            }
            catch (Exception ex)
            {
                AppendLineToOutput(ex.Message);
            }

            ProcessNextCommentButton.Enabled = true;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ProcessNextLikeButton.Enabled = true;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ProcessNextLikeButton.Enabled = false;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ProcessNextCommentButton.Enabled = true;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ProcessNextCommentButton.Enabled = false;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            ProcessNextLikeCancellationTokenSource.Cancel();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                button3.Enabled = false;

                //TODO get inputs from IdInputTextBox
                string[] ids = IdInputTextBox.Text.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                
                //even though  the method is async, running it in a task speeds up
                //this method's return to the UI
                await Task.Run(() => {
                    var fb = new Facebook.FacebookClient(AppAccessToken);
                    Random r = new Random();

                    foreach (var id in ids)
                    {
                        try
                        {
                            dynamic postsResult = fb.Get(string.Format("/{0}?metadata=1", id));

                            var data = postsResult.metadata;
                            if (data != null)
                            {
                                AppendLineToIdOutput(string.Format("{0}, {1}", id, data.type));
                            }
                        }
                        catch(Exception ex)
                        {
                            AppendLineToIdOutput(string.Format("{0}, {1}", id, ex.Message));
                        }
                        finally
                        {
                            if(r.NextDouble() <= 0.002) // 1 in 500 chance to sleep extra 5 minutes.
                            {
                                Thread.Sleep(5*60*1000);
                            }
                            Thread.Sleep(r.Next(500,2000));
                            
                        }
                        
                    }
                    
                    //var i = 1;
                    //var idString = ids[0] + ",";

                    //while (i < ids.Length) 
                    //{
                    //    idString += ids[i];

                    //    if (i % 20 == 0 || i == ids.Length - 1)
                    //    {
                    //        dynamic postsResult = fb.Get(string.Format("/?ids={0}&metadata=1", idString.Remove(idString.Length-2)));
                    //        idString = "";

                    //        var data = postsResult;
                    //        if (data != null)
                    //        {
                    //            foreach (var u in data)
                    //            {
                    //                AppendLineToIdOutput(string.Format("{0}, {1}", u.Key, u.Value.metadata.type));
                    //            }
                    //        }
                    //    }
                    //    else
                    //    {
                    //        idString += ",";
                    //    }

                    //    i++;
                    //}
                });

                button3.Enabled = true;
                
            }
            catch (TaskCanceledException ex)
            {
                //this happens when a task is cancelled before it is started
                AppendLineToIdOutput("Unhandled exception: " + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void AppendLineToIdOutput(string text)
        {
            if (IdOutputTextBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(AppendLineToIdOutput);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                IdOutputTextBox.AppendText("[" + System.DateTime.Now.ToString("dd/MM HH:mm:ss") + "] " + text + Environment.NewLine);

                if (!this.ContainsFocus)
                {
                    IdOutputTextBox.ScrollToCaret();
                }
            }
        }
    }


    public class DataCollectionProgress
    {
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
        