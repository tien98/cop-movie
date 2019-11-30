using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class MoviesCast
    {
        public int act_id { get; set; }
        public int mov_id { get; set; }
        public string role { get; set; }
        public Actor Actor { get; set; }
        public Movies Movies { get; set; }
    }
}
