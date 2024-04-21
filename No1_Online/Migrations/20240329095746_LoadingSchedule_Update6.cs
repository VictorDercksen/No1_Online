using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace No1_Online.Migrations
{
    /// <inheritdoc />
    public partial class LoadingSchedule_Update6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_LoadingSchedules_LoadingPointLoadId",
                table: "LoadingSchedules",
                column: "LoadingPointLoadId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadingSchedules_LoadingPointOffId",
                table: "LoadingSchedules",
                column: "LoadingPointOffId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadingSchedules_VehicleId",
                table: "LoadingSchedules",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoadingSchedules_LoadingPoints_LoadingPointLoadId",
                table: "LoadingSchedules",
                column: "LoadingPointLoadId",
                principalTable: "LoadingPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoadingSchedules_LoadingPoints_LoadingPointOffId",
                table: "LoadingSchedules",
                column: "LoadingPointOffId",
                principalTable: "LoadingPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoadingSchedules_Vehicles_VehicleId",
                table: "LoadingSchedules",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoadingSchedules_LoadingPoints_LoadingPointLoadId",
                table: "LoadingSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_LoadingSchedules_LoadingPoints_LoadingPointOffId",
                table: "LoadingSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_LoadingSchedules_Vehicles_VehicleId",
                table: "LoadingSchedules");

            migrationBuilder.DropIndex(
                name: "IX_LoadingSchedules_LoadingPointLoadId",
                table: "LoadingSchedules");

            migrationBuilder.DropIndex(
                name: "IX_LoadingSchedules_LoadingPointOffId",
                table: "LoadingSchedules");

            migrationBuilder.DropIndex(
                name: "IX_LoadingSchedules_VehicleId",
                table: "LoadingSchedules");
        }
    }
}
