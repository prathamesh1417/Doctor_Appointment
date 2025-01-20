using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication7.Migrations
{
    /// <inheritdoc />
    public partial class DBupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginCredential",
                columns: table => new
                {
                    LoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", nullable: false),
                    ConfirmPassword = table.Column<string>(name: "Confirm Password", type: "varchar(100)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginCredential", x => x.LoginId);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    aid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Patient_Address = table.Column<string>(type: "varchar(100)", nullable: false),
                    Patient_mobileNo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Patient_Aadhar = table.Column<string>(type: "varchar(100)", nullable: false),
                    Patient_Message = table.Column<string>(type: "varchar(100)", nullable: false),
                    Date = table.Column<string>(type: "varchar(100)", nullable: false),
                    Doctor_Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    did = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.aid);
                });

            migrationBuilder.CreateTable(
                name: "Doct",
                columns: table => new
                {
                    did = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Doctor_Username = table.Column<string>(type: "varchar(100)", nullable: false),
                    Doctor_Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Doctor_Pass = table.Column<string>(type: "varchar(100)", nullable: false),
                    Doctor_CPASS = table.Column<string>(type: "varchar(100)", nullable: false),
                    Doctor_Certificate = table.Column<string>(type: "varchar(100)", nullable: false),
                    Certi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bookaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doct", x => x.did);
                    table.ForeignKey(
                        name: "FK_Doct_Book_bookaid",
                        column: x => x.bookaid,
                        principalTable: "Book",
                        principalColumn: "aid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_did",
                table: "Book",
                column: "did");

            migrationBuilder.CreateIndex(
                name: "IX_Doct_bookaid",
                table: "Doct",
                column: "bookaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Doct_did",
                table: "Book",
                column: "did",
                principalTable: "Doct",
                principalColumn: "did",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Doct_did",
                table: "Book");

            migrationBuilder.DropTable(
                name: "LoginCredential");

            migrationBuilder.DropTable(
                name: "Doct");

            migrationBuilder.DropTable(
                name: "Book");
        }
    }
}
