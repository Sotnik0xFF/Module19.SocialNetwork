using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.View;

public class RegistrationView
{
    UserService userService;

    public RegistrationView(UserService userService)
    {
        this.userService = userService;
    }

    public void Show()
    {
        UserRegistrationData userRegistrationData = new();

        Console.WriteLine("*** Создание нового профиля ***\n");

        Console.Write("Имя: ");
        userRegistrationData.FirstName = Console.ReadLine();

        Console.Write("Фамилия: ");
        userRegistrationData.LastName = Console.ReadLine();

        Console.Write("Пароль: ");
        userRegistrationData.Password = Console.ReadLine();

        Console.Write("Почтовый адрес: ");
        userRegistrationData.Email = Console.ReadLine();

        try
        {
            userService.Register(userRegistrationData);

            SuccessMessage.Show("Профиль успешно создан. Теперь Вы можете войти в систему под своими учетными данными.\n");
        }

        catch (Exception e)
        {
            AlertMessage.Show($"Произошла ошибка при регистрации. {e.Message}");
        }
    }
}
