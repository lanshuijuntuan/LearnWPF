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

namespace FlowDocumentReaderDemo2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FlowDocument fd = new FlowDocument();
            Paragraph mParagraph = new Paragraph(new Run("Hello,World!"));
            mParagraph.FontSize = 36;
            fd.Blocks.Add(mParagraph);

            mParagraph = new Paragraph(new Run("The ultimate programming greeting"));
            mParagraph.FontSize = 14;
            mParagraph.FontStyle = FontStyles.Italic;
            mParagraph.TextAlignment = TextAlignment.Left;
            mParagraph.Foreground = Brushes.Gray;
            fd.Blocks.Add(mParagraph);

            fdReader.Document = fd;


        }
    }
}
