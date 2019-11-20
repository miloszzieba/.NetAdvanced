using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace DotNetAdvanced.MultiThreadingSynchronization
{
    internal class Program
    {
        public static Mutex Mut { get; set; } = new Mutex(false, "Global\\uniquename");

        private static void Main(string[] args)
        {
            var mutexThread = new MutexThread();
            #region Mutex
            for (var i = 0; i < 3; i++)
            {
                var thread = new Thread(new ThreadStart(mutexThread.UseResource))
                {
                    Name = i.ToString()
                };
                thread.Start();
            }
            #endregion

            #region Monitor
            var random = new Random();
            for (var i = 0; i < 10; i++)
            {
                var thread = new Thread(() =>
                    {
                        var name = Thread.CurrentThread.Name;
                        Console.WriteLine($"#{name}: Waiting");
                        Monitor.Enter(random);
                        Console.WriteLine($"#{name}: Working");
                        Thread.Sleep(500);
                        for (var j = 0; j < 10000; j++)
                            random.Next(0, 1001);
                        Console.WriteLine($"#{name}: Stopped");
                        Monitor.Exit(random);
                    });
                thread.Name = i.ToString();
                thread.Start();
            }
            Thread.Sleep(5000);
            #endregion

            #region Interlocked
            var number = 0;
            Interlocked.Add(ref number, 5);
            Interlocked.Increment(ref number);
            Interlocked.Decrement(ref number);
            Interlocked.Exchange(ref number, 10);
            //If 10, change to 20
            Interlocked.CompareExchange(ref number, 20, 10);
            #endregion

            //Heavy, long time waits
            #region Semaphore
            var semaphore = new Semaphore(3, 3);
            for (var i = 0; i < 10; i++)
            {
                var thread = new Thread(() =>
                {
                    var name = Thread.CurrentThread.Name;
                    Console.WriteLine($"#{name}: Waiting");
                    semaphore.WaitOne();
                    Console.WriteLine($"#{name}: Working");
                    Thread.Sleep(2000);
                    Console.WriteLine($"#{name}: Stopped");
                    semaphore.Release();
                });
                thread.Name = i.ToString();
                thread.Start();
            }
            Thread.Sleep(10000);
            #endregion

            //Short time waits
            #region SemaphoreSlim
            var semaphoreSlim = new SemaphoreSlim(0);
            for (var i = 0; i < 10; i++)
            {
                var thread = new Thread(() =>
                {
                    semaphoreSlim.Wait();
                    Thread.Sleep(1000);
                    semaphoreSlim.Release();
                })
                {
                    Name = i.ToString()
                };
                thread.Start();
            }
            semaphoreSlim.Release(3);
            #endregion

            #region AutoResetEvent
            var autoEvent = new AutoResetEvent(false);
            for (var i = 0; i < 3; i++)
            {
                var thread = new Thread(() =>
                {
                    Console.WriteLine("Waiting");
                    autoEvent.WaitOne();
                    Console.WriteLine("I'm in");
                    Thread.Sleep(1000);

                })
                {
                    Name = i.ToString()
                };
                thread.Start();
            }
            Thread.Sleep(500);
            autoEvent.Set();
            autoEvent.Set();
            autoEvent.Set();
            #endregion

            #region ManualResetEvent
            var manualReset = new ManualResetEventSlim();
            for (var i = 0; i < 3; i++)
            {
                var thread = new Thread(() =>
                {
                    Thread.Sleep(500);
                    Console.WriteLine("Waiting");
                    manualReset.Wait();
                    Console.WriteLine("I'm in");
                    Thread.Sleep(1000);
                })
                {
                    Name = i.ToString()
                };
                thread.Start();
            }
            manualReset.Set();
            Thread.Sleep(5000);
            manualReset.Reset();
            #endregion

            #region CountdownEvent
            var countdown = new CountdownEvent(3);
            for (var i = 0; i < 3; i++)
            {
                var thread = new Thread(() =>
                {
                    Thread.Sleep(1000);
                    countdown.Signal();
                })
                {
                    Name = i.ToString()
                };
                thread.Start();
            }
            countdown.Wait();
            #endregion

            #region barrier
            var result = new List<int>();
            var success = false;
            var barrier = new Barrier(3, (bar) =>
            {
                if (result.Count > 20)
                    success = true;
            });
            for (var i = 0; i < 3; i++)
            {
                var thread = new Thread(() =>
                {
                    while (success == false)
                    {
                        result.Add(1);
                        barrier.SignalAndWait();
                    }
                });
                thread.Start();
            }
            #endregion

            #region ReaderWriterLockSlim
            var rwlock = new ReaderWriterLockSlim();
            var list = new List<int>() { 1, 2, 3 };
            for (var i = 0; i < 3; i++)
            {
                var thread = new Thread(() =>
                {
                    rwlock.EnterReadLock();
                    foreach (var j in list)
                    {

                    }
                    rwlock.ExitReadLock();
                    rwlock.EnterUpgradeableReadLock();
                    rwlock.ExitUpgradeableReadLock();
                    rwlock.EnterWriteLock();
                    list.Add(1);
                    rwlock.ExitWriteLock();
                });
                thread.Start();
            }
            #endregion

            #region SpinLock
            var spinLock = new SpinLock();
            for (var i = 0; i < 3; i++)
            {
                var thread = new Thread(() =>
                {
                    var lockTaken = false;
                    spinLock.Enter(ref lockTaken);
                    Thread.Sleep(1000);
                    spinLock.Exit();
                });
                thread.Start();
            }
            #endregion
        }

        ~Program()
        {
            Mut.Dispose();
        }
    }
}
