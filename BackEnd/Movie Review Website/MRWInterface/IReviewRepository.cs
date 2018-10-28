using MRWEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRWInterface
{
    public interface IReviewRepository : IRepository<Review>
    {
        List<Review> GetAllReview(int movie_id);
        Review GetSpecificReview(int movie_id, int review_id);
        int UpdateSpecificReview(Review review, int movie_id, int review_id);
        int DeleteSpecificReview(Review review);
    }
}
