using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.View;

public class AddingFriendView
{
    private UserService _userService;

    public AddingFriendView(UserService userService)
    {
        this._userService = userService;
    }
    public void Show(User user)
    {
        try
        {
            UserAddingFriendData userAddingFriendData = new();

            Console.WriteLine("Введите почтовый адрес пользователя которого хотите добавить в друзья: ");

            userAddingFriendData.FriendEmail = Console.ReadLine();
            userAddingFriendData.UserId = user.Id;

            _userService.AddFriend(userAddingFriendData);

            SuccessMessage.Show("Вы успешно добавили пользователя в друзья!");
        }

        catch (UserNotFoundException)
        {
            AlertMessage.Show("Пользователя с указанным почтовым адресом не существует!");
        }

        catch (Exception)
        {
            AlertMessage.Show("Произоша ошибка при добавлении пользотваеля в друзья!");
        }

    }
}
