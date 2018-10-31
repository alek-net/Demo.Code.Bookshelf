using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookshelf.DAL.Migrations
{
    public partial class FixBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Author", "ISBN", "Title" },
                values: new object[] { "Steve Kinney", "9781617294143", "Electron in Action" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Author", "ISBN", "Title" },
                values: new object[] { "François Chollet", "9781617294433", "Deep Learning with Python" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Author", "ISBN", "Title" },
                values: new object[] { "Morgan Bruce, Paulo A. Pereira", "9781617294457", "Microservices in Action" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Author", "ISBN", "Title" },
                values: new object[] { "Craig Walls", "9781617294945", "Spring in Action, Fifth Edition" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Author", "ISBN", "Title" },
                values: new object[] { "Alessandro Negro", "9781617295645", "Graph-Powered Machine Learning" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Scott Guthrie");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Robert C. Martin");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Damian Edwards");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Author", "ISBN", "Title" },
                values: new object[] { "Aleksandar", "ISBN", "Mojata borba" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Author", "ISBN", "Title" },
                values: new object[] { "Petar", "ISBN2", "Borbata na Petar" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Author", "ISBN", "Title" },
                values: new object[] { "Marija", "ISBN3", "Prolet" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Author", "ISBN", "Title" },
                values: new object[] { "Petranka", "ISBN4", "Esen" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Author", "ISBN", "Title" },
                values: new object[] { "Marija", "ISBN5", "Zimata dojde vo mojot kraj" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Aleksandar");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Julijana");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Peco");
        }
    }
}
