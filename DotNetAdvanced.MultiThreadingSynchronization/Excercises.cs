using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetAdvanced.MultiThreadingSynchronization
{
    public static class Excercises
    {
        #region Excercise 1
        public static void Excercise1()
        {
            var path = "D:\\text.txt";
            var threads = new List<Thread>();
            for (var i = 0; i < 10; i++)
            {
                var thread = new Thread(() =>
                {
                    try
                    {
                        var name = Thread.CurrentThread.Name;
                        Monitor.Enter(path);

                        var sum = File.Exists(path) ? File.ReadAllLines(path)
                        .Select(x => Int32.Parse(x))
                        .Sum() + 4 : 1;

                        File.AppendAllLines(path, new List<string>() { sum.ToString() });
                    }
                    finally {
                        Monitor.Exit(path);
                    }
                   
                });
                threads.Add(thread);
                thread.Start();
            }

            foreach (var thread in threads)
                thread.Join();
        }
        #endregion

        #region Excercise 2
        public static void Excercise2()
        {
            var counter = 0;
            var stack = new ConcurrentStack<int>();
            var excerciseSemaphore = new SemaphoreSlim(0);
            for (int i = 0; i < 5; i++)
            {
                var thread = new Thread(() =>
                {
                    while (true)
                    {
                        stack.Push(Interlocked.Increment(ref counter));
                        excerciseSemaphore.Release();
                        Thread.Sleep(5000);
                    }
                });
                thread.Start();
                Thread.Sleep(1000);
            }

            for (int i = 0; i < 5; i++)
            {
                var thread = new Thread(() =>
                {
                    while (true)
                    {
                        var name = Thread.CurrentThread.Name;
                        excerciseSemaphore.Wait();
                        stack.TryPop(out int excerciseResult);
                        Console.WriteLine($"#{name}: {excerciseResult}, StackCount: {stack.Count}");
                        Thread.Sleep(4000);
                    }
                })
                {
                    Name = i.ToString()
                };
                thread.Start();
                Thread.Sleep(2000);
            }
        }
        #endregion

        #region Excercise 3
        public static void Excercise3()
        {
            var stack = new ConcurrentStack<int>();
            var countDownEvent = new CountdownEvent(50_000);
            var cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;
            var primeGenerator = new SignallingPrimeGenerator(stack, countDownEvent, token);
            var threads = new List<Thread>();
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 300; i++)
            {
                int j = i;
                var thread = new Thread(() =>
                {
                    primeGenerator.GeneratePrimes(j * 10_000, 10_000);
                });
                thread.Start();
                threads.Add(thread);
            };

            countDownEvent.Wait();
            cancellationTokenSource.Cancel();
            sw.Stop();

            var count = stack.Count;
            for (int i = 0; i < 20; i++)
            {
                stack.TryPop(out int result);
                Console.Write(result + ", ");
            }

            Console.WriteLine();
            Console.WriteLine($"Count: {count}");
            Console.WriteLine($"Time: {sw.ElapsedMilliseconds} ms");
            Console.ReadLine();
        }
        #endregion

    }
}
