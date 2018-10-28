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
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public List<Review> GetAllReview(int movie_id)
        {
            return this.Context.Reviews.Where(m => m.MovieId == movie_id).ToList();
        }

        public Review GetSpecificReview(int movie_id, int review_id)
        {
            return this.Context.Reviews.SingleOrDefault(m => m.MovieId == movie_id && m.Id == review_id);
        }

        public int UpdateSpecificReview(Review review, int movie_id, int review_id)
        {
            this.Context.Entry(review).State = EntityState.Modified;
            return this.Context.SaveChanges();
        }

        public int DeleteSpecificReview(Review review)
        {
            if(review != null)
            {
                //Deleting replies

                var replyList = this.Context.Replies.Where(replies => replies.Review_Id == review.Id);

                if(replyList != null)
                {
                    foreach(Reply reply in replyList)
                    {
                        this.Context.Replies.Remove(reply);
                    }

                    this.Context.SaveChanges();
                }

                //Deleting review
                this.Context.Reviews.Remove(review);
                return this.Context.SaveChanges();
            }
            else
            {
                return 0;
            }
        }
    }
}
