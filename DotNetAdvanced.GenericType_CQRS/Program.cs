using Autofac;
using DotNetAdvanced.GenericType_CQRS.Commands;
using DotNetAdvanced.GenericType_CQRS.Interfaces;
using DotNetAdvanced.GenericType_CQRS.Models;
using DotNetAdvanced.GenericType_CQRS.Queries;
using System.Linq;
using System.Reflection;

namespace DotNetAdvanced.GenericType_CQRS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            var myAssembly = Assembly.GetEntryAssembly();
            builder.RegisterAssemblyTypes(myAssembly)
                   .Where(t => t.Namespace.StartsWith("DotNetAdvanced"))
                   .AsImplementedInterfaces();

            var container = builder.Build();

            //Using Resolve in code is generally considered bad practice
            //We want to pass dependencies by constructor (not possible in Program.cs)
            var dispatcher = container.Resolve<IDispatcher>();


            //Dispatcher can be used across whole project to execute commands and queries
            //without knowing their implementation.
            //We're just passing our intention.
            var newEntity = new MyEntity() { Name = "Example Entity" };
            var command = new AddMyEntityCommand(newEntity);
            dispatcher.Handle(command);

            var query = new GetMyEntityByIdQuery(1);
            var myEntity = dispatcher.Get<GetMyEntityByIdQuery, MyEntity>(query);
        }
    }
}
