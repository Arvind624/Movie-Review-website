using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRWEntity
{
    public class Movie : Entity
    {
        public string Name { get; set; }
        public string Duration { get; set; }
        public string CategoryName { get; set; }
        public string ReleaseDate { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Star_Actors { get; set; }
        public string ImagePath { get; set; }
        public string Trailer { get; set; }
    }
}
