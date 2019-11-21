using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetAdvanced.Tasks
{
    public static class Excercises
    {
        #region Excercise 1
        public static void Excercise1()
        {
            var sw = new Stopwatch();
            sw.Start();
            var threads = new Thread[1000];
            for (var i = 0; i < 1000; i++)
            {
                var thread = new Thread(() =>
                {
                    int j = 0;
                    j++;
                });
                thread.Start();
                threads[i] = thread;
            }

            for (var i = 0; i < 100; i++)
                threads[i].Join();
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Restart();
            var taskArray = new Task[1000];
            for (var i = 0; i < 1000; i++)
            {
                var fastTask = Task.Run(() =>
                {
                    int j = 0;
                    j++;
                    return j;
                });
                taskArray[i] = fastTask;
            }

            Task.WaitAll(taskArray);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
        #endregion

        #region Excercise 2
        public static void Excercise2()
        {
            //var exceptionThread = new Thread(() =>
            //{
            //    try
            //    {
            //        throw new ApplicationException("Boom!");
            //    }
            //    catch { }
            //});
            //exceptionThread.IsBackground = true;
            //exceptionThread.Start();
            //try
            //{
            //    exceptionThread.Join();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            var exceptionTask = Task.Run(() => throw new ApplicationException("Boom!"));
            try
            {
                exceptionTask.Wait();
            }
            catch (AggregateException ex)
            {
                foreach (var inner in ex.InnerExceptions)
                    Console.WriteLine(inner.Message);
            }
        }
        #endregion

        #region Excersise 3
        public static void Excercise3()
        {
            var powerTask = Task.Run(() => 5);
            for (int i = 0; i < 3; i++)
                powerTask = powerTask.ContinueWith((x) => {
                    int y = x.Result;
                    return y * y;
                });

            Console.WriteLine(powerTask.Result);
        }
        #endregion

    }
}
