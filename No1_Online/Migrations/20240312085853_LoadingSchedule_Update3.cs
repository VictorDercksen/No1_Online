using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace No1_Online.Migrations
{
    /// <inheritdoc />
    public partial class LoadingSchedule_Update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoadingSchedules_Drivers_DriverId",
                table: "LoadingSchedules");

            migrationBuilder.DropIndex(
                name: "IX_LoadingSchedules_DriverId",
                table: "LoadingSchedules");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "LoadingSchedules");

            migrationBuilder.AlterColumn<string>(
                name: "Podnum",
                table: "LoadingSchedules",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Podnum",
                table: "LoadingSchedules",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "LoadingSchedules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoadingSchedules_DriverId",
                table: "LoadingSchedules",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoadingSchedules_Drivers_DriverId",
                table: "LoadingSchedules",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id");
        }
    }
}
