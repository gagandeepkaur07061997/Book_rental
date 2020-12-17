using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace Book_rental.Migrations
{
    public partial class Book : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile_Number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publisher_detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Publisher_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email_Id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher_detail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books_detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tittle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books_detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_detail_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Publication_detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Books_Copies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher_detailId = table.Column<int>(type: "int", nullable: false),
                    Books_detailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publication_detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publication_detail_Books_detail_Books_detailId",
                        column: x => x.Books_detailId,
                        principalTable: "Books_detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Publication_detail_Publisher_detail_Publisher_detailId",
                        column: x => x.Publisher_detailId,
                        principalTable: "Publisher_detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_detail_AuthorId",
                table: "Books_detail",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Publication_detail_Books_detailId",
                table: "Publication_detail",
                column: "Books_detailId");

            migrationBuilder.CreateIndex(
                name: "IX_Publication_detail_Publisher_detailId",
                table: "Publication_detail",
                column: "Publisher_detailId");

            var sqlFile = Path.Combine(".\\dbdatabase", @"data.sql");

            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Publication_detail");

            migrationBuilder.DropTable(
                name: "Books_detail");

            migrationBuilder.DropTable(
                name: "Publisher_detail");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
