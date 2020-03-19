using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieMood.Data.Migrations
{
    public partial class TicketQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "TicketQuantity",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketQuantity",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
