using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskDemo.HowToUseContinueWith
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> action = (str) =>
                {
                    Console.WriteLine("current task sleep two seconds (that return no result)");
                    System.Threading.Thread.Sleep(10000);
                    Console.WriteLine("Task={0},Thread={1},Str={2}", Task.CurrentId, Thread.CurrentThread.ManagedThreadId, str);
                };

            Console.WriteLine("Creating a sequence of action tasks (that return no result)");
            Task.Factory.StartNew(() => action("alpha")).
                ContinueWith(antecendent => action("beta")).
                ContinueWith(antecendent => action("gama")).Wait();

            Func<int, int> negate =
            (n) =>
            {
                Console.WriteLine("current task sleep two seconds (that return result)");
                System.Threading.Thread.Sleep(10000);
                Console.WriteLine("Task={0},Thread={1},n={2},-n={3}", Task.CurrentId, Thread.CurrentThread.ManagedThreadId, n.ToString(), -n);
                return -n;
            };

            Console.WriteLine("Creating a sequence of action tasks (that return result)");
            Task.Factory.StartNew<int>(() => negate(5)).
                ContinueWith(p => negate(p.Result)).
                ContinueWith(p => negate(p.Result)).Wait();

            Console.WriteLine("Creating a Mix task");
            Task.Factory.StartNew<int>(() => negate(88)).
                ContinueWith(antecendent => action("test")).
                ContinueWith(antecendent => negate(66)).Wait();

            Console.WriteLine("主线程开始执行工作......");

            Thread.Sleep(2000);
            

            Console.WriteLine("主线程完成工作......");

            Console.ReadLine();
            
        }
    }
}
