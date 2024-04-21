using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace No1_Online.Migrations
{
    /// <inheritdoc />
    public partial class LoadingSchedule_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoadingSchedules_Drivers_DriverId",
                table: "LoadingSchedules");

            migrationBuilder.AddColumn<decimal>(
                name: "GITValue",
                table: "Vehicles",
                type: "decimal(18,3)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "LoadingSchedules",
                type: "decimal(18,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,4)");

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "LoadingSchedules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_LoadingSchedules_Drivers_DriverId",
                table: "LoadingSchedules",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoadingSchedules_Drivers_DriverId",
                table: "LoadingSchedules");

            migrationBuilder.DropColumn(
                name: "GITValue",
                table: "Vehicles");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "LoadingSchedules",
                type: "decimal(10,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,3)");

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "LoadingSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LoadingSchedules_Drivers_DriverId",
                table: "LoadingSchedules",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
