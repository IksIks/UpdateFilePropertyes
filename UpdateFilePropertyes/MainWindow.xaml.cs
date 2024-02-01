using System.IO;
using System.Windows;

namespace UpdateFilePropertyes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string FolderPath { get; set; }
        private List<string> filesNames;

        public MainWindow()
        {
            InitializeComponent();
            filesNames = Directory.GetFiles(FolderPath).ToList();
            foreach (string file in filesNames)
            {
                File.SetCreationTime(file, DateTime.Now);
                File.SetLastWriteTime(file, DateTime.Now);
            }
        }
    }
}