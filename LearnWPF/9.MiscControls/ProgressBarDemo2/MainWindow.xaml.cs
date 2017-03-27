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

namespace ProgressBarDemo2
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

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerAsync();

        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.pbStatus.Value = e.ProgressPercentage;
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
           for(int i=0;i<=100;i++)
           {
               var worker = sender as BackgroundWorker;
               if(worker!=null)
               {
                   worker.ReportProgress(i);
               }
               i++;
               System.Threading.Thread.Sleep(100);
           }
        }
    }
}
