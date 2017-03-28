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

namespace TabControlDemo3
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

        private void pre_click(object sender, RoutedEventArgs e)
        {
            var index = tbSample.SelectedIndex-1;
            if(index<0)
            {
                index = this.tbSample.Items.Count - 1;
            }
            this.tbSample.SelectedIndex = index;
        }

        private void next_click(object sender, RoutedEventArgs e)
        {
            var index = tbSample.SelectedIndex + 1;
            if(index>=this.tbSample.Items.Count)
            {
                index = 0;
            }
            this.tbSample.SelectedIndex = index;
        }

        private void selected_click(object sender, RoutedEventArgs e)
        {
            var tab = tbSample.SelectedItem as TabItem;
            if(tab!=null)
            {
                MessageBox.Show(tab.Header.ToString(), "selected tab");
            }
        }
    }
}
