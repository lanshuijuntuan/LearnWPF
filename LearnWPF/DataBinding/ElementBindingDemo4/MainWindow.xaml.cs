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

namespace ElementBindingDemo4
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            users.Add(new User() { Name = "张三" });
            users.Add(new User() { Name = "李四" });
            users.Add(new User() { Name = "王麻子" });
            this.lb_user.ItemsSource = users;
        }

        ObservableCollection<User> users = new ObservableCollection<User>();

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            users.Add(new User() { Name = "新用户" });
        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            if(this.lb_user.SelectedItem!=null)
            {
                (this.lb_user.SelectedItem as User).Name = "Random Name";
            }
        }

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            if (this.lb_user.SelectedItem != null)
            {
               users.Remove((this.lb_user.SelectedItem as User));
            }
        }
    }

    public class User:INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if(value!=this.name)
                {
                    this.name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private void NotifyPropertyChanged(string propertyName)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
