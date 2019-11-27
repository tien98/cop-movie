using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class Genres
    {
        [Key]
        public int id { get; set; }
        [StringLength(100)]
        public string gen_name { get; set; }
        public int idCategory { get; set; }
        [ForeignKey("idCategory")]
        public virtual Category Category { get; set; }
    }
}
