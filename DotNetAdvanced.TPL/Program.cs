using System;
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
            //#region Parallel for
            //long totalSize = 0;
            //var files = Directory.GetFiles("D:\\");
            //Parallel.For(0, files.Length,
            //             index =>
            //             {
            //                 var fi = new FileInfo(files[index]);
            //                 var size = fi.Length;
            //                 Interlocked.Add(ref totalSize, size);
            //             });
            //#endregion

            //#region Parallel ForEach
            //var array = Enumerable.Range(0, 100_000).ToArray();
            //Parallel.ForEach(array, (x) => {
            //    Console.WriteLine(x);
            //    Thread.Sleep(5000);
            //});
            //#endregion

            //#region Parallel Invoke
            //Parallel.Invoke(
            //    () => { Console.WriteLine("Akcja 1"); },
            //    () => { Console.WriteLine("Akcja 2"); },
            //    () => { Console.WriteLine("Akcja 3"); }
            //    );
            //#endregion
        }
    }
}
