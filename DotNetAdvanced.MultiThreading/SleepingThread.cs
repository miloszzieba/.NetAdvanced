using System;
using System.Threading;

namespace DotNetAdvanced.MultiThreading
{
    public class SleepingThread
    {
        public void Sleep()
        {
            try
            {
                Console.WriteLine("Thread sleeping");
                Thread.Sleep(Timeout.Infinite);
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine("Thread interrupted");
            }
            catch (ThreadAbortException)
            {
                Console.WriteLine("Thread aborted");
            }
            finally
            {
                Console.WriteLine("Finally");
            }
            Console.WriteLine("Some next work thread had to do");
        }

    }
}
