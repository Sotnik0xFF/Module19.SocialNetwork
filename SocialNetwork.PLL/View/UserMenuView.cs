using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Viewж;

namespace SocialNetwork.PLL.View;

public class UserMenuView
{
    private UserService _userService;
    private UserInfoView _userInfoView;
    private UserDataUpdateView _userDataUpdateView;
    private MessageSendingView _messageSendingView;
    private UserIncomingMessageView _userIncomingMessageView;
    private UserOutcomingMessageView _userOutcomingMessageView;

    public UserMenuView(UserService userService)
    {
        _userService = userService;

        _userInfoView = new();
        _userDataUpdateView = new(_userService);
        _messageSendingView = new(_userService);
        _userIncomingMessageView = new();
        _userOutcomingMessageView = new();
    }

    public void Show(User user)
    {
        while (true)
        {
            user = _userService.FindById(user.Id);
            Console.WriteLine("\n*** Меню пользователя ***\n");
            Console.WriteLine("Входящие сообщения: {0}", user.IncomingMessages.Count());
            Console.WriteLine("Исходящие сообщения: {0}", user.OutgoingMessages.Count());
            Console.WriteLine("Друзья: {0}", user.Friends.Count());

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
                        _userInfoView.Show(user);
                        break;
                    }
                case "2":
                    {
                        _userDataUpdateView.Show(user);
                        break;
                    }

                case "3":
                    {
                        //Program.addingFriendView.Show(user);
                        break;
                    }

                case "4":
                    {
                        _messageSendingView.Show(user);
                        break;
                    }

                case "5":
                    {
                        _userIncomingMessageView.Show(user.IncomingMessages);
                        break;
                    }

                case "6":
                    {
                        _userOutcomingMessageView.Show(user.OutgoingMessages);
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
