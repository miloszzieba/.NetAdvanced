﻿using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAdvanced.PostSharp.Aspects.Helpers
{
    internal static class Formatter
    {
        public static void AppendTypeName(StringBuilder stringBuilder, Type declaringType)
        {
            stringBuilder.Append(declaringType.FullName);
            if (declaringType.IsGenericType)
            {
                var genericArguments = declaringType.GetGenericArguments();
                AppendGenericArguments(stringBuilder, genericArguments);
            }
        }

        public static void AppendGenericArguments(StringBuilder stringBuilder, Type[] genericArguments)
        {
            stringBuilder.Append('<');
            for (var i = 0; i < genericArguments.Length; i++)
            {
                if (i > 0)
                    stringBuilder.Append(", ");

                stringBuilder.Append(genericArguments[i].Name);
            }
            stringBuilder.Append('>');
        }

        public static void AppendArguments(StringBuilder stringBuilder, Arguments arguments)
        {
            stringBuilder.Append('(');
            for (var i = 0; i < arguments.Count; i++)
            {
                if (i > 0)
                    stringBuilder.Append(", ");

                stringBuilder.Append(arguments[i]);
            }
            stringBuilder.Append(')');
        }
    }
}
