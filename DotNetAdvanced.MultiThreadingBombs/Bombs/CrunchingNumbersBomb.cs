using System;
using System.Collections.Generic;
using System.Threading;

namespace DotNetAdvanced.MultiThreadingBombs.Bombs
{
    public class CrunchingNumbersBomb : BaseBomb
    {
        private int counter = 0;

        public IEnumerable<int> PushTheButton(Random random)
        {
            base.PushTheButton();
            Interlocked.Increment(ref this.counter);

            for (var i = 0; i < 10; i++)
                yield return random.Next(0, 1000);
        }

        public void Verify(List<int> list)
        {
            base.Verify();

            if (this.counter != 6 || list.Count != 60)
                throw new Boom();
        }
    }
}
