using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.BLL.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        [Test]
        public void Register_MustAddUser()
        {
            UserService userService = new();
            UserRegistrationData registrationData = new()
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "test@mail.ru",
                Password = "12345678",
            };

            userService.Register(registrationData);
            User user = userService.FindByEmail(registrationData.Email);
            userService.DeleteUser(user);
            Assert.IsNotNull(user);
        }

        [Test]
        public void Register_ThrowsException_IfInvalidEmail()
        {
            UserService userService = new();
            UserRegistrationData registrationData = new()
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "",
                Password = "12345678",
            };
            Assert.Throws<ArgumentNullException>(() => userService.Register(registrationData));
        }

        [Test]
        public void AddFriend_MustAddUserToFriends()
        {
            UserService userService = new();

            UserRegistrationData registrationData1 = new()
            {
                FirstName = "User1",
                LastName = "User1",
                Email = "user1@mail.ru",
                Password = "12345678",
            };
            UserRegistrationData registrationData2 = new()
            {
                FirstName = "User2",
                LastName = "User2",
                Email = "user2@mail.ru",
                Password = "12345678",
            };

            userService.Register(registrationData1);
            userService.Register(registrationData2);

            User user1 = userService.FindByEmail(registrationData1.Email);
            User user2 = userService.FindByEmail(registrationData2.Email);

            UserAddingFriendData userAddingFriendData = new() { UserId = user1.Id, FriendEmail = "user2@mail.ru"  };
            userService.AddFriend(userAddingFriendData);

            int friendCount = userService.GetFriendsByUserId(user1.Id).Count();

            userService.DeleteUser(user1);
            userService.DeleteUser(user2);

            Assert.True(friendCount == 1);
        }
    }
}