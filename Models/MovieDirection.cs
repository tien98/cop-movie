using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class MovieDirection
    {
        public int dir_id { get; set; }
        public int mov_id { get; set; }
        public Director Director { get; set; }
        public Movies Movies { get; set; }
    }
}
