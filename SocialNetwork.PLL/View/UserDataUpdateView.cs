using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.View;

public class UserDataUpdateView
{
    UserService userService;
    public UserDataUpdateView(UserService userService)
    {
        this.userService = userService;
    }

    public void Show(User user)
    {
        Console.WriteLine("*** Редактирование профиля ***\n");
        Console.Write("Имя: ");
        user.FirstName = Console.ReadLine();

        Console.Write("Фамилия: ");
        user.LastName = Console.ReadLine();

        Console.Write("Ссылка на фото: ");
        user.Photo = Console.ReadLine();

        Console.Write("Любимый фильм: ");
        user.FavoriteMovie = Console.ReadLine();

        Console.Write("Любимая книга: ");
        user.FavoriteBook = Console.ReadLine();

        userService.Update(user);

        SuccessMessage.Show("Ваш профиль успешно обновлён!");
    }
}
