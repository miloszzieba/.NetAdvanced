using System.Threading;

namespace DotNetAdvanced.MultiThreadingBombs.Bombs
{
    public class AutoResetEventBomb : BaseBomb
    {
        private int counter = 0;

        public void PushTheButton(AutoResetEvent autoResetEvent)
        {
            base.PushTheButton();
            Interlocked.Increment(ref this.counter);
            autoResetEvent.Set();
        }

        public override void Verify()
        {
            base.Verify();

            if (this.counter != 6)
                throw new Boom();
        }
    }
}
