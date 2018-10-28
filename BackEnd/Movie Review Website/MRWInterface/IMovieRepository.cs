using MRWEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRWInterface
{
    public interface IMovieRepository : IRepository<Movie>
    {
        List<Movie> SearchByName(string movie_name);
        List<Movie> SearchByCategory(string category_name);
    }
}
