using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.View;

public class AuthenticationView
{
    private UserService _userService;
    private UserMenuView _userMenuView;

    public AuthenticationView(UserService userService)
    {
        _userService = userService;
        _userMenuView = new UserMenuView(_userService);
    }

    public void Show()
    {
        var authenticationData = new UserAuthenticationData();

        Console.Write("Почтовый адрес: ");
        authenticationData.Email = Console.ReadLine();

        Console.Write("Пароль: ");
        authenticationData.Password = Console.ReadLine();

        try
        {
            User user = _userService.Authenticate(authenticationData);

            SuccessMessage.Show("Вы успешно вошли в социальную сеть!");
            SuccessMessage.Show("Добро пожаловать, " + user.FirstName);

            _userMenuView.Show(user);
        }

        catch (WrongPasswordException)
        {
            AlertMessage.Show("Пароль не корректный!");
        }

        catch (UserNotFoundException)
        {
            AlertMessage.Show("Пользователь не найден!");
        }

    }
}
