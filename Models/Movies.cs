using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class Movies
    {
        public int mov_id { get; set; }
        public string mov_title { get; set; }
        public int mov_year { get; set; }
        public int mov_time { get; set; }
        public string mov_img { get; set; }
        public string mov_url { get; set; }
        public string mov_country { get; set; }
        public ICollection<MoviesCast> MoviesCasts { get; set; }
        public ICollection<MovieDirection> MovieDirections { get; set; }
        public ICollection<MovieGenres> MovieGenres { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
