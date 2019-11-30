using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class Reviewer
    {
        public int rev_id { get; set; }
        public string rev_name { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
