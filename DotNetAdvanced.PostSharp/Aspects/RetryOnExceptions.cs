using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAdvanced.PostSharp.Aspects
{
    [PSerializable]
    public class RetryOnException : MethodInterceptionAspect
    {
        public RetryOnException()
        {
            this.MaxRetries = 3;
        }

        public int MaxRetries { get; set; }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            int retriesCounter = 0;

            while (true)
            {
                try
                {
                    args.Proceed();
                    return;
                }
                catch (Exception e)
                {
                    retriesCounter++;
                    if (retriesCounter > this.MaxRetries) throw;

                    Console.WriteLine(
                        "Exception during attempt {0} of calling method {1}.{2}: {3}",
                        retriesCounter, args.Method.DeclaringType, args.Method.Name, e.Message);
                }
            }
        }

        public override async Task OnInvokeAsync(MethodInterceptionArgs args)
        {
            int retriesCounter = 0;

            while (true)
            {
                try
                {
                    await args.ProceedAsync();
                    return;
                }
                catch (Exception e)
                {
                    retriesCounter++;
                    if (retriesCounter > this.MaxRetries) throw;

                    Console.WriteLine(
                        "Exception during attempt {0} of calling method {1}.{2}: {3}",
                        retriesCounter, args.Method.DeclaringType, args.Method.Name, e.Message);
                }
            }
        }
    }
}
