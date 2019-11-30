using Microsoft.EntityFrameworkCore.Migrations;

namespace web.Migrations
{
    public partial class Initital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "gen_cate",
                table: "Genresses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "gen_cate",
                table: "Genresses");
        }
    }
}
