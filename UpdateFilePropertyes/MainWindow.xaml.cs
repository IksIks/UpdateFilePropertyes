using System.IO;
using System.Windows;

namespace UpdateFilePropertyes
{
    public partial class MainWindow : Window
    {
        //private string folderPath;
        private List<string> filesNames;

        private string Date;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewTime.Text = DateTime.Now.ToLongTimeString().ToString();
        }

        private void Button_Add_Path(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PathDir.Text = dialog.SelectedPath;
            }
            else return;
        }

        private void Button_Change_Propertyes(object sender, RoutedEventArgs e)
        {
            DateTime t = Convert.ToDateTime(NewDate.Text + " " + NewTime.Text);
            filesNames = Directory.GetFiles(PathDir.Text).ToList();
            foreach (string file in filesNames)
            {
                File.SetCreationTime(file, t);
                File.SetLastWriteTime(file, t);
                File.SetLastAccessTime(file, t);
            }
        }
    }
}