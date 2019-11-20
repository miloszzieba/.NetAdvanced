using System.Collections.Concurrent;
using System.Threading;

namespace DotNetAdvanced.MultiThreadingSynchronization
{
    public class SignallingPrimeGenerator
    {
        private readonly ConcurrentBag<int> bag;
        private readonly CountdownEvent countDownEvent;
        private readonly CancellationToken token;

        public SignallingPrimeGenerator(ConcurrentBag<int> bag, CountdownEvent countDownEvent,
            CancellationToken token)
        {
            this.bag = bag;
            this.countDownEvent = countDownEvent;
            this.token = token;
        }


        //Wykorzystać poprzedni kod dotyczący liczb pierwszych.
        //Dodać do niego mechanizm, który po wyprodukowaniu 1000 liczb pierwszych
        //powiadomi główny wątek o tym

        //W momencie, kiedy główny wątek otrzyma informację powinien
        //wywołać cancellationTokenSource.Cancel, który zatrzyma produkcję liczb pierwszych
        public void GeneratePrimes(int start, int range)
        {
            var isPrime = true;
            var end = start + range;
            for (var i = start; i <= end; i++)
            {
                if (token.IsCancellationRequested)
                    break;
                for (var j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    if (token.IsCancellationRequested)
                        break;
                    {
                        countDownEvent.Signal();
                        bag.Add(i);
                    }
                }
                isPrime = true;
            }
        }
    }
}
