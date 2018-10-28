using MRWEntity;
using MRWInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRWRepository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public List<Movie> SearchByName(string movie_name)
        {
            return this.Context.Movies.Where(m => m.Name == movie_name).ToList();
        }

        public List<Movie> SearchByCategory(string category_name)
        {
            return this.Context.Movies.Where(m => m.CategoryName.Contains(category_name)).ToList();
        }
    }
}
