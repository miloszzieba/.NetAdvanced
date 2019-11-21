using Autofac;
using DotNetAdvanced.Autofac.BussinessLayer;
using DotNetAdvanced.Autofac.DAL;
using DotNetAdvanced.Autofac.Interfaces.BussinessLayer;
using DotNetAdvanced.Autofac.Interfaces.DAL;
using DotNetAdvanced.Autofac.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAdvanced.Autofac
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            //Same as above, but with injecting registered interface
            //builder.Register(c => new UserService(c.Resolve<IUserRepository>()))
            //    .As<IUserService>();

            // Scan an assembly for components
            var myAssembly = Assembly.GetEntryAssembly();
            builder.RegisterAssemblyTypes(myAssembly)
                   .Where(t => t.Namespace.StartsWith("DotNetAdvanced"))
                   .AsImplementedInterfaces();

            //When we are passing not registered arguments
            //Resolved, when IUserRepository is injected
            builder.Register(c => new UserRepository("127.0.0.1")).As<IUserRepository>();

            //It has to be registered explicitly, 
            //because there's AsImplementedInterfaces above
            builder.RegisterType<UserController>();

            var container = builder.Build();

            var userController = container.Resolve<UserController>();
            userController.Register("Miłosz", "Miłosz", "SuperTajneHasło", 10);
            userController.Login("Miłosz", "SuperTajneHasło");
        }
    }
}
