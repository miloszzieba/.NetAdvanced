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
    public sealed class ExceptionHandlingAspect : OnExceptionAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
            args.FlowBehavior = FlowBehavior.ThrowException;
            args.Exception = new ApplicationException("Server error", args.Exception);
        }
    }
}
