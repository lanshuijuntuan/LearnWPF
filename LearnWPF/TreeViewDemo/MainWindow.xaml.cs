using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TreeViewDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var station= new Station()
            {
                Name = "1",
                Code = "2",
                Children = new List<Station>()
                {
                    new Station()
                    {
                        Code="2",
                        Name="3"
                    },
                    new Station()
                    {
                        Code="3",
                        Name="4"
                    }
                }
            };
            this.treeview1.ItemsSource = new List<Station>() { station };
        }
    }

    public class Station
    {
        public string Name { get; set; }

        public string Code { get; set; }
        public List<Station> Children { get; set; }
    }
}
