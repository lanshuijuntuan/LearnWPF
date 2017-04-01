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
using System.Collections;
using System.Collections.ObjectModel;

namespace ListBoxDemo1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ObservableCollection<Course> lst = new ObservableCollection<Course>();
            lst.Add(new Course() { Grade = 90, Name = "语文" });
            lst.Add(new Course() { Grade = 90, Name = "数学" });
            lst.Add(new Course() { Grade = 80, Name = "体育" });
            this.lst_course.ItemsSource = lst;
        }
    }

    public class Course
    {
        public string Name { get; set; }

        public int Grade { get; set; }
       
    }
}
