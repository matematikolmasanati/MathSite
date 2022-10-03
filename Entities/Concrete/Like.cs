using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Like
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public LikeType LikeType { get; set; }
    }

    public class LikeForDiscussion : Like
    {
        public int DiscussionId { get; set; }
    }
    public class LikeForAnswer : Like
    {
        public int AnswerId { get; set; }
    }

    public enum LikeType
    {
        Like = 1, Dislike = 0
    }
}
