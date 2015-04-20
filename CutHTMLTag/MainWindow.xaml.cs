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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CutHTMLTag
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {

        }

        private void openFileDialog(TextBox textbox, String filter)
        {
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();

            fileDialog.DefaultExt = "txt";
            if(filter != null)
                fileDialog.Filter = filter;
            Nullable<bool> result = fileDialog.ShowDialog();
            if (result == true)
            {
                textbox.Text = fileDialog.FileName;
            }
        }

        private void saveFileDialog(TextBox textbox, String filter)
        {
            Microsoft.Win32.SaveFileDialog fileDialog = new Microsoft.Win32.SaveFileDialog();

            fileDialog.DefaultExt = "*.txt";
            fileDialog.Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*"; 
            if (filter != null)
                fileDialog.Filter = filter;
            Nullable<bool> result = fileDialog.ShowDialog();
            if (result == true)
            {
                textbox.Text = fileDialog.FileName;
            }
        }


        private void runCommand()
        {
            FileStream stream = File.OpenRead(txtBoxSource.Text);
            Boolean flag = false;
            char inChar;
            int myByte;
            while ((myByte = stream.ReadByte()) != -1)
            {
                inChar = Convert.ToChar(myByte);
                if (inChar.Equals('<'))
                    flag = true;
                else if (inChar.Equals('>'))
                    flag = false;
                
            }

        }

        private void btnBrowserSource_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog(txtBoxSource,null);
        }

        private void btnBrowserDestination_Click(object sender, RoutedEventArgs e)
        {
            saveFileDialog(txtBoxDestination, null);
        }
    }
}
