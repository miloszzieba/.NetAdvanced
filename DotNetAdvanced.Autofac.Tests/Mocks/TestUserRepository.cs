using DotNetAdvanced.Autofac.Interfaces.DAL;
using DotNetAdvanced.Autofac.Models;

namespace DotNetAdvanced.Autofac.Tests.Mocks
{
    public class TestUserRepository : IUserRepository
    {
        public void AddUser(User user)
        {
        }

        public User GetUserByLogin(string login)
        {
            if (login == "Succesful")
                return new User()
                {
                    Login = "Succesful",
                    Password = "SuperHasło"
                };
            else
                return null;
        }

        public User GetUserByName(string name)
        {
            return new User()
            {
                Name = "Miłosz"
            };
        }
    }
}
