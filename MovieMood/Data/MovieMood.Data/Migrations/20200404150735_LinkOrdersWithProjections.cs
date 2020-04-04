using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieMood.Data.Migrations
{
    public partial class LinkOrdersWithProjections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectionId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProjectionId",
                table: "Orders",
                column: "ProjectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Projections_ProjectionId",
                table: "Orders",
                column: "ProjectionId",
                principalTable: "Projections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Projections_ProjectionId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProjectionId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProjectionId",
                table: "Orders");
        }
    }
}
