using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MulakatAPI.Repository.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CalmaListeSarkilar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CalmaListeSarkilar",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CalmaListeSarkilar",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CalmaListeSarkilar",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CalmaListeSarkilar",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CalmaListeSarkilar",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CalmaListeSarkilar",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CalmaListeSarkilar",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Sanatcilar",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CalmaListeleri",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CalmaListeleri",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CalmaListeleri",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sarkilar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sarkilar",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sarkilar",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Albumler",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Albumler",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Albumler",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sanatcilar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sanatcilar",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "SanatciId",
                table: "Sarkilar",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SanatciId",
                table: "Sarkilar");

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
        }
    }
}
