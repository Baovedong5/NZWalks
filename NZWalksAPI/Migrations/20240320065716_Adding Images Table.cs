using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingImagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    FileName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FileDescription = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    FileExtesion = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FileSizeInBytes = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    FilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
