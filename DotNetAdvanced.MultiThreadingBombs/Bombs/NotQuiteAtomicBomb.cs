namespace DotNetAdvanced.MultiThreadingBombs.Bombs
{
    //Fix it first
    public class NotQuiteAtomicBomb : BaseBomb, IBomb
    {
        private int counter = 0;

        public override void PushTheButton()
        {
            base.PushTheButton();
            this.counter++;
        }

        public override void Verify()
        {
            base.Verify();

            if (this.counter != 10000)
                throw new Boom();
        }
    }
}
