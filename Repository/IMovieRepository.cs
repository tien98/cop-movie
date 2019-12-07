using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Models;

namespace web.Repository
{
    interface IMovieRepository
    {
        Task<List<Genress>> GetCategories();

        Task<List<Movies>> GetMovies();

        Task<Movies> GetMovie(int? movieId);

        Task<int> AddMovie(Movies movie);

        Task<int> DeleteMovie(int? movieId);

        Task UpdateMovie(Movies movie);
    }
}
