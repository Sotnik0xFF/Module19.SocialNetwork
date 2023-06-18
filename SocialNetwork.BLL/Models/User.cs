namespace SocialNetwork.BLL.Models;

public class User
{
    public int Id { get; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? Photo { get; set; }
    public string? FavoriteMovie { get; set; }
    public string? FavoriteBook { get; set; }
    public IEnumerable<Message> IncomingMessages { get; }
    public IEnumerable<Message> OutgoingMessages { get; }
    public IEnumerable<User> Friends { get; }


    public User(
        int id,
        string? firstName,
        string? lastName,
        string? password,
        string? email,
        string? photo,
        IEnumerable<Message> incomingMessages,
        IEnumerable<Message> outgoingMessages,
        IEnumerable<User> friends,
        string? favoriteMovie,
        string? favoriteBook)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Password = password;
        Email = email;
        Photo = photo;
        IncomingMessages = incomingMessages;
        OutgoingMessages = outgoingMessages;
        Friends = friends;
        FavoriteMovie = favoriteMovie;
        FavoriteBook = favoriteBook;
    }
}
