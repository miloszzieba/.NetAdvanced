using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAdvanced.PLinq
{
    public static class StandardDeviation
    {
        public static double Calculate(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException("array");

            if (array.Length == 0)
                return 0;

            var mean = array.AsParallel().Average();

            var standardDev = array.AsParallel()
                .WithDegreeOfParallelism(5)
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                .Aggregate(
                 0.0,
                 // do this on each thread
                 (subtotal, item) => subtotal + Math.Pow((item - mean), 2),
                 //Unique for Parallel.Aggregate
                 // aggregate results after all threads are done.
                 (total, thisThread) => total + thisThread,

                // perform standard deviation calc on the aggregated result.
                (finalSum) => Math.Sqrt((finalSum / (array.Length - 1)))
            );

            return standardDev;
        }
    }
}
