using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadPoolDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int workerThread=0;
            int completionThread=0;
            ThreadPool.GetMaxThreads( out workerThread, out completionThread);
            Console.WriteLine(string.Format("当前ThreadPool.GetMaxThreads()线程数目,workerThread：{0};completionThread：{1}", workerThread, completionThread));
            for (int i = 0; i < 5; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(TestThread2),i);
            }

            Console.WriteLine(string.Format("当前ThreadPool.GetMaxThreads()线程数目,workerThread：{0};completionThread：{1}", workerThread, completionThread));

            Console.ReadLine();
        }


        public  static void TestThread(object test)
        {
            Console.WriteLine(string.Format("当前线程ID:{0}", Thread.CurrentThread.ManagedThreadId));
            int workerThread = 0;
            int completionThread = 0;
            Console.WriteLine(string.Format("当前ThreadPool.GetMaxThreads()线程数目,workerThread：{0};completionThread：{1}", workerThread, completionThread));
        }


        public static void TestThread2(object num)
        {
            Console.WriteLine(string.Format("当前线程ID:{0},num:{1}", Thread.CurrentThread.ManagedThreadId,num));
            Thread.Sleep((10 - (int)num) * 1000);
            int workerThread = 0;
            int completionThread = 0;
            Console.WriteLine(string.Format("TestThread2当前ThreadPool.GetMaxThreads()线程数目,workerThread：{0};completionThread：{1},num:{2}", workerThread, completionThread,num));
           
        }
    }
}
