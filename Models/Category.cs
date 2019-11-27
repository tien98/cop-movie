using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace web.Models
{
    public class Category
    {
        public Category()
        {
            Genres = new HashSet<Genres>();
        }
        [Key]
        public int id { get; set; }
        [StringLength(100)]
        public string name { get; set; }
        public ICollection<Genres> Genres { get; set; }

    }
}
