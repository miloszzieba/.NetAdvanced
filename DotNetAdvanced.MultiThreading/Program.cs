using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace DotNetAdvanced.MultiThreading
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region Start Thread
            var additionalThread = new AdditionalThread();
            var thread = new Thread(additionalThread.DoWork);
            Console.WriteLine("Additional thread starting");
            thread.Start(1);
            Console.WriteLine("Main thread waiting for additional thread");
            thread.Join();
            Console.WriteLine("Additional thread stopped execution");
            #endregion

            #region Return Value
            var value = "TEST";
            thread = new Thread(
                (x) =>
                {
                    Thread.Sleep(100);
                    value = "Return value";
                });
            thread.Start(value);
            thread.Join();
            Console.WriteLine(value);
            #endregion

            #region Thread IsBackground
            thread = new Thread(
                () =>
                {
                    while (true) { }
                });
            thread.IsBackground = true;
            thread.Start();
            Console.WriteLine();
            #endregion

            #region Sleeping
            var sleepingThread = new SleepingThread();
            thread = new Thread(sleepingThread.Sleep);
            thread.Start();
            Thread.Sleep(2000);
            thread.Interrupt();

            Thread.Sleep(1000);

            thread = new Thread(sleepingThread.Sleep);
            thread.Start();
            Thread.Sleep(2000);
            thread.Abort();
            #endregion

            #region Thread priority
            thread = new Thread(new AdditionalThread().DoWork);
            thread.Priority = ThreadPriority.Highest;
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
            thread.Start(1);
            thread.Join();
            #endregion

            #region CancellationToken
            var cts = new CancellationTokenSource();
            var cancellationTokenThread = new CancellationTokenThread(cts.Token);

            thread = new Thread(new ThreadStart(cancellationTokenThread.DoWork));
            thread.Start();

            Thread.Sleep(10000);
            Console.WriteLine("Cancellation requested");
            cts.Cancel();
            thread.Join();
            cts.Dispose();
            #endregion
        }
    }
}
