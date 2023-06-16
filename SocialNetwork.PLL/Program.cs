using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.View;

namespace SocialNetwork.PLL;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        UserService userService = new UserService();

        MainView mainView = new MainView(userService);

        Console.WriteLine("Добро пожаловать в SocialNetwork!\n");
        while (true)
        {
            mainView.Show();
        }
    }
}