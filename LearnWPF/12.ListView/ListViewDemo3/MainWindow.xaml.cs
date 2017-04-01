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
using System.Collections.ObjectModel;

namespace ListViewDemo3
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
            this.lstview_person.ItemsSource = persons;
        }

    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Mail { get; set; }
    }
}
