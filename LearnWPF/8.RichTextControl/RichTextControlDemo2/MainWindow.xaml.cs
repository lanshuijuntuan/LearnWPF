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

namespace RichTextControlDemo2
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

        private void rtx_edits_SelectionChanged(object sender, RoutedEventArgs e)
        {
            TextRange tmpRange = new TextRange(rtx_edits.Document.ContentStart, rtx_edits.Selection.Start);
            txtStatus.Text = "Selection starts at character #" + tmpRange.Text.Length + Environment.NewLine;
            txtStatus.Text+="Selection is"+rtx_edits.Selection.Text.Length+" character(s) long"+Environment.NewLine;
            txtStatus.Text += "Selected text:'" + rtx_edits.Selection.Text + "'";
        }

        private void btn_getText_Click(object sender, RoutedEventArgs e)
        {
            TextRange txtRange = new TextRange(rtx_edits.Document.ContentStart, rtx_edits.Document.ContentEnd);
            MessageBox.Show(txtRange.Text);
        }

        private void btn_setText_Click(object sender, RoutedEventArgs e)
        {
            TextRange txtRange = new TextRange(rtx_edits.Document.ContentStart, rtx_edits.Document.ContentEnd);
            txtRange.Text = "another World,another text";
        }

        private void btn_getSelText_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(rtx_edits.Selection.Text);
        }

        private void btn_ReplaceSelText_Click(object sender, RoutedEventArgs e)
        {
            rtx_edits.Selection.Text = "{Replaced text}";
        }

    }
}
