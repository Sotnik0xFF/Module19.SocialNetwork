using SocialNetwork.BLL.Models;

namespace SocialNetwork.PLL.Viewж
{
    public class UserInfoView
    {
        public void Show(User user)
        {
            Console.WriteLine("\n*** Информация о профиле ***");
            Console.WriteLine("ID: {0}", user.Id);
            Console.WriteLine("Имя: {0}", user.FirstName);
            Console.WriteLine("Фамилия: {0}", user.LastName);
            Console.WriteLine("Пароль: {0}", user.Password);
            Console.WriteLine("Почтовый адрес: {0}", user.Email);
            Console.WriteLine("Ссылка на фото: {0}", user.Photo);
            Console.WriteLine("Любимый фильм: {0}", user.FavoriteMovie);
            Console.WriteLine("Любимая книга: {0}", user.FavoriteBook);
        }
    }
}
