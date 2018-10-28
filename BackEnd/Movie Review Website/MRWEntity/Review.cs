using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRWEntity
{
    public class Review : Entity
    {
        public int MovieId { get; set; }
        public string Review_Description { get; set; }
    }
}
