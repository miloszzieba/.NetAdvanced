using DotNetAdvanced.Autofac.BussinessLayer;
using DotNetAdvanced.Autofac.Interfaces.DAL;
using DotNetAdvanced.Autofac.Models;
using DotNetAdvanced.Autofac.Tests.Mocks;
using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace DotNetAdvanced.Autofac.Tests
{
    public class UserServiceTests
    {
        public UserServiceTests()
        {
        }

        [Fact]
        public void NoUserLoginTest()
        {
            //Arrange
            var login = "NoUser";
            var password = "SuperHasło";
            var testUserRepository = new TestUserRepository();
            var userService = new UserService(testUserRepository);

            //Act
            var action = () => userService.Login(login, password);

            //Assert
            Assert.Throws<ApplicationException>(action);
        }


        [Fact]
        public void SuccesfulLoginTest()
        {
            //Arrange
            var login = "Succesful";
            var password = "SuperHasło";
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.GetUserByLogin("Succesful"))
                .Returns(new User()
                {
                    Login = "Succesful",
                    Password = "SuperHasło"
                });
            var userService = new UserService(userRepositoryMock.Object);

            //Act
            try
            {
                userService.Login(login, password);
            }
            //Assert
            catch (Exception ex)
            {
                Assert.True(false);
            }

            Assert.True(true);
        }

        [Fact]
        public void WrongPasswordLoginTest()
        {
            //Arrange
            var login = "Succesful";
            var password = "Super";
            var testUserRepository = new TestUserRepository();
            var userService = new UserService(testUserRepository);

            //Act
            Assert.Throws<ApplicationException>(
                () => userService.Login(login, password));
        }

        [Fact]
        public void RegisterTest()
        {
            //ARRANGE
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);
            var expectedUSer = new User();

            //ACT
            var user = userService.Register(expectedUSer);
            userService.Invoking((x) => x.Register(expectedUSer))
                .Should().Throw<ApplicationException>();

            //ASSERT
            userRepositoryMock.Verify(x => x.AddUser(It.IsAny<User>()));

            user.Should().Be(expectedUSer)
                .And.NotBeNull();
            user.Name.Should().NotBeNullOrWhiteSpace();
            user.Age.Should().Be(10);

        }
    }
}
