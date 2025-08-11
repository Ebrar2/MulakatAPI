using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MulakatAPI.Repository.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalmaListeleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalmaListeleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sanatcilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KurulusTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanatcilar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albumler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SanatciId = table.Column<int>(type: "int", nullable: false),
                    CikisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albumler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albumler_Sanatcilar_SanatciId",
                        column: x => x.SanatciId,
                        principalTable: "Sanatcilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sarkilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlbumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sarkilar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sarkilar_Albumler_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albumler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalmaListeSarkilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalmaListeId = table.Column<int>(type: "int", nullable: false),
                    SarkiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalmaListeSarkilar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalmaListeSarkilar_CalmaListeleri_CalmaListeId",
                        column: x => x.CalmaListeId,
                        principalTable: "CalmaListeleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalmaListeSarkilar_Sarkilar_SarkiId",
                        column: x => x.SarkiId,
                        principalTable: "Sarkilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CalmaListeleri",
                columns: new[] { "Id", "Ad" },
                values: new object[,]
                {
                    { 1, "CalmaListe1" },
                    { 2, "CalmaListe2" },
                    { 3, "CalmaListe3" }
                });

            migrationBuilder.InsertData(
                table: "Sanatcilar",
                columns: new[] { "Id", "Ad", "KurulusTarihi" },
                values: new object[,]
                {
                    { 1, "Sanatci1", new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Sanatci2", new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Sanatci3", new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Albumler",
                columns: new[] { "Id", "Ad", "CikisTarihi", "SanatciId" },
                values: new object[,]
                {
                    { 1, "Album1", new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "Album2", new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, "Album3", new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Sarkilar",
                columns: new[] { "Id", "Ad", "AlbumId" },
                values: new object[,]
                {
                    { 1, "Sarki1", 1 },
                    { 2, "Sarki2", 3 },
                    { 3, "Sarki3", 2 }
                });

            migrationBuilder.InsertData(
                table: "CalmaListeSarkilar",
                columns: new[] { "Id", "CalmaListeId", "SarkiId" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 2, 2 },
                    { 3, 1, 3 },
                    { 4, 2, 3 },
                    { 5, 3, 1 },
                    { 6, 3, 2 },
                    { 7, 3, 3 },
                    { 8, 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albumler_SanatciId",
                table: "Albumler",
                column: "SanatciId");

            migrationBuilder.CreateIndex(
                name: "IX_CalmaListeSarkilar_CalmaListeId",
                table: "CalmaListeSarkilar",
                column: "CalmaListeId");

            migrationBuilder.CreateIndex(
                name: "IX_CalmaListeSarkilar_SarkiId_CalmaListeId",
                table: "CalmaListeSarkilar",
                columns: new[] { "SarkiId", "CalmaListeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sarkilar_AlbumId",
                table: "Sarkilar",
                column: "AlbumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalmaListeSarkilar");

            migrationBuilder.DropTable(
                name: "CalmaListeleri");

            migrationBuilder.DropTable(
                name: "Sarkilar");

            migrationBuilder.DropTable(
                name: "Albumler");

            migrationBuilder.DropTable(
                name: "Sanatcilar");
        }
    }
}
