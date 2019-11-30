using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class WebContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<MovieDirection> MovieDirections { get; set; }
        public DbSet<MoviesCast> MoviesCasts { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<Genress> Genresses { get; set; }
        public DbSet<MovieGenres> MovieGenres { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public WebContext(DbContextOptions<WebContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>( b =>
            {
                b.HasKey(e => e.act_id);
                b.Property(e => e.act_id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Director>(b =>
            {
                b.HasKey(e => e.dir_id);
                b.Property(e => e.dir_id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Movies>(b =>
            {
                b.HasKey(e => e.mov_id);
                b.Property(e => e.mov_id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Reviewer>(b =>
            {
                b.HasKey(e => e.rev_id);
                b.Property(e => e.rev_id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Genress>(b =>
            {
                b.HasKey(e => e.gen_id);
                b.Property(e => e.gen_id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<MovieDirection>(b =>
            {
                b.HasKey(e => e.dir_id);
                b.HasKey(e => e.mov_id);
            });

            modelBuilder.Entity<Rating>(b =>
            {
                b.HasKey(e => e.rev_id);
                b.HasKey(e => e.mov_id);
            });

            modelBuilder.Entity<MovieGenres>(b =>
            {
                b.HasKey(e => e.gen_id);
                b.HasKey(e => e.mov_id);
            });

            modelBuilder.Entity<MoviesCast>(b =>
            {
                b.HasKey(e => e.act_id);
                b.HasKey(e => e.mov_id);
            });

            modelBuilder.Entity<MoviesCast>()
                .HasOne<Actor>(s => s.Actor)
                .WithMany(g => g.MoviesCasts)
                .HasForeignKey(s => s.act_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MoviesCast>()
                .HasOne<Movies>(s => s.Movies)
                .WithMany(g => g.MoviesCasts)
                .HasForeignKey(s => s.mov_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MovieDirection>()
                .HasOne<Director>(s => s.Director)
                .WithMany(g => g.MovieDirections)
                .HasForeignKey(s => s.dir_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MovieDirection>()
                .HasOne<Movies>(s => s.Movies)
                .WithMany(g => g.MovieDirections)
                .HasForeignKey(s => s.mov_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MovieGenres>()
                .HasOne<Genress>(s => s.Genress)
                .WithMany(g => g.MovieGenres)
                .HasForeignKey(s => s.gen_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MovieGenres>()
                .HasOne<Movies>(s => s.Movies)
                .WithMany(g => g.MovieGenres)
                .HasForeignKey(s => s.mov_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Rating>()
                .HasOne<Movies>(s => s.Movies)
                .WithMany(g => g.Ratings)
                .HasForeignKey(s => s.mov_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Rating>()
                .HasOne<Reviewer>(s => s.Reviewer)
                .WithMany(g => g.Ratings)
                .HasForeignKey(s => s.rev_id)
                .OnDelete(DeleteBehavior.Cascade);
        } 
    }
}
