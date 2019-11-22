using NLog;
using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAdvanced.PostSharp.Aspects
{
    [PSerializable]
    public class LogMethodInfoAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Info($"The {args.Method.Name} method has been entered.");
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            Console.WriteLine("The {0} method executed successfully.", args.Method.Name);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            args.ReturnValue = 1;
            Console.WriteLine("The {0} method has exited.", args.Method.Name);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            var ourException = args.Exception;
            Console.WriteLine("An exception was thrown in {0}.", args.Method.Name);
            args.Exception = new ApplicationException("Server error. Please consult with admin");
        }

    }
}
