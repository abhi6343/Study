using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TableAttributeDemo.Migrations
{
    /// <inheritdoc />
    public partial class TableAttr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegdNo = table.Column<int>(type: "int", nullable: false),
                    SerialNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => new { x.RegdNo, x.SerialNo });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
