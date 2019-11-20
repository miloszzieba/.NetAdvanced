using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace DotNetAdvanced.MultiThreading
{
    public class PrimeGenerator
    {
        private readonly List<int> _list;

        public PrimeGenerator(List<int> list)
        {
            this._list = list;
        }

        public void GeneratePrimes(int start, int range)
        {
            var isPrime = true;
            var end = start + range;
            for (var i = start; i <= end; i++)
            {
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
                    _list.Add(i);
                }
                isPrime = true;
            }
        }
    }
}
