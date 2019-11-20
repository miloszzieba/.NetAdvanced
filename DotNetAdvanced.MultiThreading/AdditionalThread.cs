using System;
using System.Threading;

namespace DotNetAdvanced.MultiThreading
{
    public class AdditionalThread
    {
        public void DoWork(object obj)
        {
            Console.WriteLine("Additional thread started");
            Thread.Sleep(5000);
            Console.WriteLine("Additional thread finished important work");
        }
    }
}
