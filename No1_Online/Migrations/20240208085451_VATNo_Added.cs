using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace No1_Online.Migrations
{
    /// <inheritdoc />
    public partial class VATNo_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VATNo",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VATNo",
                table: "Companies");
        }
    }
}
