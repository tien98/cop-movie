using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Models;

namespace web.Repository
{
    public interface IGenress
    {
        Task Add(Genress genres);
        bool Exsist(int id);
        Task Update(Genress genres);
        Task Remove(int id);
        Task<Genress> FindByID(int id);
        Task<List<Genress>>  GetAll();
    }
    public class GenresRepository : IGenress
    {
        private readonly WebContext context;
        public  GenresRepository(WebContext _context)
        {
            this.context = _context;
        }
        public async Task Add(Genress genres)
        {
            context.Add(genres);
             await context.SaveChangesAsync();
        }

        public bool Exsist(int id)
        {
            Genress genres = context.Genresses.Find(id);
            if(genres != null)
            {
                return true;
            }
            return false;
        }

        public async Task<Genress> FindByID(int id)
        {
            Genress genres = await context.Genresses.FindAsync(id);
            return genres;

        }
        public async Task<List<Genress>> GetAll()
        {
            return await context.Genresses.ToListAsync();
        }

        public async Task Remove(int id)
        {
            Genress genres = await context.Genresses.FindAsync(id);
            context.Genresses.Remove(genres);
            context.SaveChanges();
        }

        public async Task Update(Genress genres)
        {
            Genress genressNew = await context.Genresses.FindAsync(genres.gen_id);
            genressNew = genres;
            await context.SaveChangesAsync();
        }
    }
}
