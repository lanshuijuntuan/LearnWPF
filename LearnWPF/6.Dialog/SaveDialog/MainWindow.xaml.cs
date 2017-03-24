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

namespace SaveDialog
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

        private void btn_save_file(object sender, RoutedEventArgs e)
        {
            SaveFileDialog mSaveFileDialog = new SaveFileDialog();
            mSaveFileDialog.Filter = "文本文档(*.txt)|*.txt|所有文件(*.*)|*.*";
            mSaveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if(mSaveFileDialog.ShowDialog()==true)
            {
                using(FileStream fs=File.Create(mSaveFileDialog.FileName))
                {
                    byte[] bytes=System.Text.Encoding.Default.GetBytes(txt_content.Text);
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                }
            }
        }
    }
}
