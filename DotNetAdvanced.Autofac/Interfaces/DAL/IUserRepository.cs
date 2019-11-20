using DotNetAdvanced.Autofac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAdvanced.Autofac.Interfaces.DAL
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUserByName(string name);
        User GetUserByLogin(string login);
    }
}
