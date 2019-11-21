using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetAdvanced.TPL
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region Parallel for
            long totalSize = 0;
            var files = Directory.GetFiles("D:\\Source", "*", SearchOption.AllDirectories);
            Console.WriteLine($"Count: {files.Length}");
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < files.Length; i++)
            {
                var fi = new FileInfo(files[i]);
                var size = fi.Length;
                totalSize += size;
            }
            sw.Stop();
            Console.WriteLine($"Czas: {sw.ElapsedMilliseconds}ms");
            Console.WriteLine(totalSize);

            totalSize = 0;
            sw.Restart();
            Parallel.For(0, files.Length, new ParallelOptions() { MaxDegreeOfParallelism = 5 },
                         index =>
                         {
                             var fi = new FileInfo(files[index]);
                             var size = fi.Length;
                             Interlocked.Add(ref totalSize, size);
                         });
            sw.Stop();
            Console.WriteLine($"Czas: {sw.ElapsedMilliseconds}ms");
            Console.WriteLine(totalSize);
            Console.ReadLine();
            #endregion

            //#region Parallel ForEach
            //var array = Enumerable.Range(0, 100_000).ToArray();
            //Parallel.ForEach(array, (x) =>
            //{
            //    Console.WriteLine(x);
            //    Thread.Sleep(5000);
            //});
            //#endregion

            //#region Parallel Invoke
            //Parallel.Invoke(new ParallelOptions() { MaxDegreeOfParallelism = 10 },
            //    () => { Console.WriteLine("Akcja 1"); },
            //    () => { Console.WriteLine("Akcja 2"); },
            //    () => { Console.WriteLine("Akcja 3"); });
            //#endregion
        }
    }
}
