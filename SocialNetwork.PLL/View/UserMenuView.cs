using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.PLL.View;

public class UserMenuView
{
    UserService _userService;
    public UserMenuView(UserService userService)
    {
        _userService = userService;
    }

    public void Show(User user)
    {
        while (true)
        {
            //Console.WriteLine("Входящие сообщения: {0}", user.IncomingMessages.Count());
            //Console.WriteLine("Исходящие сообщения: {0}", user.OutgoingMessages.Count());
            //Console.WriteLine("Мои друзья: {0}", user.Friends.Count());

            Console.WriteLine("1 - Просмотреть информацию о профиле");
            Console.WriteLine("2 - Редактировать профиль");
            Console.WriteLine("3 - Добавить в друзья");
            Console.WriteLine("4 - Написать сообщение");
            Console.WriteLine("5 - Просмотреть входящие сообщения");
            Console.WriteLine("6 - Просмотреть исходящие сообщения");
            Console.WriteLine("7 - Просмотреть моих друзей");
            Console.WriteLine("8 - Выйти из профиля");
            Console.Write("\n> ");

            string? keyValue = Console.ReadLine();

            if (keyValue == "8") break;

            switch (keyValue)
            {
                case "1":
                    {
                        //Program.userInfoView.Show(user);
                        break;
                    }
                case "2":
                    {
                        //Program.userDataUpdateView.Show(user);
                        //user = _userService.FindById(user.Id);
                        break;
                    }

                case "3":
                    {
                        //Program.addingFriendView.Show(user);
                        //user = _userService.FindById(user.Id);
                        break;
                    }

                case "4":
                    {
                        //Program.messageSendingView.Show(user);
                        //user = userService.FindById(user.Id);
                        break;
                    }

                case "5":
                    {

                        //Program.userIncomingMessageView.Show(user.IncomingMessages);
                        break;
                    }

                case "6":
                    {
                        //Program.userOutcomingMessageView.Show(user.OutgoingMessages);
                        break;
                    }

                case "7":
                    {
                        //Program.userFriendView.Show(user.Friends);
                        break;
                    }
            }
        }
    }
}
