using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookshelf.DAL.Migrations
{
    public partial class AdditionalBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "ISBN", "LoanedTo", "Title" },
                values: new object[] { 5, "Marija", "ISBN5", null, "Zimata dojde vo mojot kraj" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
