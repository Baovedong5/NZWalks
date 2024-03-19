using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class Seedingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7f9058ca-1123-4f7a-95fb-42be587e2722"), "Hard" },
                    { new Guid("a9648a0a-9d67-4f3e-a7c8-0d9d601a3396"), "Medium" },
                    { new Guid("bd502112-a322-4092-a458-5d332db054ec"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0447bc9c-ce4b-4019-882e-355d8f6686f4"), "AKL", "Auckland", "https://bit.ly/3VpbtMS" },
                    { new Guid("4c218e45-068d-4bc2-b346-74eec5466661"), "WGN", "Wellington", "https://bit.ly/4aeiB2Q" },
                    { new Guid("829de7fe-8a55-4f70-9f5d-adab12215f51"), "NSN", "Nelson", "https://bit.ly/49VT2E6" },
                    { new Guid("a3c2db25-b582-4cd4-8d10-2c1ab984e2c9"), "BOP", "Bay Of Plenty", null },
                    { new Guid("ac601f69-b2f9-473e-a168-cf11a722a655"), "STL", "Southland", "null" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("7f9058ca-1123-4f7a-95fb-42be587e2722"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("a9648a0a-9d67-4f3e-a7c8-0d9d601a3396"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("bd502112-a322-4092-a458-5d332db054ec"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0447bc9c-ce4b-4019-882e-355d8f6686f4"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4c218e45-068d-4bc2-b346-74eec5466661"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("829de7fe-8a55-4f70-9f5d-adab12215f51"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a3c2db25-b582-4cd4-8d10-2c1ab984e2c9"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ac601f69-b2f9-473e-a168-cf11a722a655"));
        }
    }
}
