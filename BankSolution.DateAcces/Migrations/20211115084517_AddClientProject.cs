using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankSolution.DateAcces.Migrations
{
    public partial class AddClientProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderPrice = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "OrderPrice" },
                values: new object[,]
                {
                    { 1, "andrew.berry@outlook.com", "Andrew", "Berry", 35520m },
                    { 2, "jasmine.clarkson@outlook.com", "Jasmine", "Clarkson", 27873m },
                    { 3, "tim.coleman@outlook.com", "Tim", "Coleman", 32522m },
                    { 4, "dominic.short@outlook.com", "Dominic", "Short", 37973m },
                    { 5, "wendy.clark@outlook.com", "Wendy", "Clark", 60478m }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Budget", "ClientId", "Name", "StartedDate" },
                values: new object[,]
                {
                    { 5, 7333m, 1, "Uzzin", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 84479m, 2, "RuddyRex", new DateTime(2015, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 14451m, 3, "Whistler", new DateTime(2015, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 4466m, 4, "DejaVu", new DateTime(2007, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 806m, 5, "Lonesome", new DateTime(2006, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientId",
                table: "Projects",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Clients_ClientId",
                table: "Projects",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Clients_ClientId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ClientId",
                table: "Projects");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Projects");
        }
    }
}
