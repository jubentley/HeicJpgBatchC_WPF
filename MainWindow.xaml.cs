using System.Windows;

namespace HeicJpgBatchC_WPF
{
    public partial class MainWindow : Window
    {
        readonly string defaultLblExecuteTxt = "Ready to Convert";
        string folderPath;
        bool executeReady = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void BtnChangeDir(object sender, RoutedEventArgs e)
        {
            lblExecute.Content = defaultLblExecuteTxt;

            var dialog = new Microsoft.Win32.OpenFolderDialog
            {
                Title = "Select a folder containing HEIC images"
            };

            if (dialog.ShowDialog(this) == true)
            {
                folderPath = dialog.FolderName;
                lblDirectory.Content = folderPath;
                //btnExecute.IsEnabled = true;
                executeReady = true; 
            }
        }

        private async void BtnExecute(object sender, RoutedEventArgs e)
        {
            // dummy mode
            lblExecute.Content = "Converting - Standby";
            await Task.Delay(3000);
            lblExecute.Content = "HEIC's are Converted";
            return;

            if(!executeReady) { return; }
            // Run ImageMagic
            executeReady = false;
        }
        private async void BtnTerminate(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}