using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetAdvanced.PLinq
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var array = Enumerable.Range(0, 100_000).ToArray();

            //#region AsParallel
            //var sw = new Stopwatch();
            //sw.Start();
            //var sum = array.Select(x => {
            //    Thread.Sleep(2);
            //    return x;
            //}).ToList();
            //sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds);
            //sw.Restart();
            //var sumParallel = array.AsParallel().AsOrdered().Select(x =>
            //{
            //    Thread.Sleep(2);
            //    return x;
            //}).ToList();
            //sw.Stop();
            //Console.WriteLine(sumParallel);
            //Console.WriteLine(sw.ElapsedMilliseconds);
            //Console.ReadLine();
            //#endregion

            //#region Cancellation
            //var cts = new CancellationTokenSource();
            //Task.Run(() =>
            //{
            //    Thread.Sleep(2000);
            //    cts.Cancel();
            //});
            //try
            //{
            //    var result = array.AsParallel().WithCancellation(cts.Token)
            //        .Where(x => x % 3 == 0)
            //        .Select(x =>
            //        {
            //            Thread.Sleep(100);
            //            return x;
            //        })
            //        .OrderByDescending(x => x)
            //        .ToArray();
            //}
            //catch (OperationCanceledException e)
            //{ }
            //finally
            //{
            //    cts.Dispose();
            //}
            //#endregion

            //#region ExceptionHandling
            //try
            //{
            //    var result = array.AsParallel().Select(x =>
            //    {
            //        if (x % 100 == 0)
            //            throw new ApplicationException("Happy exception");
            //        return x;
            //    }).ToList();
            //}
            //catch (AggregateException ex)
            //{
            //    foreach (var innerEx in ex.InnerExceptions)
            //        Console.WriteLine(ex.Message);
            //}
            //#endregion

            #region Parallel Aggregate
            var source = new int[1000];
            var rand = new Random();
            for (var x = 0; x < source.Length; x++)
                source[x] = rand.Next(0, 100);


            var standardDev = StandardDeviation.Calculate(source);
            Console.WriteLine("Standard deviation is {0}", standardDev);
            Console.ReadLine();
            #endregion
        }
    }
}
