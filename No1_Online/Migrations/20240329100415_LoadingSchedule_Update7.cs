using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace No1_Online.Migrations
{
    /// <inheritdoc />
    public partial class LoadingSchedule_Update7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoadingSchedules_Companies_CompanyId",
                table: "LoadingSchedules");

            migrationBuilder.DropIndex(
                name: "IX_LoadingSchedules_CompanyId",
                table: "LoadingSchedules");

            migrationBuilder.CreateIndex(
                name: "IX_LoadingSchedules_TransporterId",
                table: "LoadingSchedules",
                column: "TransporterId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoadingSchedules_Companies_TransporterId",
                table: "LoadingSchedules",
                column: "TransporterId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoadingSchedules_Companies_TransporterId",
                table: "LoadingSchedules");

            migrationBuilder.DropIndex(
                name: "IX_LoadingSchedules_TransporterId",
                table: "LoadingSchedules");

            migrationBuilder.CreateIndex(
                name: "IX_LoadingSchedules_CompanyId",
                table: "LoadingSchedules",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoadingSchedules_Companies_CompanyId",
                table: "LoadingSchedules",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
