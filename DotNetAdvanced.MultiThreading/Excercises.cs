using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetAdvanced.MultiThreading
{
    public static class Excercises
    {
        #region Excersise 1
        public static void Excercise1()
        {
            var bag = new ConcurrentBag<int>();
            var threads = new List<Thread>();
            for (var i = 0; i < 10; i++)
            {
                var j = i;
                var thread = new Thread(() =>
                {
                    bag.Add(j * 5 + 4);
                });
                thread.Start();
                threads.Add(thread);
            }

            foreach (var t in threads)
                t.Join();

            Console.WriteLine(bag.Sum());
        }
        #endregion

        #region Excersise 2
        public static void Excercise2()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var sum = 0;
            Action action = () =>
            {
                int innerSum = 0;
                try
                {
                    int counter = 0;
                    while (!token.IsCancellationRequested)
                    {
                        Console.WriteLine(counter);
                        innerSum += counter;
                        counter++;
                        Thread.Sleep(500);
                    }
                }
                catch (ThreadInterruptedException)
                {
                }
                catch (ThreadAbortException)
                {
                    sum = 0;
                }
                sum = innerSum;
            };

            var thread = new Thread(new ThreadStart(action));
            thread.Start();
            Console.ReadLine();
            thread.Abort();

            thread = new Thread(new ThreadStart(action));
            thread.Start();
            Console.ReadLine();
            thread.Interrupt();
            thread.Join();
            Console.WriteLine($"Suma to {sum}");

            sum = 0;
            thread = new Thread(new ThreadStart(action));
            thread.Start();
            Console.ReadLine();
            cts.Cancel();
            thread.Join();
            Console.WriteLine($"Suma to {sum}");
        }
        #endregion

        #region Excercise 3
        public static void Excercise3()
        {
            int threadCount = 0;
            var stack = new ConcurrentStack<int>();
            var cts = new CancellationTokenSource();
            var primeGenerator = new PrimeGenerator(stack, cts.Token);
            var threads = new List<Thread>();
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 3000; i++)
            {
                int j = i;
                var thread = new Thread(() =>
                {
                    threadCount++;
                    Console.WriteLine(threadCount);
                    primeGenerator.GeneratePrimes(j * 100000, 100000);
                    threadCount--;
                    Console.WriteLine(threadCount);
                });
                thread.Start();
                threads.Add(thread);
            };

            Thread.Sleep(30_000);
            cts.Cancel();
            sw.Stop();

            var count = stack.Count;
            for(int i = 0; i < 20;i++)
            {
                stack.TryPop(out int result);
                Console.Write(result + ", ");
            }

            Console.WriteLine();
            Console.WriteLine($"Thread count: {threadCount}");
            Console.WriteLine($"Count: {count}");
            Console.WriteLine($"Time: {sw.ElapsedMilliseconds} ms");
            Console.ReadLine();
        }
        #endregion

    }
}
