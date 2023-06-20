using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories
{
    public class MessageRepository : BaseRepository, IMessageRepository
    {
        private const string MessageColumns = $@"
            id as {nameof(MessageEntity.Id)},
            content as {nameof(MessageEntity.Content)},
            sender_id as {nameof(MessageEntity.SenderId)},
            recipient_id as {nameof(MessageEntity.RecipientId)}";

        public int Create(MessageEntity messageEntity)
        {
            string sql = $@"
                INSERT INTO messages (content, sender_id, recipient_id)
                VALUES (
                    @{nameof(MessageEntity.Content)},
                    @{nameof(MessageEntity.SenderId)},
                    @{nameof(MessageEntity.RecipientId)})";

            return Execute(sql, messageEntity);
        }

        public int DeleteById(int messageId)
        {
            string sql = $@"
                DELETE FROM messages
                WHERE id = @MessageId";

            return Execute(sql, new { MessageId = messageId });
        }

        public IEnumerable<MessageEntity> FindByRecipientId(int recipientId)
        {
            string sql = $@"
                SELECT {MessageColumns}
                FROM messages
                WHERE recipient_id = @MessageRecipientId";

            return Query<MessageEntity>(sql, new { MessageRecipientId = recipientId });
        }

        public IEnumerable<MessageEntity> FindBySenderId(int senderId)
        {
            string sql = $@"
                SELECT {MessageColumns}
                FROM messages
                WHERE sender_id = @MessageSenderId";

            return Query<MessageEntity>(sql, new { MessageSenderId = senderId });
        }
    }
}
