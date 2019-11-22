using System;
using System.Threading;

namespace DotNetAdvanced.MultiThreadingBombs.Bombs
{
    public class NiceTimingBomb : BaseBomb
    {
        private int counter = 0;
        private readonly DateTime lastPushDate = new DateTime();

        public override void PushTheButton()
        {
            base.PushTheButton();
            if ((DateTime.Now - this.lastPushDate) > TimeSpan.FromSeconds(1))
                Interlocked.Exchange(ref this.boom, 1);

            Interlocked.Increment(ref this.counter);

        }

        public override void Verify()
        {
            base.Verify();

            if (this.counter != 6)
                throw new Boom();
        }
    }
}
