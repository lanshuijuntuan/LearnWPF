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

namespace CheckBoxDemo3
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

        private void cbAllFeatures_CheckedChanged(object sender, RoutedEventArgs e)
        {
            bool newval = (cbAllFeatures.IsChecked == true);
            
            this.cbFeatureAbc.IsChecked = newval;
            this.cbFeatureXYZ.IsChecked = newval;
            this.cbFeatureWWW.IsChecked = newval;
        }

       

        private void cbFeature_CheckedChanged(object sender, RoutedEventArgs e)
        {
            cbAllFeatures.IsChecked = null;
            if (cbFeatureXYZ.IsChecked == true && cbFeatureAbc.IsChecked == true && cbFeatureWWW.IsChecked == true)
            {
                cbAllFeatures.IsChecked = true;
            }
            else if (cbFeatureXYZ.IsChecked == false && cbFeatureAbc.IsChecked == false && cbFeatureWWW.IsChecked == false)
            {
                cbAllFeatures.IsChecked = false;
            }
        }

       
    }
}
