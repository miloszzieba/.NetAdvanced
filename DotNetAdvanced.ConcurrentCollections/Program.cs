using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetAdvanced.ConcurrentCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Thread-Broken List
            var list = new List<int>();

            for (var i = 0; i < 2000; i++)
            {
                Task.Run(() => list.Add(i));
                Task.Run(() => list.Add(i + 1));
            }

            Thread.Sleep(1000);
            Console.WriteLine(list.Count);
            #endregion

            //#region ConcurrentBag
            //var bag = new ConcurrentBag<int>();

            //for (var i = 0; i < 500; i++)
            //{
            //    Task.Run(() => bag.Add(i));
            //    Task.Run(() => bag.Add(i + 1));
            //}

            //Thread.Sleep(1000);
            //Console.WriteLine(bag.Count);
            //#endregion

            //#region ConcurrentDictionary
            ////Still not thread-safe
            //if (!bag.Any(x => x == 1))
            //    bag.Add(1);

            ////Thread-safe and unique objects
            //var dictionary = new ConcurrentDictionary<int, object>();
            //dictionary.TryAdd(1, null);
            //#endregion

            //#region BlockingCollection
            ////Producer-consumer scenario
            //var blockingCollection = new BlockingCollection<int>();
            //blockingCollection.Add(1);
            //blockingCollection.Add(2);
            //blockingCollection.CompleteAdding();

            //if (blockingCollection.IsAddingCompleted)
            //{
            //    blockingCollection.TryTake(out var result2);
            //}
            //#endregion
        }
    }
}