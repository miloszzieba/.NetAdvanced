using DotNetAdvanced.Autofac.Interfaces.BussinessLayer;
using DotNetAdvanced.Autofac.Interfaces.DAL;
using DotNetAdvanced.Autofac.Models;
using System;
using System.Collections.Generic;

namespace DotNetAdvanced.Autofac.BussinessLayer
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }


        public void Login(string login, string password)
        {
            var user = this._userRepository.GetUserByLogin(login);
            if (user.Password == password)
                return;
            throw new ApplicationException("User is not registered");
        }

        public User Register(User user)
        {
            this._userRepository.AddUser(user);
            return user;
        }
    }
}
