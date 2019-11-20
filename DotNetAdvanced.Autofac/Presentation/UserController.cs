using DotNetAdvanced.Autofac.Interfaces.BussinessLayer;
using DotNetAdvanced.Autofac.Models;
using System;

namespace DotNetAdvanced.Autofac.Presentation
{
    public class UserController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public void Login(string user, string password)
        {
            try
            {
                this.userService.Login(user, password);
                Console.WriteLine("User successfully logged in");
            }
            catch (Exception ex)
            {
                Console.WriteLine("User failed to log in");
            }
        }

        public void Register(string name, string login, string password, int age)
        {
            try
            {
                this.userService.Register(new User()
                {
                    Name = name,
                    Login = login,
                    Password = password,
                    Age = age
                });
                Console.WriteLine("User successfully registered");
            }
            catch (Exception ex)
            {
                Console.WriteLine("User failed to register");
            }
        }
    }
}
