using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Entities
{
    public class FriendEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FriendId { get; set; }
    }
}
