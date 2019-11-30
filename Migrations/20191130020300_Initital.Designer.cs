﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using web.Models;

namespace web.Migrations
{
    [DbContext(typeof(WebContext))]
    [Migration("20191130020300_Initital")]
    partial class Initital
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("web.Models.Actor", b =>
                {
                    b.Property<int>("act_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("act_fname")
                        .HasColumnType("text");

                    b.Property<bool>("act_gender")
                        .HasColumnType("boolean");

                    b.Property<string>("act_lname")
                        .HasColumnType("text");

                    b.HasKey("act_id");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("web.Models.Director", b =>
                {
                    b.Property<int>("dir_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("dir_fname")
                        .HasColumnType("text");

                    b.Property<string>("dir_lname")
                        .HasColumnType("text");

                    b.HasKey("dir_id");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("web.Models.Genress", b =>
                {
                    b.Property<int>("gen_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("gen_cate")
                        .HasColumnType("integer");

                    b.Property<string>("gen_title")
                        .HasColumnType("text");

                    b.HasKey("gen_id");

                    b.ToTable("Genresses");
                });

            modelBuilder.Entity("web.Models.MovieDirection", b =>
                {
                    b.Property<int>("mov_id")
                        .HasColumnType("integer");

                    b.Property<int>("dir_id")
                        .HasColumnType("integer");

                    b.HasKey("mov_id");

                    b.HasAlternateKey("dir_id");

                    b.ToTable("MovieDirections");
                });

            modelBuilder.Entity("web.Models.MovieGenres", b =>
                {
                    b.Property<int>("mov_id")
                        .HasColumnType("integer");

                    b.Property<int>("gen_id")
                        .HasColumnType("integer");

                    b.HasKey("mov_id");

                    b.HasAlternateKey("gen_id");

                    b.ToTable("MovieGenres");
                });

            modelBuilder.Entity("web.Models.Movies", b =>
                {
                    b.Property<int>("mov_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("mov_country")
                        .HasColumnType("text");

                    b.Property<string>("mov_img")
                        .HasColumnType("text");

                    b.Property<int>("mov_time")
                        .HasColumnType("integer");

                    b.Property<string>("mov_title")
                        .HasColumnType("text");

                    b.Property<string>("mov_url")
                        .HasColumnType("text");

                    b.Property<int>("mov_year")
                        .HasColumnType("integer");

                    b.HasKey("mov_id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("web.Models.MoviesCast", b =>
                {
                    b.Property<int>("mov_id")
                        .HasColumnType("integer");

                    b.Property<int>("act_id")
                        .HasColumnType("integer");

                    b.Property<string>("role")
                        .HasColumnType("text");

                    b.HasKey("mov_id");

                    b.HasAlternateKey("act_id");

                    b.ToTable("MoviesCasts");
                });

            modelBuilder.Entity("web.Models.Rating", b =>
                {
                    b.Property<int>("mov_id")
                        .HasColumnType("integer");

                    b.Property<int>("num_o_ratings")
                        .HasColumnType("integer");

                    b.Property<int>("rev_id")
                        .HasColumnType("integer");

                    b.Property<int>("rev_stars")
                        .HasColumnType("integer");

                    b.HasKey("mov_id");

                    b.HasAlternateKey("rev_id");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("web.Models.Reviewer", b =>
                {
                    b.Property<int>("rev_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("rev_name")
                        .HasColumnType("text");

                    b.HasKey("rev_id");

                    b.ToTable("Reviewers");
                });

            modelBuilder.Entity("web.Models.MovieDirection", b =>
                {
                    b.HasOne("web.Models.Director", "Director")
                        .WithMany("MovieDirections")
                        .HasForeignKey("dir_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("web.Models.Movies", "Movies")
                        .WithMany("MovieDirections")
                        .HasForeignKey("mov_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("web.Models.MovieGenres", b =>
                {
                    b.HasOne("web.Models.Genress", "Genress")
                        .WithMany("MovieGenres")
                        .HasForeignKey("gen_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("web.Models.Movies", "Movies")
                        .WithMany("MovieGenres")
                        .HasForeignKey("mov_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("web.Models.MoviesCast", b =>
                {
                    b.HasOne("web.Models.Actor", "Actor")
                        .WithMany("MoviesCasts")
                        .HasForeignKey("act_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("web.Models.Movies", "Movies")
                        .WithMany("MoviesCasts")
                        .HasForeignKey("mov_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("web.Models.Rating", b =>
                {
                    b.HasOne("web.Models.Movies", "Movies")
                        .WithMany("Ratings")
                        .HasForeignKey("mov_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("web.Models.Reviewer", "Reviewer")
                        .WithMany("Ratings")
                        .HasForeignKey("rev_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
