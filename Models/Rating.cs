using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class Rating
    {
        public int mov_id { get; set; }
        public int rev_id { get; set; }
        public int rev_stars { get; set; }
        public int num_o_ratings { get; set; }
        public Movies Movies { get; set; }
        public Reviewer Reviewer { get; set; }
    }
}
