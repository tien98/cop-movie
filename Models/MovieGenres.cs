using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class MovieGenres
    {
        public int mov_id { get; set; }
        public int gen_id { get; set; }
        public Genress Genress { get; set; }
        public Movies Movies { get; set; }
    }
}
