using DotNetAdvanced.PLinq;
using DotNetAdvanced.PostSharp.Aspects;
using System;
using System.Reflection;
using System.Threading;

namespace DotNetAdvanced.PostSharp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            for (var i = 0; i < 1000; i++)
            {
                var x = TestMethod("TEST");
                x++;
            }
            Console.ReadLine();
        }

        [LogMethodInfoAspect]
        private static int TestMethod(string testString)
        {
            return 5;
        }
    }
}
