using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class Actor
    {
        public int act_id { get; set; }
        public string act_fname { get; set; }
        public string act_lname { get; set; }
        public bool act_gender { get; set; }

        public ICollection<MoviesCast> MoviesCasts { get; set; }
    }
}
