using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Interfaces;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.BLL.Services;

public class MessageService
{
    private IMessageRepository _messageRepository;
    private IUserRepository _userRepository;

    public MessageService()
    {
        _userRepository = new UserRepository();
        _messageRepository = new MessageRepository();
    }

    public IEnumerable<Message> GetIncomingMessagesByUserId(int recipientId)
    {
        var messages = new List<Message>();

        _messageRepository.FindByRecipientId(recipientId).ToList().ForEach(m =>
        {
            var senderUserEntity = _userRepository.FindById(m.SenderId);
            var recipientUserEntity = _userRepository.FindById(m.RecipientId);

            if (senderUserEntity is null || recipientUserEntity is null)
                throw new Exception();

            messages.Add(new Message(m.Id, m.Content, senderUserEntity.Email, recipientUserEntity.Email));
        });

        return messages;
    }

    public IEnumerable<Message> GetOutcomingMessagesByUserId(int senderId)
    {
        var messages = new List<Message>();

        _messageRepository.FindBySenderId(senderId).ToList().ForEach(m =>
        {
            UserEntity? senderUserEntity = _userRepository.FindById(m.SenderId);
            UserEntity? recipientUserEntity = _userRepository.FindById(m.RecipientId);

            if (senderUserEntity is null || recipientUserEntity is null)
                throw new Exception();

            messages.Add(new Message(m.Id, m.Content, senderUserEntity.Email, recipientUserEntity.Email));
        });

        return messages;
    }

    public void SendMessage(MessageSendingData messageSendingData)
    {
        if (String.IsNullOrEmpty(messageSendingData.RecipientEmail))
            throw new ArgumentNullException(nameof(MessageSendingData.RecipientEmail));

        if (String.IsNullOrEmpty(messageSendingData.Content))
            throw new ArgumentNullException(nameof(MessageSendingData.Content));

        if (messageSendingData.Content.Length > 5000)
            throw new ArgumentOutOfRangeException();

        UserEntity? findUserEntity = _userRepository.FindByEmail(messageSendingData.RecipientEmail);
        if (findUserEntity is null) throw new UserNotFoundException();

        var messageEntity = new MessageEntity()
        {
            Content = messageSendingData.Content,
            SenderId = messageSendingData.SenderId,
            RecipientId = findUserEntity.Id
        };

        if (_messageRepository.Create(messageEntity) == 0)
            throw new Exception();
    }
}
