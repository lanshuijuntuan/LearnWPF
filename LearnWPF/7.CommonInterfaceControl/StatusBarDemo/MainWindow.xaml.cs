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

namespace StatusBarDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtEdit_SelectionChanged(object sender, RoutedEventArgs e)
        {
            int row = txtEdit.GetLineIndexFromCharacterIndex(txtEdit.CaretIndex);
            int col = txtEdit.CaretIndex - txtEdit.GetCharacterIndexFromLineIndex(row);
            lbcurpostion.Text = "Line " + (row + 1).ToString() + ",Char " + (col + 1).ToString();

        }
    }
}
