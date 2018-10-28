using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRWEntity
{
    public class Reply : Entity
    {
        public int MovieId { get; set; }
        public int Review_Id { get; set; }
        public string Reply_Description { get; set; }
    }
}
