using MRWEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRWInterface
{
    public interface IReplyRepository : IRepository<Reply>
    {
        List<Reply> GetAllReplies(int movie_id, int review_id);
        Reply GetSpecificReply(int movie_id, int review_id, int reply_id);
        int UpdateSpecificReply(Reply reply, int movie_id, int review_id, int reply_id);
        int DeleteSpecificReply(Reply reply);
    }
}
