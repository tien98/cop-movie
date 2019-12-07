using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace web.Models
{
    public class IndexModel : PageModel
    {
        private readonly WebContext _context;

        public IndexModel(WebContext context)
        {
            _context = context;
        }

        public IList<Movies> Movie { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenres { get; set; }

        public async Task OnGetAsync()
        {
            // using linq
            var movies = from m in _context.Movies
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.mov_title.Contains(SearchString));
            }
            Movie = await movies.ToListAsync();
        }
    }

}
