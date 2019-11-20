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

            //task = Task.Factory.StartNew(() => Thread.Sleep(1000));
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
            //var resultTasks = Task.WhenAll(tasks).Result;
            //#endregion

            //#region ContinueWith
            //intTask = Task.Run(() =>
            //{
            //    Thread.Sleep(1000);
            //    return 5;
            //});

            //var continueTask = intTask.ContinueWith((x) => x.Result + 5);
            //result = intTask.Result;
            //var result2 = continueTask.Result;
            //#endregion

            //#region Task Cancelling
            //var tokenSource = new CancellationTokenSource();
            //CancellationToken ct = tokenSource.Token;

            //task = Task.Factory.StartNew(() =>
            //{
            //    ct.ThrowIfCancellationRequested();

            //    bool moreToDo = true;
            //    while (moreToDo)
            //    {
            //        Thread.Sleep(500);
            //        if (ct.IsCancellationRequested)
            //        {
            //            //Clean your data
            //            ct.ThrowIfCancellationRequested();
            //        }

            //    }
            //}, tokenSource.Token);

            //tokenSource.Cancel();
            //try
            //{
            //    task.Wait();
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
