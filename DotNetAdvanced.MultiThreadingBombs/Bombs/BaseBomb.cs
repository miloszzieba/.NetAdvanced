using System.Threading;

namespace DotNetAdvanced.MultiThreadingBombs.Bombs
{
    public class BaseBomb
    {
        private string lastThreadName = "";
        protected int boom = 0;

        public virtual void PushTheButton()
        {
            if (this.lastThreadName == Thread.CurrentThread.Name)
                Interlocked.Exchange(ref this.boom, 1);

            Interlocked.Exchange(ref this.lastThreadName, Thread.CurrentThread.Name);
        }

        public virtual void Verify()
        {
            if (this.boom > 0)
                throw new Boom();
        }
    }
}
