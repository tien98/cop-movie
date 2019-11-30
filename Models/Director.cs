using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class Director
    {
        public int dir_id { get; set; }
        public string dir_fname { get; set; }
        public string dir_lname { get; set; }
        public ICollection<MovieDirection> MovieDirections { get; set; }
    }
}
