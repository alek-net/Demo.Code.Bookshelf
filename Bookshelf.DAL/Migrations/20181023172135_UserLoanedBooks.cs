using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookshelf.DAL.Migrations
{
    public partial class UserLoanedBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Books_LoanedTo",
                table: "Books",
                column: "LoanedTo");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_LoanedTo",
                table: "Books",
                column: "LoanedTo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_LoanedTo",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_LoanedTo",
                table: "Books");
        }
    }
}
