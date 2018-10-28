using MRWEntity;
using MRWInterface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRWRepository
{
    public class ReplyRepository : Repository<Reply>, IReplyRepository
    {
        public List<Reply> GetAllReplies(int movie_id, int review_id)
        {
            return this.Context.Replies.Where(m => m.MovieId == movie_id && m.Review_Id == review_id).ToList();
        }

        public Reply GetSpecificReply(int movie_id, int review_id, int reply_id)
        {
            return this.Context.Replies.SingleOrDefault(m => m.MovieId == movie_id && m.Review_Id == review_id && m.Id == reply_id);
        }

        public int UpdateSpecificReply(Reply reply, int movie_id, int review_id, int reply_id)
        {
            this.Context.Entry(reply).State = EntityState.Modified;
            return this.Context.SaveChanges();
        }

        public int DeleteSpecificReply(Reply reply)
        {
            if(reply != null)
            {
                this.Context.Replies.Remove(reply);
                return this.Context.SaveChanges();
            }
            else
            {
                return 0;
            }
        }
    }
}
