using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ListViewDemo
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

        private void tbxName_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void checkboxHasJob_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox mCheckBox = e.OriginalSource as CheckBox;
            ContentPresenter mContentPresenter = mCheckBox.TemplatedParent as ContentPresenter;
            Student stu = mContentPresenter.Content as Student;
            MessageBox.Show(string.Format("选中学生姓名为：{0}，年级为：{1}", stu.Name, stu.Grade));

            ListViewItem mListViewItem = this.listviewitems.ItemContainerGenerator.ContainerFromItem(stu) as ListViewItem;

            CheckBox cb = FindVisualChild<CheckBox>(mListViewItem);

            MessageBox.Show(cb.Name + "，" + cb.Height.ToString() + "，" + cb.Width.ToString());

        }

        private ChildType FindVisualChild<ChildType>(DependencyObject obj) where ChildType : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is ChildType)
                {
                    return child as ChildType;
                }
                else
                {
                    ChildType childOfChildren = FindVisualChild<ChildType>(child);
                    if (childOfChildren != null)
                    {
                        return childOfChildren;
                    }
                }
            }
            return null;

        }

        private void StuSort(ListView lv, string sortby, ListSortDirection direction)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(lv.ItemsSource);
            view.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortby, direction);
            view.SortDescriptions.Add(sd);
            view.Refresh();
        }

        private void listviewitems_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader header = e.OriginalSource as GridViewColumnHeader;
            
            StuSort(listviewitems, "Score", ListSortDirection.Descending);
        }
    }

    public class Student
    {
        public string ID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string Grade
        {
            get;
            set;
        }
        public string Professional
        {
            get;
            set;
        }
        public bool HasJob
        {
            get;
            set;
        }

        public float Score
        {
            get;
            set;
        }
    }
}
