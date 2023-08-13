namespace QuestAppsDownloader
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DownloadButton = new Button();
            GameList = new DataGridView();
            GamePicture = new PictureBox();
            ConsoleBox = new RichTextBox();
            OpenFolderButton = new Button();
            CleanDownloadsButton = new Button();
            LoadingBar = new ProgressBar();
            FilterBox = new TextBox();
            FilterButton = new Button();
            ((System.ComponentModel.ISupportInitialize)GameList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GamePicture).BeginInit();
            SuspendLayout();
            // 
            // DownloadButton
            // 
            DownloadButton.Location = new Point(17, 387);
            DownloadButton.Margin = new Padding(4, 5, 4, 5);
            DownloadButton.Name = "DownloadButton";
            DownloadButton.Size = new Size(133, 72);
            DownloadButton.TabIndex = 0;
            DownloadButton.Text = "Download";
            DownloadButton.UseVisualStyleBackColor = true;
            DownloadButton.Click += DownloadButton_Click;
            // 
            // GameList
            // 
            GameList.AllowUserToAddRows = false;
            GameList.AllowUserToDeleteRows = false;
            GameList.AllowUserToResizeRows = false;
            GameList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GameList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            GameList.ColumnHeadersHeight = 34;
            GameList.Location = new Point(501, 20);
            GameList.Margin = new Padding(4, 5, 4, 5);
            GameList.MultiSelect = false;
            GameList.Name = "GameList";
            GameList.ReadOnly = true;
            GameList.RowHeadersWidth = 62;
            GameList.RowTemplate.Height = 25;
            GameList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GameList.Size = new Size(1751, 1395);
            GameList.TabIndex = 1;
            GameList.RowEnter += GameList_RowEnter;
            // 
            // GamePicture
            // 
            GamePicture.BackColor = SystemColors.InactiveCaption;
            GamePicture.Location = new Point(17, 20);
            GamePicture.Margin = new Padding(4, 5, 4, 5);
            GamePicture.Name = "GamePicture";
            GamePicture.Size = new Size(476, 357);
            GamePicture.SizeMode = PictureBoxSizeMode.Zoom;
            GamePicture.TabIndex = 2;
            GamePicture.TabStop = false;
            // 
            // ConsoleBox
            // 
            ConsoleBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            ConsoleBox.BackColor = SystemColors.InactiveCaption;
            ConsoleBox.Location = new Point(17, 507);
            ConsoleBox.Margin = new Padding(4, 5, 4, 5);
            ConsoleBox.Name = "ConsoleBox";
            ConsoleBox.ReadOnly = true;
            ConsoleBox.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            ConsoleBox.Size = new Size(474, 905);
            ConsoleBox.TabIndex = 3;
            ConsoleBox.Text = "";
            ConsoleBox.TextChanged += ConsoleBox_TextChanged;
            // 
            // OpenFolderButton
            // 
            OpenFolderButton.Location = new Point(360, 387);
            OpenFolderButton.Margin = new Padding(4, 5, 4, 5);
            OpenFolderButton.Name = "OpenFolderButton";
            OpenFolderButton.Size = new Size(133, 72);
            OpenFolderButton.TabIndex = 4;
            OpenFolderButton.Text = "Open Downloads";
            OpenFolderButton.UseVisualStyleBackColor = true;
            OpenFolderButton.Click += OpenFolderButton_Click;
            // 
            // CleanDownloadsButton
            // 
            CleanDownloadsButton.Location = new Point(189, 387);
            CleanDownloadsButton.Margin = new Padding(4, 5, 4, 5);
            CleanDownloadsButton.Name = "CleanDownloadsButton";
            CleanDownloadsButton.Size = new Size(133, 72);
            CleanDownloadsButton.TabIndex = 5;
            CleanDownloadsButton.Text = "Clean Downloads";
            CleanDownloadsButton.UseVisualStyleBackColor = true;
            CleanDownloadsButton.Click += CleanDownloadsButton_Click;
            // 
            // LoadingBar
            // 
            LoadingBar.Location = new Point(53, 177);
            LoadingBar.Margin = new Padding(4, 5, 4, 5);
            LoadingBar.Name = "LoadingBar";
            LoadingBar.Size = new Size(401, 53);
            LoadingBar.Step = 30;
            LoadingBar.Style = ProgressBarStyle.Marquee;
            LoadingBar.TabIndex = 6;
            // 
            // FilterBox
            // 
            FilterBox.Location = new Point(17, 467);
            FilterBox.Name = "FilterBox";
            FilterBox.PlaceholderText = "Filter";
            FilterBox.Size = new Size(418, 31);
            FilterBox.TabIndex = 7;
            // 
            // FilterButton
            // 
            FilterButton.Location = new Point(445, 467);
            FilterButton.Name = "FilterButton";
            FilterButton.Size = new Size(46, 32);
            FilterButton.TabIndex = 8;
            FilterButton.Text = "🔎";
            FilterButton.UseVisualStyleBackColor = true;
            FilterButton.Click += FilterButton_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(2270, 1435);
            Controls.Add(FilterButton);
            Controls.Add(FilterBox);
            Controls.Add(LoadingBar);
            Controls.Add(CleanDownloadsButton);
            Controls.Add(OpenFolderButton);
            Controls.Add(ConsoleBox);
            Controls.Add(GamePicture);
            Controls.Add(GameList);
            Controls.Add(DownloadButton);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quest Apps Downloader";
            Load += MainWindow_Load;
            ((System.ComponentModel.ISupportInitialize)GameList).EndInit();
            ((System.ComponentModel.ISupportInitialize)GamePicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button DownloadButton;
        private DataGridView GameList;
        private PictureBox GamePicture;
        private RichTextBox ConsoleBox;
        private Button OpenFolderButton;
        private Button CleanDownloadsButton;
        private ProgressBar LoadingBar;
        private TextBox FilterBox;
        private Button FilterButton;
    }
}