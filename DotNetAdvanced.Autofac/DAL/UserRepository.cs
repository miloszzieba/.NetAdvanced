using DotNetAdvanced.Autofac.Interfaces.DAL;
using DotNetAdvanced.Autofac.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetAdvanced.Autofac.DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> database = new List<User>();

        public void AddUser(User user)
        {
            this.database.Add(user);
        }

        public User GetUserByLogin(string login)
        {
            return this.database.FirstOrDefault(x => x.Login == login);
        }

        public User GetUserByName(string name)
        {
            return this.database.FirstOrDefault(x => x.Name == name);
        }
    }
}
