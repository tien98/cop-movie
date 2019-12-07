using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Models;

namespace web.Repository
{
    public class MovieRepository : IMovieRepository
    {
        WebContext db;
        public MovieRepository(WebContext _db)
        {
            db = _db;
        }

        public async Task<List<Genress>> GetCategories()
        {
            if (db != null)
            {
                return await db.Genresses.ToListAsync();
            }

            return null;
        }

        public async Task<List<Movies>> GetMovies()
        {
            if (db != null)
            {
                return await (from p in db.Movies
                              select p).ToListAsync();
            }

            return null;
        }

        public async Task<List<Movies>> GetMovie()
        {
            if (db != null)
            {
                return await (from p in db.Movies
                              select p).ToListAsync();
            }

            return null;
        }

        public async Task<Movies> GetMovie(int? movieId)
        {
            if (db != null)
            {
                return await (from p in db.Movies
                              where p.mov_id == movieId
                              select p).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<int> AddMovie(Movies movie)
        {
            if (db != null)
            {
                await db.Movies.AddAsync(movie);
                await db.SaveChangesAsync();

                return movie.mov_id;
            }

            return 0;
        }

        public async Task<int> DeleteMovie(int? MovieId)
        {
            int result = 0;

            if (db != null)
            {
                //Find the Movie for specific Movie id
                var Movie = await db.Movies.FirstOrDefaultAsync(x => x.mov_id == MovieId);

                if (Movie != null)
                {
                    //Delete that Movie
                    db.Movies.Remove(Movie);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }


        public async Task UpdateMovie(Movies movie)
        {
            if (db != null)
            {
                //Delete that Movie
                db.Movies.Update(movie);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}
