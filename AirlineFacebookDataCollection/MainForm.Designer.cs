namespace AirlineFacebookDataCollection
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.NumPostsToProcessUpdown = new System.Windows.Forms.NumericUpDown();
            this.ProcessNextLikeButton = new System.Windows.Forms.Button();
            this.CancelLikesCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.ProcessNextCommentButton = new System.Windows.Forms.Button();
            this.LikesNextTextbox = new System.Windows.Forms.TextBox();
            this.LikesNextTextboxCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.CommentsNextTextbox = new System.Windows.Forms.TextBox();
            this.CommentsNextTextboxCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.UntilDatetimepicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.QueryStringTextbox = new System.Windows.Forms.TextBox();
            this.QueryPostLimitUpdown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AppAccessTokenTextbox = new System.Windows.Forms.TextBox();
            this.UserAccessTokenTextbox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.CancelGetUserDataBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.TestingButton = new System.Windows.Forms.Button();
            this.GetUserDataBtn = new System.Windows.Forms.Button();
            this.CheckTokenBtn = new System.Windows.Forms.Button();
            this.OutputTextbox = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.IdOutputTextBox = new System.Windows.Forms.TextBox();
            this.IdInputTextBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumPostsToProcessUpdown)).BeginInit();
            this.CancelLikesCMS.SuspendLayout();
            this.LikesNextTextboxCMS.SuspendLayout();
            this.CommentsNextTextboxCMS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QueryPostLimitUpdown)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(854, 542);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.webBrowser1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(846, 516);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Login";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(840, 510);
            this.webBrowser1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.NumPostsToProcessUpdown);
            this.tabPage2.Controls.Add(this.ProcessNextLikeButton);
            this.tabPage2.Controls.Add(this.ProcessNextCommentButton);
            this.tabPage2.Controls.Add(this.LikesNextTextbox);
            this.tabPage2.Controls.Add(this.CommentsNextTextbox);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.UntilDatetimepicker);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.QueryStringTextbox);
            this.tabPage2.Controls.Add(this.QueryPostLimitUpdown);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.AppAccessTokenTextbox);
            this.tabPage2.Controls.Add(this.UserAccessTokenTextbox);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.CancelGetUserDataBtn);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.TestingButton);
            this.tabPage2.Controls.Add(this.GetUserDataBtn);
            this.tabPage2.Controls.Add(this.CheckTokenBtn);
            this.tabPage2.Controls.Add(this.OutputTextbox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(846, 516);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Collect data";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "for how many posts";
            // 
            // NumPostsToProcessUpdown
            // 
            this.NumPostsToProcessUpdown.Location = new System.Drawing.Point(8, 116);
            this.NumPostsToProcessUpdown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NumPostsToProcessUpdown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumPostsToProcessUpdown.Name = "NumPostsToProcessUpdown";
            this.NumPostsToProcessUpdown.Size = new System.Drawing.Size(83, 20);
            this.NumPostsToProcessUpdown.TabIndex = 22;
            this.NumPostsToProcessUpdown.ThousandsSeparator = true;
            this.NumPostsToProcessUpdown.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.NumPostsToProcessUpdown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // ProcessNextLikeButton
            // 
            this.ProcessNextLikeButton.ContextMenuStrip = this.CancelLikesCMS;
            this.ProcessNextLikeButton.Location = new System.Drawing.Point(168, 134);
            this.ProcessNextLikeButton.Name = "ProcessNextLikeButton";
            this.ProcessNextLikeButton.Size = new System.Drawing.Size(108, 23);
            this.ProcessNextLikeButton.TabIndex = 21;
            this.ProcessNextLikeButton.Text = "Process Likes";
            this.ProcessNextLikeButton.UseVisualStyleBackColor = true;
            this.ProcessNextLikeButton.Click += new System.EventHandler(this.ProcessNextLikeButton_Click);
            // 
            // CancelLikesCMS
            // 
            this.CancelLikesCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem7});
            this.CancelLikesCMS.Name = "contextMenuStrip1";
            this.CancelLikesCMS.Size = new System.Drawing.Size(130, 26);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(129, 22);
            this.toolStripMenuItem7.Text = "Cancel likes";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // ProcessNextCommentButton
            // 
            this.ProcessNextCommentButton.Location = new System.Drawing.Point(168, 105);
            this.ProcessNextCommentButton.Name = "ProcessNextCommentButton";
            this.ProcessNextCommentButton.Size = new System.Drawing.Size(108, 23);
            this.ProcessNextCommentButton.TabIndex = 20;
            this.ProcessNextCommentButton.Text = "Process Comments";
            this.ProcessNextCommentButton.UseVisualStyleBackColor = true;
            this.ProcessNextCommentButton.Click += new System.EventHandler(this.ProcessNextCommentButton_Click);
            // 
            // LikesNextTextbox
            // 
            this.LikesNextTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LikesNextTextbox.ContextMenuStrip = this.LikesNextTextboxCMS;
            this.LikesNextTextbox.Location = new System.Drawing.Point(282, 134);
            this.LikesNextTextbox.Multiline = true;
            this.LikesNextTextbox.Name = "LikesNextTextbox";
            this.LikesNextTextbox.Size = new System.Drawing.Size(561, 23);
            this.LikesNextTextbox.TabIndex = 19;
            this.LikesNextTextbox.WordWrap = false;
            // 
            // LikesNextTextboxCMS
            // 
            this.LikesNextTextboxCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.LikesNextTextboxCMS.Name = "contextMenuStrip1";
            this.LikesNextTextboxCMS.Size = new System.Drawing.Size(166, 48);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(165, 22);
            this.toolStripMenuItem5.Text = "enable likes button";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(165, 22);
            this.toolStripMenuItem6.Text = "disable likes button";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // CommentsNextTextbox
            // 
            this.CommentsNextTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommentsNextTextbox.ContextMenuStrip = this.CommentsNextTextboxCMS;
            this.CommentsNextTextbox.Location = new System.Drawing.Point(282, 105);
            this.CommentsNextTextbox.Multiline = true;
            this.CommentsNextTextbox.Name = "CommentsNextTextbox";
            this.CommentsNextTextbox.Size = new System.Drawing.Size(561, 23);
            this.CommentsNextTextbox.TabIndex = 18;
            this.CommentsNextTextbox.WordWrap = false;
            // 
            // CommentsNextTextboxCMS
            // 
            this.CommentsNextTextboxCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.CommentsNextTextboxCMS.Name = "contextMenuStrip1";
            this.CommentsNextTextboxCMS.Size = new System.Drawing.Size(189, 48);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(188, 22);
            this.toolStripMenuItem3.Text = "enable comment button";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(188, 22);
            this.toolStripMenuItem4.Text = "disable comment button";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(94, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Output";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(150, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "until (click for oldest post)";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // UntilDatetimepicker
            // 
            this.UntilDatetimepicker.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.UntilDatetimepicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.UntilDatetimepicker.Location = new System.Drawing.Point(150, 77);
            this.UntilDatetimepicker.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.UntilDatetimepicker.MinDate = new System.DateTime(2008, 1, 1, 0, 0, 0, 0);
            this.UntilDatetimepicker.Name = "UntilDatetimepicker";
            this.UntilDatetimepicker.ShowUpDown = true;
            this.UntilDatetimepicker.Size = new System.Drawing.Size(126, 20);
            this.UntilDatetimepicker.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(282, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Query string (without post limit and until)";
            // 
            // QueryStringTextbox
            // 
            this.QueryStringTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QueryStringTextbox.Location = new System.Drawing.Point(282, 76);
            this.QueryStringTextbox.Multiline = true;
            this.QueryStringTextbox.Name = "QueryStringTextbox";
            this.QueryStringTextbox.Size = new System.Drawing.Size(561, 23);
            this.QueryStringTextbox.TabIndex = 13;
            this.QueryStringTextbox.WordWrap = false;
            // 
            // QueryPostLimitUpdown
            // 
            this.QueryPostLimitUpdown.Location = new System.Drawing.Point(97, 77);
            this.QueryPostLimitUpdown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.QueryPostLimitUpdown.Name = "QueryPostLimitUpdown";
            this.QueryPostLimitUpdown.Size = new System.Drawing.Size(47, 20);
            this.QueryPostLimitUpdown.TabIndex = 12;
            this.QueryPostLimitUpdown.ThousandsSeparator = true;
            this.QueryPostLimitUpdown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "batch limit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(315, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "UserToken";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "AppToken";
            // 
            // AppAccessTokenTextbox
            // 
            this.AppAccessTokenTextbox.Location = new System.Drawing.Point(97, 18);
            this.AppAccessTokenTextbox.MinimumSize = new System.Drawing.Size(4, 23);
            this.AppAccessTokenTextbox.Multiline = true;
            this.AppAccessTokenTextbox.Name = "AppAccessTokenTextbox";
            this.AppAccessTokenTextbox.ReadOnly = true;
            this.AppAccessTokenTextbox.Size = new System.Drawing.Size(210, 23);
            this.AppAccessTokenTextbox.TabIndex = 8;
            this.AppAccessTokenTextbox.WordWrap = false;
            // 
            // UserAccessTokenTextbox
            // 
            this.UserAccessTokenTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserAccessTokenTextbox.Location = new System.Drawing.Point(313, 18);
            this.UserAccessTokenTextbox.Multiline = true;
            this.UserAccessTokenTextbox.Name = "UserAccessTokenTextbox";
            this.UserAccessTokenTextbox.ReadOnly = true;
            this.UserAccessTokenTextbox.Size = new System.Drawing.Size(530, 23);
            this.UserAccessTokenTextbox.TabIndex = 7;
            this.UserAccessTokenTextbox.WordWrap = false;
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Gray;
            this.button2.Location = new System.Drawing.Point(8, 452);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 35);
            this.button2.TabIndex = 6;
            this.button2.Text = "recreate db";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // CancelGetUserDataBtn
            // 
            this.CancelGetUserDataBtn.Enabled = false;
            this.CancelGetUserDataBtn.Location = new System.Drawing.Point(0, 47);
            this.CancelGetUserDataBtn.Name = "CancelGetUserDataBtn";
            this.CancelGetUserDataBtn.Size = new System.Drawing.Size(91, 23);
            this.CancelGetUserDataBtn.TabIndex = 5;
            this.CancelGetUserDataBtn.Text = "Cancel get data";
            this.CancelGetUserDataBtn.UseVisualStyleBackColor = true;
            this.CancelGetUserDataBtn.Click += new System.EventHandler(this.CancelGetUserDataBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "< Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TestingButton
            // 
            this.TestingButton.Location = new System.Drawing.Point(0, 383);
            this.TestingButton.Name = "TestingButton";
            this.TestingButton.Size = new System.Drawing.Size(75, 23);
            this.TestingButton.TabIndex = 3;
            this.TestingButton.Text = "TESTING";
            this.TestingButton.UseVisualStyleBackColor = true;
            this.TestingButton.Click += new System.EventHandler(this.TestingButton_Click);
            // 
            // GetUserDataBtn
            // 
            this.GetUserDataBtn.Location = new System.Drawing.Point(8, 74);
            this.GetUserDataBtn.Name = "GetUserDataBtn";
            this.GetUserDataBtn.Size = new System.Drawing.Size(83, 23);
            this.GetUserDataBtn.TabIndex = 2;
            this.GetUserDataBtn.Text = "Get data";
            this.GetUserDataBtn.UseVisualStyleBackColor = true;
            this.GetUserDataBtn.Click += new System.EventHandler(this.GetUserDataBtn_Click);
            // 
            // CheckTokenBtn
            // 
            this.CheckTokenBtn.Location = new System.Drawing.Point(8, 18);
            this.CheckTokenBtn.Name = "CheckTokenBtn";
            this.CheckTokenBtn.Size = new System.Drawing.Size(83, 23);
            this.CheckTokenBtn.TabIndex = 1;
            this.CheckTokenBtn.Text = "Debug tokens";
            this.CheckTokenBtn.UseVisualStyleBackColor = true;
            this.CheckTokenBtn.Click += new System.EventHandler(this.CheckTokenBtn_Click);
            // 
            // OutputTextbox
            // 
            this.OutputTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputTextbox.BackColor = System.Drawing.SystemColors.Window;
            this.OutputTextbox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputTextbox.Location = new System.Drawing.Point(97, 180);
            this.OutputTextbox.Name = "OutputTextbox";
            this.OutputTextbox.ReadOnly = true;
            this.OutputTextbox.Size = new System.Drawing.Size(746, 336);
            this.OutputTextbox.TabIndex = 0;
            this.OutputTextbox.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.IdOutputTextBox);
            this.tabPage3.Controls.Add(this.IdInputTextBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(846, 516);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(8, 26);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 30);
            this.button3.TabIndex = 1;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // IdOutputTextBox
            // 
            this.IdOutputTextBox.Location = new System.Drawing.Point(390, 26);
            this.IdOutputTextBox.MaxLength = 0;
            this.IdOutputTextBox.Multiline = true;
            this.IdOutputTextBox.Name = "IdOutputTextBox";
            this.IdOutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.IdOutputTextBox.Size = new System.Drawing.Size(448, 482);
            this.IdOutputTextBox.TabIndex = 0;
            // 
            // IdInputTextBox
            // 
            this.IdInputTextBox.Location = new System.Drawing.Point(122, 26);
            this.IdInputTextBox.MaxLength = 0;
            this.IdInputTextBox.Multiline = true;
            this.IdInputTextBox.Name = "IdInputTextBox";
            this.IdInputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.IdInputTextBox.Size = new System.Drawing.Size(252, 487);
            this.IdInputTextBox.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.toolStripMenuItem1.Text = "enable button";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(142, 22);
            this.toolStripMenuItem2.Text = "disable button";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 542);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Facebook data collection";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumPostsToProcessUpdown)).EndInit();
            this.CancelLikesCMS.ResumeLayout(false);
            this.LikesNextTextboxCMS.ResumeLayout(false);
            this.CommentsNextTextboxCMS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.QueryPostLimitUpdown)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button CheckTokenBtn;
        private System.Windows.Forms.RichTextBox OutputTextbox;
        private System.Windows.Forms.Button GetUserDataBtn;
        private System.Windows.Forms.Button TestingButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button CancelGetUserDataBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.TextBox UserAccessTokenTextbox;
        private System.Windows.Forms.TextBox AppAccessTokenTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox QueryStringTextbox;
        private System.Windows.Forms.NumericUpDown QueryPostLimitUpdown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker UntilDatetimepicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ProcessNextLikeButton;
        private System.Windows.Forms.Button ProcessNextCommentButton;
        private System.Windows.Forms.TextBox LikesNextTextbox;
        private System.Windows.Forms.TextBox CommentsNextTextbox;
        private System.Windows.Forms.NumericUpDown NumPostsToProcessUpdown;
        private System.Windows.Forms.ContextMenuStrip CommentsNextTextboxCMS;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ContextMenuStrip LikesNextTextboxCMS;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ContextMenuStrip CancelLikesCMS;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox IdOutputTextBox;
        private System.Windows.Forms.TextBox IdInputTextBox;
    }
}

