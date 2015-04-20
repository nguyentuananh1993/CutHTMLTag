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
            runCommand();
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

        
String strUTF8Text = null;
 



        private void runCommand()
        {
            StreamWriter dest = new StreamWriter(txtBoxDestination.Text, true, Encoding.UTF8);
            StreamReader sr = new StreamReader(txtBoxSource.Text,Encoding.UTF8); 
            Boolean flag = false;
            Boolean flagEnter = false;
            int j = 0;

            while(true){ // infinit loop
                j++;
                String strLine = sr.ReadLine();
                if (strLine == null) break; 
              for(int i=0;i<strLine.Length;i++){
                if (strLine[i].Equals('<')){
                    flag = true;
                    if(flagEnter)
                        dest.Write("\n");
                    flagEnter = false;
                }
                else if (strLine[i].Equals('>')) {
                    flag = false;
                    continue;
                    }
                if (!flag)
                {
                    dest.Write(strLine[i]);
                    flagEnter = true;
                }
              }
              if(null== strLine) break; // exit point
            }

            sr.Close();
            dest.Close();
            Console.WriteLine("akjdfalkdshfalds anhnt %d.\n", j);
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
