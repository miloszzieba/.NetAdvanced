using System.Threading;

namespace DotNetAdvanced.MultiThreadingSynchronization
{
    public class MutexThread
    {
        public void UseResource()
        {
            if (Program.Mut.WaitOne(Timeout.Infinite))
            {
                Thread.Sleep(500);
                Program.Mut.ReleaseMutex();
            }
            else
            {

            }

        }
    }
}
