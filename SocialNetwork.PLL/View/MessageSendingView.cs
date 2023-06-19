using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.View;

public class MessageSendingView
{
    UserService _userService;
    MessageService _messageService;

    public MessageSendingView(UserService userService)
    {
        _messageService = userService.MessageService;
        _userService = userService;
    }

    public void Show(User user)
    {
        MessageSendingData messageSendingData = new();

        Console.Write("Почтовый адрес получателя: ");
        messageSendingData.RecipientEmail = Console.ReadLine();

        Console.WriteLine("Введите сообщение (не больше 5000 символов): ");
        messageSendingData.Content = Console.ReadLine();
        messageSendingData.SenderId = user.Id;

        try
        {
            _messageService.SendMessage(messageSendingData);
            SuccessMessage.Show("Сообщение успешно отправлено!");
        }
        catch (UserNotFoundException)
        {
            AlertMessage.Show("Пользователь не найден!");
        }
        catch (ArgumentNullException)
        {
            AlertMessage.Show("Введите корректное значение!");
        }
        catch (Exception)
        {
            AlertMessage.Show("Произошла ошибка при отправке сообщения!");
        }

    }
}
