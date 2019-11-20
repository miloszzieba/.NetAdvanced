using System;
using System.Threading;

namespace DotNetAdvanced.MultiThreading
{
    public class CancellationTokenThread
    {
        private readonly CancellationToken token;

        public CancellationTokenThread(CancellationToken token)
        {
            this.token = token;
        }

        public void DoWork()
        {
            Console.WriteLine("Thread started");
            while (!token.IsCancellationRequested)
            {

                Thread.SpinWait(50000);
            }
            Console.WriteLine("Thread cancelled");
        }
    }
}
