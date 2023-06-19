using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories
{
    public class FriendRepository : BaseRepository, IFriendRepository
    {
        private const string FriendColumns = $@"
            id as {nameof(FriendEntity.Id)},
            user_id as {nameof(FriendEntity.UserId)},
            friend_id as {nameof(FriendEntity.FriendId)}";

        public int Create(FriendEntity friendEntity)
        {
            string sql = $@"
                INSERT INTO friends (user_id, friend_id)
                VALUES (
                    @{nameof(FriendEntity.UserId)},
                    @{nameof(FriendEntity.FriendId)})";

            return Execute(sql, friendEntity);
        }

        public int Delete(int id)
        {
            string sql = $@"
                DELETE FROM friends
                WHERE id = @FriendEntryId";

            return Execute(sql, new { FriendEntryId = id });
        }

        public IEnumerable<FriendEntity> FindAllByUserId(int userId)
        {
            string sql = $@"
                SELECT {FriendColumns}
                FROM friends
                WHERE user_id = @FriendEntryUserId";

            return Query<FriendEntity>(sql, new { FriendEntryUserId = userId});
        }
    }
}
