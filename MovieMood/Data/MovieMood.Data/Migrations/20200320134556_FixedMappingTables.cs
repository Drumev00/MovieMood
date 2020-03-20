using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieMood.Data.Migrations
{
    public partial class FixedMappingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "TicketOrders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "TicketOrders",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TicketOrders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "TicketOrders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "MovieGenres",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "MovieGenres",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MovieGenres",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "MovieGenres",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketOrders_IsDeleted",
                table: "TicketOrders",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_IsDeleted",
                table: "MovieGenres",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TicketOrders_IsDeleted",
                table: "TicketOrders");

            migrationBuilder.DropIndex(
                name: "IX_MovieGenres_IsDeleted",
                table: "MovieGenres");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "TicketOrders");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "TicketOrders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TicketOrders");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "TicketOrders");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "MovieGenres");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "MovieGenres");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MovieGenres");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "MovieGenres");
        }
    }
}
