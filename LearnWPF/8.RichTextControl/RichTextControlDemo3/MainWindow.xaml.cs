using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace RichTextControlDemo3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cbx_fontfamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(p => p.Source);
            cbx_fontsize.ItemsSource = new List<Double>() { 8, 9, 10, 11, 12, 13, 14, 15, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
        }

        private void cbx_fontfamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbx_fontfamily.SelectedItem!=null)
            {
                rtb_edit.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cbx_fontfamily.SelectedItem);
            }
        }

        private void cbx_fontsize_TextChanged(object sender, TextChangedEventArgs e)
        {
            rtb_edit.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cbx_fontsize.Text);
        }

        private void rtb_edit_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object fontweight = rtb_edit.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btn_bold.IsChecked = ((fontweight != DependencyProperty.UnsetValue) && (fontweight.Equals(FontWeights.Bold)));
            object fontstyle = rtb_edit.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btn_italic.IsChecked = (fontstyle != DependencyProperty.UnsetValue && fontstyle.Equals(FontStyles.Italic));
            object textDecoration=rtb_edit.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btn_underline.IsChecked=(textDecoration!=DependencyProperty.UnsetValue&&textDecoration.Equals(TextDecorations.Underline));

            var fontfamily = rtb_edit.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cbx_fontfamily.SelectedItem = fontfamily;
            var fontsize = rtb_edit.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cbx_fontsize.Text = fontsize.ToString();

        }

      

        

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog mDialog = new OpenFileDialog();
            mDialog.Filter = "rich text format (*.rtf)|*.rtf|所有文件(*.*)|*.*";
            mDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if(mDialog.ShowDialog()==true)
            {
                using(FileStream fs=File.Open(mDialog.FileName,FileMode.Open))
                {
                    TextRange txtRange = new TextRange(rtb_edit.Document.ContentStart, rtb_edit.Document.ContentEnd);
                    txtRange.Load(fs,DataFormats.Rtf);
                }
            }
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog mDialog = new SaveFileDialog();
            mDialog.Filter = "rich text format (*.rtf)|*.rtf|所有文件 (*.*)|*.*";
            mDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if(mDialog.ShowDialog()==true)
            {
                using(FileStream fs=File.Open(mDialog.FileName,FileMode.Create))
                {
                    TextRange txtRange = new TextRange(rtb_edit.Document.ContentStart, rtb_edit.Document.ContentEnd);
                    txtRange.Save(fs, DataFormats.Rtf);
                }
            }
        }
    }
}
