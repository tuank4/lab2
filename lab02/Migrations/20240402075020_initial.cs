using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace lab02.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desciption = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StId);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.StId, x.CId });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CId",
                        column: x => x.CId,
                        principalTable: "Courses",
                        principalColumn: "CId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StId",
                        column: x => x.StId,
                        principalTable: "Students",
                        principalColumn: "StId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CId", "CName", "Desciption" },
                values: new object[,]
                {
                    { new Guid("6ebc3dbe-2e7b-4132-8c33-e089d47694cd"), "Walter Isaacson", "Harry Potter's life is miserable. His parents are dead" },
                    { new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"), "J.K. Rowling", "Harry Potter's life is miserable. His parents are dead and he's stuck with his heartless relatives, who force him to live in a tiny closet under the stairs." }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StId", "Name" },
                values: new object[,]
                {
                    { new Guid("150c81c6-2458-466e-907a-2df11325e2b8"), "Steve Jobs" },
                    { new Guid("98474b8e-d713-401e-8aee-acb7353f97bb"), "Harry Potter and the Sorcerer's Stone" },
                    { new Guid("bfe902af-3cf0-4a1c-8a83-66be60b028ba"), "Harry Chamber " }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CId", "StId" },
                values: new object[,]
                {
                    { new Guid("6ebc3dbe-2e7b-4132-8c33-e089d47694cd"), new Guid("150c81c6-2458-466e-907a-2df11325e2b8") },
                    { new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"), new Guid("98474b8e-d713-401e-8aee-acb7353f97bb") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CId",
                table: "StudentCourses",
                column: "CId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
