using System;
using System.Collections.Concurrent;
using System.Threading;

namespace DotNetAdvanced.MultiThreadingSynchronization
{
    public class SignallingPrimeGenerator
    {
        private readonly ConcurrentStack<int> _stack;
        private readonly CountdownEvent _countDownEvent;
        private readonly CancellationToken _token;

        public SignallingPrimeGenerator(ConcurrentStack<int> stack, CountdownEvent countDownEvent,
            CancellationToken token)
        {
            this._stack = stack;
            this._countDownEvent = countDownEvent;
            this._token = token;
        }

        public void GeneratePrimes(int start, int range)
        {
            var isPrime = true;
            var end = start + range;
            for (var i = start; i <= end; i++)
            {
                for (var j = 2; j < i; j++)
                {
                    if (_token.IsCancellationRequested)
                        return;
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    try
                    {
                        _countDownEvent.Signal();
                        _stack.Push(i);
                    } catch(InvalidOperationException ex)
                    {
                        return;
                    }
                }
                isPrime = true;
            }
        }
    }
}
