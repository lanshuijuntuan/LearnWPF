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

namespace MessageBoxDemo
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



        private void Button_Message_buttons_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hello world !", "my app", MessageBoxButton.YesNoCancel);
        }

        private void Button_Smiple_Messagebox_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hello world !");
        }

        private void Button_Messagebox_with_title_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hello world !", "my app");
        }

        private void button_msg_with_response_click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("hello world !", "my app", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("you choice yes", "my app");
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("you choice No", "my app");
                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show("you choice Cancel", "my app");
                    break;
            }
        }

        private void btn_msg_with_icon(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hello world!", "my app", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
        }

        private void btn_msg_with_default_choice(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hello world!", "my app", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.No);
        }
    }
}
