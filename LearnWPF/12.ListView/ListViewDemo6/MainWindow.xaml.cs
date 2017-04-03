using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace ListViewDemo6
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ObservableCollection<Person> persons = new ObservableCollection<Person>();
            persons.Add(new Person() { Name = "张三", Age = 23, Mail = "zhq@163.com" });
            persons.Add(new Person() { Name = "李四", Age = 27, Mail = "wangmazi@163.com" });
            persons.Add(new Person() { Name = "王麻子", Age = 28, Mail = "wangmazi@163.com" });
            this.lstview.ItemsSource = persons;
            CollectionView view =  (CollectionView)CollectionViewSource.GetDefaultView(this.lstview.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Age", ListSortDirection.Ascending));
            view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Descending));
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Mail { get; set; }
    }
}
