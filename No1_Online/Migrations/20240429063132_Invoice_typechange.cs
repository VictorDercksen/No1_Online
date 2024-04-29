using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace No1_Online.Migrations
{
    /// <inheritdoc />
    public partial class Invoice_typechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Remitances");

            migrationBuilder.AddColumn<string>(
                name: "Invoice",
                table: "Remitances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Invoice",
                table: "Remitances");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Remitances",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
