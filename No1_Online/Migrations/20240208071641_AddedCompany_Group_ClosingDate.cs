using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace No1_Online.Migrations
{
    /// <inheritdoc />
    public partial class AddedCompany_Group_ClosingDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ClosingDate",
                table: "Companies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosingDate",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Group",
                table: "Companies");
        }
    }
}
