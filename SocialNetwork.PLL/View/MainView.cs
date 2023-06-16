using SocialNetwork.BLL.Services;

namespace SocialNetwork.PLL.View;

public class MainView
{
    private RegistrationView _registrationView;
    private AuthenticationView _authenticationView;
    private UserService _userService;

    public MainView(UserService userService)
    {
        _userService = userService;

        _registrationView = new RegistrationView(_userService);
        _authenticationView = new AuthenticationView(_userService);
    }

    public void Show()
    {
        Console.WriteLine("*** Главное меню ***");
        Console.WriteLine("1 - Войти в профиль");
        Console.WriteLine("2 - Зарегистрироваться");
        Console.Write("\n> ");

        switch (Console.ReadLine())
        {
            case "1":
                {
                    _authenticationView.Show();
                    break;
                }

            case "2":
                {
                    _registrationView.Show();
                    break;
                }
        }
    }
}
