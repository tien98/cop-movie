using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class Genress
    {
        public int gen_id { get; set; }
        public string gen_title { get; set; }
        public int gen_cate { get; set; }
        public ICollection<MovieGenres> MovieGenres { get; set; }
    }
}
