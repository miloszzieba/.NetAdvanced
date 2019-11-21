using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetAdvanced.Tasks
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //#region Start Task
            //var task = new Task(() => Thread.Sleep(1000));
            //task.Start();
            //task.Wait();

            //task = Task.Run(() => Thread.Sleep(1000));
            //task.Wait();

            //var awaitableTask = Task.Factory.StartNew(() => Thread.Sleep(1000));
            //#endregion

            //#region Return Value
            //Task<int> intTask = Task.Run(() =>
            //{
            //    Thread.Sleep(1000);
            //    return 5;
            //});
            //var result = intTask.Result;
            //#endregion

            //#region Wait All
            //var tasks = new Task<int>[3];
            //for (var i = 0; i < 3; i++)
            //{
            //    tasks[i] = (Task.Run(() => 5));
            //}
            //Task.WaitAll(tasks);
            //var resultTasks = Task.WhenAll(tasks);
            //#endregion

            //#region ContinueWith
            //var intTask = Task.Run(() =>
            //{
            //    Thread.Sleep(1000);
            //    return 5;
            //});

            //var continueTask = intTask.ContinueWith((x) => {
            //    Thread.Sleep(5000);
            //    return x.Result + 5;
            //    });
            //var result = intTask.Result;
            //Console.WriteLine(result);
            //var result2 = continueTask.Result;
            //Console.WriteLine(result2);
            //Console.ReadLine();
            //#endregion

            //#region Task Cancelling
            //var tokenSource = new CancellationTokenSource();
            //var token = tokenSource.Token;

            //var task = Task.Run(() => 5, token);

            //var task2 = Task.Factory.StartNew(() =>
            //{
            //    token.ThrowIfCancellationRequested();

            //    bool moreToDo = true;
            //    while (moreToDo)
            //    {
            //        Thread.Sleep(500);
            //        if (token.IsCancellationRequested)
            //        {
            //            //Clean your data
            //            token.ThrowIfCancellationRequested();
            //        }

            //    }
            //}, tokenSource.Token);

            //tokenSource.Cancel();
            //try
            //{
            //    task2.Wait();
            //}
            //catch (AggregateException e)
            //{
            //}
            //finally
            //{
            //    tokenSource.Dispose();
            //}
            //#endregion
        }
    }
}
