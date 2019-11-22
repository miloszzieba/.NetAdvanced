using DotNetAdvanced.PostSharp.Aspects;
using PostSharp.Extensibility;

#if DEBUG
[assembly: ChochlikAspect(AttributePriority = 1)]
#endif