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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OpenDialogDemo
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

       

        private void btn_smiple_click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog mOpenFileDialog = new OpenFileDialog();
            mOpenFileDialog.Filter = "Txt文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if(mOpenFileDialog.ShowDialog()==true)
            {
                
               byte[] bytes = File.ReadAllBytes(mOpenFileDialog.FileName);
              this.txt_contents.Text= System.Text.Encoding.GetEncoding("gb2312").GetString(bytes, 0, bytes.Length);
            }
        }

        private void btn_image_click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog mOpenFileDialog = new OpenFileDialog();
            mOpenFileDialog.Filter = "jpg文件(*.jpg)|*.jpg|png文件(*.png)|*.png";
            if(mOpenFileDialog.ShowDialog()==true)
            {

                txt_contents.Background = new ImageBrush(new BitmapImage(new Uri(mOpenFileDialog.FileName, UriKind.Absolute)));
            }
        }

        private void btn_support_multiple_files(object sender, RoutedEventArgs e)
        {
            OpenFileDialog mOpenFileDialog = new OpenFileDialog();
            mOpenFileDialog.Filter = "jpg文件(*.jpg)|*.jpg|png文件(*.png)|*.png";
            mOpenFileDialog.Multiselect = true;
            if (mOpenFileDialog.ShowDialog() == true)
            {
                this.listbox.ItemsSource = mOpenFileDialog.SafeFileNames.ToArray();
            }
        }

        private void btn_initlizefolder_click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog mOpenFileDialog = new OpenFileDialog();
            mOpenFileDialog.Filter = "Txt文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            mOpenFileDialog.InitialDirectory =Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (mOpenFileDialog.ShowDialog() == true)
            {

                byte[] bytes = File.ReadAllBytes(mOpenFileDialog.FileName);
                this.txt_contents.Text = System.Text.Encoding.GetEncoding("gb2312").GetString(bytes, 0, bytes.Length);
            }
        }
    }
}
