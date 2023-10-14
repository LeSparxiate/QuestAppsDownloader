using System.Data;
using System.Diagnostics;
using System.Reflection;
using QuestAppsDownloader.Controllers;
using QuestAppsDownloader.DTO.DTOs;
using QuestAppsDownloader.Services.Implementations.Tools;

namespace QuestAppsDownloader
{
    public partial class MainWindow : Form
    {
        private const string PicturesDirectory = "./metadata/.meta./thumbnails";
        private const string FilterRequest = "GameName LIKE '%{0}%' OR ReleaseName LIKE '%{0}%'";

        private VRPPublic VrpPublic;

        private readonly MainWindowController _mainWindowController;

        public MainWindow(MainWindowController mainWindowController)
        {
            _mainWindowController = mainWindowController;
            InitializeComponent();
        }

        private async void MainWindow_Load(object sender, EventArgs e)
        {
            Console.SetOut(new TextBoxWriter(ConsoleBox));

            await _mainWindowController.SetupRclone();
            VrpPublic = await _mainWindowController.SetupVRPPublic();
            await _mainWindowController.GetMetadata(VrpPublic);

            _mainWindowController.LoadMetadata();
            GameList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            GameList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, GameList, new object[] { true });
            GameList.DataSource = _mainWindowController.Metadata;
            foreach (DataGridViewColumn column in GameList.Columns)
                column.SortMode = DataGridViewColumnSortMode.Automatic;

            LoadingBar.Visible = false;
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            ConsoleBox.Text = string.Empty;
            _mainWindowController.DownloadGame(GameList.Rows[GameList.SelectedRows[0].Index].Cells[1].Value.ToString(), VrpPublic);
        }

        private void GameList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var pictureName = $"{GameList.Rows[e.RowIndex].Cells[2].Value}.jpg";
            GamePicture.ImageLocation = $"{PicturesDirectory}/{pictureName}";
        }

        private void OpenFolderButton_Click(object sender, EventArgs e)
        {
            var openDownloadsFolder = new ProcessStartInfo
            {
                Arguments = $"{Directory.GetCurrentDirectory()}\\downloads",
                FileName = "explorer.exe"
            };

            Process.Start(openDownloadsFolder);
        }

        private void CleanDownloadsButton_Click(object sender, EventArgs e)
        {
            FileManager.DeleteDirectory("./downloads");
        }

        private void ConsoleBox_TextChanged(object sender, EventArgs e)
        {
            ConsoleBox.SelectionStart = ConsoleBox.Text.Length;
            ConsoleBox.ScrollToCaret();
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            (GameList.DataSource as DataTable).DefaultView.RowFilter = string.Format(FilterRequest, FilterBox.Text);
        }
    }
}