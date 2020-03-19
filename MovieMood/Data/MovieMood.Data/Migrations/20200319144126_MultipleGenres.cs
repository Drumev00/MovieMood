using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieMood.Data.Migrations
{
    public partial class MultipleGenres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MovieGenres",
                columns: table => new
                {
                    MovieId = table.Column<string>(nullable: false),
                    Genre = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres", x => new { x.MovieId, x.Genre });
                    table.ForeignKey(
                        name: "FK_MovieGenres_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "Genre",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
