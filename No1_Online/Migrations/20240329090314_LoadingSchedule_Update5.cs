using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace No1_Online.Migrations
{
    /// <inheritdoc />
    public partial class LoadingSchedule_Update5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoadingSchedules_Notes_NoteId",
                table: "LoadingSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_LoadingSchedules_Vehicles_VehicleId",
                table: "LoadingSchedules");

            migrationBuilder.DropIndex(
                name: "IX_LoadingSchedules_NoteId",
                table: "LoadingSchedules");

            migrationBuilder.DropIndex(
                name: "IX_LoadingSchedules_VehicleId",
                table: "LoadingSchedules");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_LoadingSchedules_NoteId",
                table: "LoadingSchedules",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadingSchedules_VehicleId",
                table: "LoadingSchedules",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoadingSchedules_Notes_NoteId",
                table: "LoadingSchedules",
                column: "NoteId",
                principalTable: "Notes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoadingSchedules_Vehicles_VehicleId",
                table: "LoadingSchedules",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }
    }
}
