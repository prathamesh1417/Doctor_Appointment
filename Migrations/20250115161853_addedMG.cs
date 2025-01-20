using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication7.Migrations
{
    /// <inheritdoc />
    public partial class addedMG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doct_Book_bookaid",
                table: "Doct");

            migrationBuilder.DropIndex(
                name: "IX_Doct_bookaid",
                table: "Doct");

            migrationBuilder.DropColumn(
                name: "bookaid",
                table: "Doct");

            migrationBuilder.AddColumn<int>(
                name: "aid",
                table: "Doct",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "aid",
                table: "Doct");

            migrationBuilder.AddColumn<int>(
                name: "bookaid",
                table: "Doct",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doct_bookaid",
                table: "Doct",
                column: "bookaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Doct_Book_bookaid",
                table: "Doct",
                column: "bookaid",
                principalTable: "Book",
                principalColumn: "aid");
        }
    }
}
