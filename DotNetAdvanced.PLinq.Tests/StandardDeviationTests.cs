using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DotNetAdvanced.PLinq.Tests
{
    public class StandardDeviationTests
    {
        [Fact]
        public void SuccesfulCalculateTest()
        {
            var array = new int[] { 1, 2, 3, 4, 5 };

            var result = StandardDeviation.Calculate(array);

            result.Should().BeApproximately(1.41, 0.005);
        }

        [Fact]
        public void EmptyArrayCalculateTest()
        {
            var array = new int[0];

            var result = StandardDeviation.Calculate(array);

            result.Should().Be(0);
        }

        [Fact]
        public void NullArrayCalculateTest()
        {
            int[] array = null;

            Assert.Throws<ArgumentNullException>(() => StandardDeviation.Calculate(array));
        }

        [Fact]
        public void SuccesfulZeroCalculateTest()
        {
            var array = new int[] { 0, 0, 0, 0, 0 };

            var result = StandardDeviation.Calculate(array);

            result.Should().Be(0);
        }

        [Fact]
        public void SuccesfulMaxValueCalculateTest()
        {
            var array = new int[] { int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MinValue, int.MinValue, int.MinValue, int.MinValue, int.MinValue };

            Action action = new Action(() =>
            {
                StandardDeviation.Calculate(array);
            });

            action.Should().NotThrow();


        }
    }
}
