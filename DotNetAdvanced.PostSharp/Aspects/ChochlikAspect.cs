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
    public class ChochlikAspect : OnMethodBoundaryAspect
    {
        public override void OnExit(MethodExecutionArgs args)
        {
            var random = new Random();
            var number = random.Next(0, 100);
            args.ReturnValue = new ArgumentNullException();
        }
    }
}
