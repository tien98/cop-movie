using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class CategoryContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Genres> Genress { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NewsDB;Integrated Security=True");
        }
    }
}
