using DotNetAdvanced.Autofac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAdvanced.Autofac.Interfaces.BussinessLayer
{
    public interface IUserService
    {
        void Login(string username, string password);
        User Register(User user);
    }
}
