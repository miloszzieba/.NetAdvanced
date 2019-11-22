using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAdvanced.PostSharp.Aspects
{
    public class LogMethodAspectProvider : IAspectProvider
    {
        readonly LogMethodAttribute aspectToApply = new LogMethodAttribute();

        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            Assembly assembly = (Assembly)targetElement;

            List<AspectInstance> instances = new List<AspectInstance>();
            foreach (Type type in assembly.GetTypes())
            {
                ProcessType(type, instances);
            }

            return instances;
        }

        private void ProcessType(Type type, List<AspectInstance> instances)
        {
            foreach (MethodInfo targetMethod in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly))
            {
                instances.Add(new AspectInstance(targetMethod, aspectToApply));
            }

            foreach (Type nestedType in type.GetNestedTypes())
            {
                ProcessType(nestedType, instances);
            }
        }
    }
}
