using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Interfaces;
using SocialNetwork.DAL.Repositories;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.BLL.Services;

public class UserService
{
    MessageService _messageService;
    IUserRepository _userRepository;
    IFriendRepository _friendRepository;

    public UserService()
    {
        _messageService = new MessageService();
        _userRepository = new UserRepository();
        _friendRepository = new FriendRepository();
    }

    public MessageService MessageService => _messageService;

    public void Register(UserRegistrationData data)
    {
        if (String.IsNullOrEmpty(data.FirstName))
            throw new ArgumentNullException(nameof(data.FirstName));

        if (String.IsNullOrEmpty(data.LastName))
            throw new ArgumentNullException(nameof(data.LastName));

        if (String.IsNullOrEmpty(data.Password))
            throw new ArgumentNullException(nameof(data.Password));

        if (String.IsNullOrEmpty(data.Email))
            throw new ArgumentNullException(nameof(data.Email));

        if (data.Password.Length < 8)
            throw new ArgumentException(nameof(data.Password), "Invalid password length.");

        if (!new EmailAddressAttribute().IsValid(data.Email))
            throw new ArgumentException(nameof(data.Email), "Invalid Email.");

        if (_userRepository.FindByEmail(data.Email) != null)
            throw new ArgumentException(nameof(data.Email), "Email already used.");

        UserEntity user = new()
        {
            FirstName = data.FirstName,
            LastName = data.LastName,
            Password = data.Password,
            Email = data.Email
        };

        if (_userRepository.Create(user) == 0)
            throw new Exception();
    }

    public User FindByEmail(string email)
    {
        UserEntity? findUserEntity = _userRepository.FindByEmail(email);
        if (findUserEntity is null)
            throw new UserNotFoundException();

        return ConstructUserModel(findUserEntity);
    }

    public User FindById(int id)
    {
        UserEntity? findUserEntity = _userRepository.FindById(id);
        if (findUserEntity is null)
            throw new UserNotFoundException();

        return ConstructUserModel(findUserEntity);
    }

    public User Authenticate(UserAuthenticationData userAuthenticationData)
    {
        if (String.IsNullOrEmpty(userAuthenticationData.Email))
            throw new ArgumentException(nameof(UserAuthenticationData.Email));

        var findUserEntity = _userRepository.FindByEmail(userAuthenticationData.Email);
        if (findUserEntity is null) throw new UserNotFoundException();

        if (findUserEntity.Password != userAuthenticationData.Password)
            throw new WrongPasswordException();

        return ConstructUserModel(findUserEntity);
    }

    public void Update(User user)
    {
        UserEntity updatableUserEntity = new()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Password = user.Password,
            Email = user.Email,
            Photo = user.Photo,
            FavoriteMovie = user.FavoriteMovie,
            FavoriteBook = user.FavoriteBook
        };

        if (_userRepository.Update(updatableUserEntity) == 0)
            throw new Exception();
    }

    public void AddFriend(UserAddingFriendData userAddingFriendData)
    {
        if (String.IsNullOrEmpty(userAddingFriendData.FriendEmail))
            throw new ArgumentNullException(nameof(UserAddingFriendData.FriendEmail));

        UserEntity? friend = _userRepository.FindByEmail(userAddingFriendData.FriendEmail);

        if (friend is null)
            throw new UserNotFoundException();

        FriendEntity friendEntity = new()
        {
            UserId = userAddingFriendData.UserId,
            FriendId = friend.Id
        };

        if (_friendRepository.Create(friendEntity) == 0)
            throw new Exception();

    }

    public IEnumerable<User> GetFriendsByUserId(int userId)
    {
        return _friendRepository.FindAllByUserId(userId).Select(friendsEntity => FindById(friendsEntity.FriendId));
    }

    public void DeleteUser(User user)
    {
        _userRepository.DeleteById(user.Id);
    }

    private User ConstructUserModel(UserEntity userEntity)
    {
        return new User(userEntity.Id,
                      userEntity.FirstName,
                      userEntity.LastName,
                      userEntity.Password,
                      userEntity.Email,
                      userEntity.Photo,
                      _messageService.GetIncomingMessagesByUserId(userEntity.Id),
                      _messageService.GetOutcomingMessagesByUserId(userEntity.Id),
                      GetFriendsByUserId(userEntity.Id),
                      userEntity.FavoriteMovie,
                      userEntity.FavoriteBook);
    }
}
