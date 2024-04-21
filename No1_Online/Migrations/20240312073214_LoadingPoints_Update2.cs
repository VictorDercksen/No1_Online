using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace No1_Online.Migrations
{
    /// <inheritdoc />
    public partial class LoadingPoints_Update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoadingPoints_Contacts_ContactId",
                table: "LoadingPoints");

            migrationBuilder.DropIndex(
                name: "IX_LoadingPoints_ContactId",
                table: "LoadingPoints");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "LoadingPoints");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "LoadingPoints",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoadingPoints_ContactId",
                table: "LoadingPoints",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoadingPoints_Contacts_ContactId",
                table: "LoadingPoints",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id");
        }
    }
}
