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

namespace ListBoxDemo2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ObservableCollection<Book> books = new ObservableCollection<Book>();
            books.Add(new Book() { Title = "语文", Completetion = 13 });
            books.Add(new Book() { Title = "数学", Completetion = 45 });
            books.Add(new Book() { Title = "地理", Completetion = 67 });
            lstbooks.ItemsSource = books;

        }

        private void ShowSelectedItems(object sender, RoutedEventArgs e)
        {
            if (lstbooks.SelectedItem != null)
            {
                var book = lstbooks.SelectedItem as Book;
                if (book != null)
                {
                    this.Title = book.Title;
                }
            }

        }

        private void GoNextItem(object sender, RoutedEventArgs e)
        {
            if (this.lstbooks.SelectedIndex == -1)
            {
                return;
            }
            if (lstbooks.SelectedIndex == lstbooks.Items.Count - 1)
            {
                lstbooks.SelectedIndex = 0;
            }
            else
            {
                this.lstbooks.SelectedIndex = (lstbooks.SelectedIndex + 1);
            }

        }

        private void GoBackItem(object sender, RoutedEventArgs e)
        {
            if (this.lstbooks.SelectedIndex == -1)
            {
                return;
            }
            if (lstbooks.SelectedIndex ==0 )
            {
                lstbooks.SelectedIndex = lstbooks.Items.Count - 1;
            }
            else
            {
                this.lstbooks.SelectedIndex = (lstbooks.SelectedIndex - 1);
            }
        }

        private void SelectAllItems(object sender, RoutedEventArgs e)
        {
           foreach(var item in this.lstbooks.Items)
           {
               this.lstbooks.SelectedItems.Add(item);
           }
        }
    }

    public class Book
    {
        public string Title
        {
            get;
            set;
        }

        public int Completetion
        {
            get;
            set;
        }
    }
}
