using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class InsertPerson_StoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_InsertPerson = @"CREATE PROCEDURE [dbo].[InsertPerson]
                                        (@PersonID uniqueidentifier, @CountryID uniqueidentifier, @PersonName nvarchar(40), @Email nvarchar(40), @Gender nvarchar(10), @DateOfBirth datetime2(7), @Address nvarchar(200), @ReceiveNewsLetters bit)
                                            AS BEGIN
                                                INSERT INTO [dbo].[Persons] (PersonID, CountryID, PersonName, Email, Gender, DateOfBirth, Address, ReceiveNewsLetters)
                                                VALUES (@PersonID, @CountryID, @PersonName, @Email, @Gender, @DateOfBirth, @Address, @ReceiveNewsLetters);
                                            END";
            migrationBuilder.Sql(sp_InsertPerson);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_InsertPerson = @"DROP PROCEDURE [dbo].[InsertPerson]";
            migrationBuilder.Sql(sp_InsertPerson);
        }
    }
}
