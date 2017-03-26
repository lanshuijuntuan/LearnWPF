using System;
using System.Collections.Generic;
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

namespace FlowDocumentReaderDemo4
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
    }

    public class User:INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get { return name; }
            set 
            {
                if(value!=name)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }


        private int age;

        public int Age
        {
            get { return age; }
            set
            {
                if (value != age)
                {
                    age = value;
                    OnPropertyChanged("Age");
                }
            }
        }


        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
