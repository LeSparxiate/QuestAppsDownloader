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
            tabControl = new TabControl();
            DownloadTab = new TabPage();
            SideloadTab = new TabPage();
            SideloadGroupBox = new GroupBox();
            APKPathLabel = new Label();
            ApkPathTextbox = new TextBox();
            BrowseApk = new Button();
            StartSideloadButton = new Button();
            VRHeadsetStatusGroupBox = new GroupBox();
            VRStatusLabel = new Label();
            StatusLabel = new Label();
            ManualConnectButton = new Button();
            AutoDetectButton = new Button();
            VRHIpAddressTexbox = new TextBox();
            VRHIpLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)GameList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GamePicture).BeginInit();
            tabControl.SuspendLayout();
            DownloadTab.SuspendLayout();
            SideloadTab.SuspendLayout();
            SideloadGroupBox.SuspendLayout();
            VRHeadsetStatusGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // DownloadButton
            // 
            DownloadButton.Location = new Point(7, 375);
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
            GameList.Location = new Point(491, 8);
            GameList.Margin = new Padding(4, 5, 4, 5);
            GameList.MultiSelect = false;
            GameList.Name = "GameList";
            GameList.ReadOnly = true;
            GameList.RowHeadersWidth = 62;
            GameList.RowTemplate.Height = 25;
            GameList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GameList.Size = new Size(1348, 846);
            GameList.TabIndex = 1;
            GameList.RowEnter += GameList_RowEnter;
            // 
            // GamePicture
            // 
            GamePicture.BackColor = SystemColors.InactiveCaption;
            GamePicture.Location = new Point(7, 8);
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
            ConsoleBox.Location = new Point(7, 495);
            ConsoleBox.Margin = new Padding(4, 5, 4, 5);
            ConsoleBox.Name = "ConsoleBox";
            ConsoleBox.ReadOnly = true;
            ConsoleBox.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            ConsoleBox.Size = new Size(474, 359);
            ConsoleBox.TabIndex = 3;
            ConsoleBox.Text = "";
            ConsoleBox.TextChanged += ConsoleBox_TextChanged;
            // 
            // OpenFolderButton
            // 
            OpenFolderButton.Location = new Point(350, 375);
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
            CleanDownloadsButton.Location = new Point(179, 375);
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
            LoadingBar.Location = new Point(45, 171);
            LoadingBar.Margin = new Padding(4, 5, 4, 5);
            LoadingBar.Name = "LoadingBar";
            LoadingBar.Size = new Size(401, 53);
            LoadingBar.Step = 30;
            LoadingBar.Style = ProgressBarStyle.Marquee;
            LoadingBar.TabIndex = 6;
            // 
            // FilterBox
            // 
            FilterBox.Location = new Point(7, 455);
            FilterBox.Name = "FilterBox";
            FilterBox.PlaceholderText = "Filter";
            FilterBox.Size = new Size(418, 31);
            FilterBox.TabIndex = 7;
            // 
            // FilterButton
            // 
            FilterButton.Location = new Point(435, 455);
            FilterButton.Name = "FilterButton";
            FilterButton.Size = new Size(46, 32);
            FilterButton.TabIndex = 8;
            FilterButton.Text = "🔎";
            FilterButton.UseVisualStyleBackColor = true;
            FilterButton.Click += FilterButton_Click;
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(DownloadTab);
            tabControl.Controls.Add(SideloadTab);
            tabControl.Location = new Point(12, 12);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1854, 900);
            tabControl.TabIndex = 9;
            // 
            // DownloadTab
            // 
            DownloadTab.BackColor = SystemColors.ControlDarkDark;
            DownloadTab.Controls.Add(LoadingBar);
            DownloadTab.Controls.Add(GameList);
            DownloadTab.Controls.Add(FilterButton);
            DownloadTab.Controls.Add(DownloadButton);
            DownloadTab.Controls.Add(FilterBox);
            DownloadTab.Controls.Add(GamePicture);
            DownloadTab.Controls.Add(ConsoleBox);
            DownloadTab.Controls.Add(CleanDownloadsButton);
            DownloadTab.Controls.Add(OpenFolderButton);
            DownloadTab.Location = new Point(4, 34);
            DownloadTab.Name = "DownloadTab";
            DownloadTab.Padding = new Padding(3);
            DownloadTab.Size = new Size(1846, 862);
            DownloadTab.TabIndex = 0;
            DownloadTab.Text = "Download";
            // 
            // SideloadTab
            // 
            SideloadTab.BackColor = SystemColors.ControlDarkDark;
            SideloadTab.Controls.Add(SideloadGroupBox);
            SideloadTab.Controls.Add(VRHeadsetStatusGroupBox);
            SideloadTab.Location = new Point(4, 34);
            SideloadTab.Name = "SideloadTab";
            SideloadTab.Padding = new Padding(3);
            SideloadTab.Size = new Size(1846, 862);
            SideloadTab.TabIndex = 1;
            SideloadTab.Text = "Sideload";
            // 
            // SideloadGroupBox
            // 
            SideloadGroupBox.Anchor = AnchorStyles.None;
            SideloadGroupBox.Controls.Add(APKPathLabel);
            SideloadGroupBox.Controls.Add(ApkPathTextbox);
            SideloadGroupBox.Controls.Add(BrowseApk);
            SideloadGroupBox.Controls.Add(StartSideloadButton);
            SideloadGroupBox.Location = new Point(962, 324);
            SideloadGroupBox.Name = "SideloadGroupBox";
            SideloadGroupBox.Size = new Size(418, 210);
            SideloadGroupBox.TabIndex = 4;
            SideloadGroupBox.TabStop = false;
            SideloadGroupBox.Text = "Sideload";
            // 
            // APKPathLabel
            // 
            APKPathLabel.AutoSize = true;
            APKPathLabel.Location = new Point(11, 42);
            APKPathLabel.Name = "APKPathLabel";
            APKPathLabel.Size = new Size(92, 25);
            APKPathLabel.TabIndex = 3;
            APKPathLabel.Text = "APK Path :";
            // 
            // ApkPathTextbox
            // 
            ApkPathTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ApkPathTextbox.Location = new Point(11, 80);
            ApkPathTextbox.Name = "ApkPathTextbox";
            ApkPathTextbox.Size = new Size(278, 31);
            ApkPathTextbox.TabIndex = 0;
            // 
            // BrowseApk
            // 
            BrowseApk.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BrowseApk.Location = new Point(295, 78);
            BrowseApk.Name = "BrowseApk";
            BrowseApk.Size = new Size(112, 34);
            BrowseApk.TabIndex = 1;
            BrowseApk.Text = "Browse";
            BrowseApk.UseVisualStyleBackColor = true;
            BrowseApk.Click += BrowseApk_Click;
            // 
            // StartSideloadButton
            // 
            StartSideloadButton.Location = new Point(121, 140);
            StartSideloadButton.Name = "StartSideloadButton";
            StartSideloadButton.Size = new Size(176, 34);
            StartSideloadButton.TabIndex = 2;
            StartSideloadButton.Text = "Start Sideload";
            StartSideloadButton.UseVisualStyleBackColor = true;
            StartSideloadButton.Click += StartSideloadButton_Click;
            // 
            // VRHeadsetStatusGroupBox
            // 
            VRHeadsetStatusGroupBox.Anchor = AnchorStyles.None;
            VRHeadsetStatusGroupBox.Controls.Add(VRStatusLabel);
            VRHeadsetStatusGroupBox.Controls.Add(StatusLabel);
            VRHeadsetStatusGroupBox.Controls.Add(ManualConnectButton);
            VRHeadsetStatusGroupBox.Controls.Add(AutoDetectButton);
            VRHeadsetStatusGroupBox.Controls.Add(VRHIpAddressTexbox);
            VRHeadsetStatusGroupBox.Controls.Add(VRHIpLabel);
            VRHeadsetStatusGroupBox.Location = new Point(455, 324);
            VRHeadsetStatusGroupBox.Name = "VRHeadsetStatusGroupBox";
            VRHeadsetStatusGroupBox.Size = new Size(418, 210);
            VRHeadsetStatusGroupBox.TabIndex = 3;
            VRHeadsetStatusGroupBox.TabStop = false;
            VRHeadsetStatusGroupBox.Text = "VR Headset Status";
            // 
            // VRStatusLabel
            // 
            VRStatusLabel.AutoSize = true;
            VRStatusLabel.ForeColor = Color.Red;
            VRStatusLabel.Location = new Point(183, 150);
            VRStatusLabel.Name = "VRStatusLabel";
            VRStatusLabel.Size = new Size(132, 25);
            VRStatusLabel.TabIndex = 5;
            VRStatusLabel.Text = "Not Connected";
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Location = new Point(108, 150);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(69, 25);
            StatusLabel.TabIndex = 4;
            StatusLabel.Text = "Status :";
            // 
            // ManualConnectButton
            // 
            ManualConnectButton.Location = new Point(21, 91);
            ManualConnectButton.Name = "ManualConnectButton";
            ManualConnectButton.Size = new Size(179, 34);
            ManualConnectButton.TabIndex = 3;
            ManualConnectButton.Text = "Manual Connection";
            ManualConnectButton.UseVisualStyleBackColor = true;
            ManualConnectButton.Click += ManualConnectButton_Click;
            // 
            // AutoDetectButton
            // 
            AutoDetectButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AutoDetectButton.Location = new Point(255, 91);
            AutoDetectButton.Name = "AutoDetectButton";
            AutoDetectButton.Size = new Size(140, 34);
            AutoDetectButton.TabIndex = 2;
            AutoDetectButton.Text = "Auto Detect";
            AutoDetectButton.UseVisualStyleBackColor = true;
            AutoDetectButton.Click += AutoDetectButton_Click;
            // 
            // VRHIpAddressTexbox
            // 
            VRHIpAddressTexbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            VRHIpAddressTexbox.Location = new Point(133, 39);
            VRHIpAddressTexbox.Name = "VRHIpAddressTexbox";
            VRHIpAddressTexbox.Size = new Size(262, 31);
            VRHIpAddressTexbox.TabIndex = 1;
            // 
            // VRHIpLabel
            // 
            VRHIpLabel.AutoSize = true;
            VRHIpLabel.Location = new Point(21, 42);
            VRHIpLabel.Name = "VRHIpLabel";
            VRHIpLabel.Size = new Size(106, 25);
            VRHIpLabel.TabIndex = 0;
            VRHIpLabel.Text = "IP Address :";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(1878, 924);
            Controls.Add(tabControl);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quest Apps Downloader";
            Load += MainWindow_Load;
            ((System.ComponentModel.ISupportInitialize)GameList).EndInit();
            ((System.ComponentModel.ISupportInitialize)GamePicture).EndInit();
            tabControl.ResumeLayout(false);
            DownloadTab.ResumeLayout(false);
            DownloadTab.PerformLayout();
            SideloadTab.ResumeLayout(false);
            SideloadGroupBox.ResumeLayout(false);
            SideloadGroupBox.PerformLayout();
            VRHeadsetStatusGroupBox.ResumeLayout(false);
            VRHeadsetStatusGroupBox.PerformLayout();
            ResumeLayout(false);
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
        private TabControl tabControl;
        private TabPage DownloadTab;
        private TabPage SideloadTab;
        private Button StartSideloadButton;
        private Button BrowseApk;
        private TextBox ApkPathTextbox;
        private GroupBox VRHeadsetStatusGroupBox;
        private Label VRStatusLabel;
        private Label StatusLabel;
        private Button ManualConnectButton;
        private Button AutoDetectButton;
        private TextBox VRHIpAddressTexbox;
        private Label VRHIpLabel;
        private GroupBox SideloadGroupBox;
        private Label APKPathLabel;
    }
}