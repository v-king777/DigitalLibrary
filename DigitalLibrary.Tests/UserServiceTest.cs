using NUnit.Framework;
using System;

namespace DigitalLibrary.Tests
{
    [TestFixture]
    public class UserServiceTest
    {
        [Test]
        public void DeleteUserMustThrowUserNotFoundException()
        {
            var userData = new UserData();
            var userService = new UserService();

            Assert.Throws<UserNotFoundException>(() => userService.DeleteUser(userData));
        }
    }
}
