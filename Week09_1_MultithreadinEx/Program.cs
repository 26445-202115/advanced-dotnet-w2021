using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadinEx
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Inside the method {MethodBase.GetCurrentMethod().Name} ");
            Console.WriteLine($"Managed Thread Id: {Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine("Invoking 'UseThreads' method");
            UseThreads();

            Console.WriteLine("Invoking 'UseThreadPool' method");
            UseThreadPool();
            Thread.Sleep(5000);

            Console.WriteLine("Invoking 'UseParallelLinq' method");
            UseParallelLinq();

            Console.WriteLine("Invoking 'UseTaskParallelLibrary' method");
            UseTaskParallelLibrary();

            Console.WriteLine("Program complete, press any key to exit...");
            Console.ReadKey();
        }

        private static void UseParallelLinq()
        {
            Console.WriteLine($"Inside the method {MethodBase.GetCurrentMethod().Name}");

            Console.WriteLine($"Thread pool Managed Thread Id: {Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine("Doing some work with PLINQ...");
            List<int> numbers = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                numbers.Add(i);
            }

            Console.WriteLine("Calling AsParallel without DegreesOfParallelism");

            foreach(var number in numbers.AsParallel())
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("Calling AsParallel with DegreesOfParallelism");
            foreach(var number in numbers.AsParallel().WithDegreeOfParallelism(Environment.ProcessorCount))
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("Calling AsParallel with DegreesOfParallelism AND AsOrdered");
            foreach (var number in numbers.AsParallel().AsOrdered().WithDegreeOfParallelism(Environment.ProcessorCount))
            {
                Console.WriteLine(number);
            }
        }

        private static void UseThreadPool()
        {
            ThreadPool.QueueUserWorkItem(DoWorkThreadPool);
        }


        private static void DoWorkThreadPool(object state)
        {
            Console.WriteLine($"Inside the method {MethodBase.GetCurrentMethod().Name}");

            Console.WriteLine($"Thread pool Managed Thread Id: {Thread.CurrentThread.ManagedThreadId}");

            int num = 0;
            for(int i =0; i <4000000; i++)
            {
                num = i;
            }
            Console.WriteLine($"Num: {num}");

        }
        private static void UseThreads()
        {
            Console.WriteLine($"Inside the method {MethodBase.GetCurrentMethod().Name} ");

            var thread = new Thread(DoWork);
            Console.WriteLine($"Thread State BEFORE start: {thread.ThreadState}");

            thread.Start();
            Console.WriteLine($"Thread State AFTER start: {thread.ThreadState}");

            var parameterizedThread = new Thread(DoWorkWithParameter);
            Console.WriteLine($"Parameterized Thread State BEFORE start: {parameterizedThread.ThreadState}");

            parameterizedThread.Start(5);

            Console.WriteLine($"Parameterized Thread State AFTER start: {parameterizedThread.ThreadState}");



        }

        private static void DoWork()
        {
            Console.WriteLine($"Inside the method {MethodBase.GetCurrentMethod().Name}");

            Console.WriteLine($"Managed Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(2000);
            Console.WriteLine("Doing some work in DoWork()....");

        }

        private static void DoWorkWithParameter(object paramValue)
        {
            Console.WriteLine($"Inside the method {MethodBase.GetCurrentMethod().Name}");

            Console.WriteLine($"Managed Thread Id: {Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine($"Computation Result : {Convert.ToInt32(paramValue) * Convert.ToInt32(paramValue)}...");
        }

        private static void UseTaskParallelLibrary()
        {
            // invoke one or more operations or actions or methods, etc. in parallel, i.e. in the background
            // or on a background thread
            Parallel.Invoke(() =>
            {
                DoWork();
            }, () =>
            {
                DoWorkWithParameter(5);
            }, () =>
            {
                Console.WriteLine($"Inside the method {MethodBase.GetCurrentMethod().Name}");
                Console.WriteLine($"Managed thread id: {Thread.CurrentThread.ManagedThreadId}");
                Console.WriteLine("Doing work from UseTaskParallelLibraryMethod...");

                for (var i = 0; i < 10; i++)
                {
                    Console.WriteLine(i);
                }
            });
        }

    }
}
