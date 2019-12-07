using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace web.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    act_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    act_fname = table.Column<string>(nullable: true),
                    act_lname = table.Column<string>(nullable: true),
                    act_gender = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.act_id);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    dir_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dir_fname = table.Column<string>(nullable: true),
                    dir_lname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.dir_id);
                });

            migrationBuilder.CreateTable(
                name: "Genresses",
                columns: table => new
                {
                    gen_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    gen_title = table.Column<string>(nullable: true),
                    gen_cate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genresses", x => x.gen_id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    mov_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mov_title = table.Column<string>(nullable: true),
                    mov_year = table.Column<int>(nullable: false),
                    mov_time = table.Column<int>(nullable: false),
                    mov_img = table.Column<string>(nullable: true),
                    mov_url = table.Column<string>(nullable: true),
                    mov_country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.mov_id);
                });

            migrationBuilder.CreateTable(
                name: "Reviewers",
                columns: table => new
                {
                    rev_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rev_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviewers", x => x.rev_id);
                });

            migrationBuilder.CreateTable(
                name: "MovieDirections",
                columns: table => new
                {
                    mov_id = table.Column<int>(nullable: false),
                    dir_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDirections", x => x.mov_id);
                    table.UniqueConstraint("AK_MovieDirections_dir_id", x => x.dir_id);
                    table.ForeignKey(
                        name: "FK_MovieDirections_Directors_dir_id",
                        column: x => x.dir_id,
                        principalTable: "Directors",
                        principalColumn: "dir_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieDirections_Movies_mov_id",
                        column: x => x.mov_id,
                        principalTable: "Movies",
                        principalColumn: "mov_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenres",
                columns: table => new
                {
                    mov_id = table.Column<int>(nullable: false),
                    gen_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres", x => x.mov_id);
                    table.UniqueConstraint("AK_MovieGenres_gen_id", x => x.gen_id);
                    table.ForeignKey(
                        name: "FK_MovieGenres_Genresses_gen_id",
                        column: x => x.gen_id,
                        principalTable: "Genresses",
                        principalColumn: "gen_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenres_Movies_mov_id",
                        column: x => x.mov_id,
                        principalTable: "Movies",
                        principalColumn: "mov_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviesCasts",
                columns: table => new
                {
                    mov_id = table.Column<int>(nullable: false),
                    act_id = table.Column<int>(nullable: false),
                    role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesCasts", x => x.mov_id);
                    table.UniqueConstraint("AK_MoviesCasts_act_id", x => x.act_id);
                    table.ForeignKey(
                        name: "FK_MoviesCasts_Actors_act_id",
                        column: x => x.act_id,
                        principalTable: "Actors",
                        principalColumn: "act_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesCasts_Movies_mov_id",
                        column: x => x.mov_id,
                        principalTable: "Movies",
                        principalColumn: "mov_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    mov_id = table.Column<int>(nullable: false),
                    rev_id = table.Column<int>(nullable: false),
                    rev_stars = table.Column<int>(nullable: false),
                    num_o_ratings = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.mov_id);
                    table.UniqueConstraint("AK_Ratings_rev_id", x => x.rev_id);
                    table.ForeignKey(
                        name: "FK_Ratings_Movies_mov_id",
                        column: x => x.mov_id,
                        principalTable: "Movies",
                        principalColumn: "mov_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Reviewers_rev_id",
                        column: x => x.rev_id,
                        principalTable: "Reviewers",
                        principalColumn: "rev_id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieDirections");

            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "MoviesCasts");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Genresses");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Reviewers");
        }
    }
}
