using System;
using System.Collections.Generic;
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

namespace WebBrowserControlDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            wbrowser.Navigate("http://www.baidu.com");
        }

        private void Back_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            wbrowser.GoBack();
        }

        private void Forward_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            wbrowser.GoForward();
        }

        private void Go_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            wbrowser.Navigate(txtUrl.Text);
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
            {
                var txtbox=sender as TextBox;
                wbrowser.Navigate(txtbox.Text);
            }
        }

        private void CanBack_Executed(object sender, CanExecuteRoutedEventArgs e)
        {
            if(wbrowser!=null&&wbrowser.CanGoBack)
            {
               e.CanExecute = true;
            }
        }

        private void CanForward_Executed(object sender, CanExecuteRoutedEventArgs e)
        {
            if(wbrowser!=null&&wbrowser.CanGoForward)
            {
                e.CanExecute = true;
            }
        }
    }
}
