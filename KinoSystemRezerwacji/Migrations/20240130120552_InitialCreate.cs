using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KinoSystemRezerwacji.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filmy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CzasTrwania = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seanse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    DataSeansu = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seanse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seanse_Filmy_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Filmy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Filmy",
                columns: new[] { "Id", "CzasTrwania", "Opis", "Tytul" },
                values: new object[,]
                {
                    { 1, 137, "Dramat wojenny...", "Niezłomny" },
                    { 2, 152, "Kolejna epicka część...", "Gwiezdne Wojny: Ostatni Jedi" },
                    { 3, 148, "Thriller science-fiction...", "Incepcja" },
                    { 4, 128, "Muzyczny romans...", "La La Land" },
                    { 5, 169, "Film science-fiction...", "Interstellar" },
                    { 6, 155, "Epicki film...", "Gladiator" }
                });

            migrationBuilder.InsertData(
                table: "Seanse",
                columns: new[] { "Id", "DataSeansu", "FilmId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 30, 18, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 2, new DateTime(2024, 1, 30, 18, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 3, new DateTime(2024, 1, 30, 18, 0, 0, 0, DateTimeKind.Local), 3 },
                    { 4, new DateTime(2024, 1, 30, 18, 0, 0, 0, DateTimeKind.Local), 4 },
                    { 5, new DateTime(2024, 1, 30, 18, 0, 0, 0, DateTimeKind.Local), 5 },
                    { 6, new DateTime(2024, 1, 30, 18, 0, 0, 0, DateTimeKind.Local), 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seanse_FilmId",
                table: "Seanse",
                column: "FilmId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seanse");

            migrationBuilder.DropTable(
                name: "Filmy");
        }
    }
}
