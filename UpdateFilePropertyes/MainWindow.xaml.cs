using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace UpdateFilePropertyes
{
    public partial class MainWindow : Window
    {
        private List<string>? filesNames;

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
            FolderBrowserDialog dialog = new();

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PathDir.Text = dialog.SelectedPath;
            }
            else return;
        }

        private void Button_Change_Propertyes(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(NewTime.Text) || String.IsNullOrEmpty(PathDir.Text))
            {
                System.Windows.MessageBox.Show("Ошибка, не все поля заполнены", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!IsCorrectTime(NewTime.Text))
            {
                System.Windows.MessageBox.Show("У времени неправильный формат", "", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            DateTime t = Convert.ToDateTime(NewDate.Text + " " + NewTime.Text);
            filesNames = Directory.GetFiles(PathDir.Text).ToList();
            foreach (string file in filesNames)
            {
                File.SetCreationTime(file, t);
                File.SetLastWriteTime(file, t);
                File.SetLastAccessTime(file, t);
            }
            System.Windows.MessageBox.Show("Выполнено", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool IsCorrectTime(string newTime)
        {
            if (String.IsNullOrEmpty(newTime)) return false;
            if (Regex.IsMatch(newTime, "[a-z] + [A-Z] + [;,*-]")) return false;
            return true;
        }
    }
}