using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace DotNetAdvanced.MultiThreading
{
    public class PrimeGenerator
    {
        private readonly ConcurrentStack<int> _stack;
        private readonly CancellationToken _token;

        public PrimeGenerator(ConcurrentStack<int> stack, CancellationToken token)
        {
            this._stack = stack;
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
                    _stack.Push(i);
                }
                isPrime = true;
            }
        }
    }
}
