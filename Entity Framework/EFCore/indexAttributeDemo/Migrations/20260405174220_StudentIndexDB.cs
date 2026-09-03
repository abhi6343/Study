using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndexAttributeDemo.Migrations
{
    /// <inheritdoc />
    public partial class StudentIndexDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Admin");

            migrationBuilder.CreateTable(
                name: "StudentIndexDB",
                schema: "Admin",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationNumber = table.Column<int>(type: "int", nullable: false),
                    RollNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentIndexDB", x => x.StudentId);
                });

            migrationBuilder.CreateIndex(
                name: "Index_RegistrationNumber_RollNumber",
                schema: "Admin",
                table: "StudentIndexDB",
                columns: new[] { "RegistrationNumber", "RollNumber" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentIndexDB",
                schema: "Admin");
        }
    }
}
