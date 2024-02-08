using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace No1_Online.Migrations
{
    /// <inheritdoc />
    public partial class PostalCode_Spelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostcalCode",
                table: "Addresses",
                newName: "PostalCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Addresses",
                newName: "PostcalCode");
        }
    }
}
