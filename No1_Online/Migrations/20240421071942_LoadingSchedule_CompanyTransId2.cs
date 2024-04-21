using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace No1_Online.Migrations
{
    /// <inheritdoc />
    public partial class LoadingSchedule_CompanyTransId2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoadingSchedules_Companies_TransporterId",
                table: "LoadingSchedules");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "LoadingSchedules");

            migrationBuilder.RenameColumn(
                name: "TransporterId",
                table: "LoadingSchedules",
                newName: "CompanyTransId");

            migrationBuilder.RenameIndex(
                name: "IX_LoadingSchedules_TransporterId",
                table: "LoadingSchedules",
                newName: "IX_LoadingSchedules_CompanyTransId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoadingSchedules_Companies_CompanyTransId",
                table: "LoadingSchedules",
                column: "CompanyTransId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoadingSchedules_Companies_CompanyTransId",
                table: "LoadingSchedules");

            migrationBuilder.RenameColumn(
                name: "CompanyTransId",
                table: "LoadingSchedules",
                newName: "TransporterId");

            migrationBuilder.RenameIndex(
                name: "IX_LoadingSchedules_CompanyTransId",
                table: "LoadingSchedules",
                newName: "IX_LoadingSchedules_TransporterId");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId1",
                table: "LoadingSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_LoadingSchedules_Companies_TransporterId",
                table: "LoadingSchedules",
                column: "TransporterId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
