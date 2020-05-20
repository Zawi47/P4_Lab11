using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace P4_Lab11
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public TextBoxContent TextBoxC { get; set; } = new TextBoxContent();
        private FileSystemWatcher FSM = new FileSystemWatcher();
        private string _path;
        public Window1()
        {
            InitializeComponent();
            MyTextBox.DataContext = TextBoxC;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog()
            {
                Title = "Wybierz plik do obserwowania",
                Filter = "Pliki txt|*.txt"
            };
            fileDialog.ShowDialog(this);

            _path = fileDialog.FileName;
            
            TextBoxC.Content = File.ReadAllText(_path);
            FSM.Path = _path.Replace(fileDialog.SafeFileName, string.Empty);
            FSM.NotifyFilter = NotifyFilters.LastWrite;
            FSM.EnableRaisingEvents = true;
            FSM.Changed += FSM_Changed;
        }

        private void FSM_Changed(object sender, FileSystemEventArgs e)
        {
            TextBoxC.Content = File.ReadAllText(_path);

        }
    }
}
