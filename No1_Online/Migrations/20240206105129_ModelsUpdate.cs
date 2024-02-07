using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace No1_Online.Migrations
{
    /// <inheritdoc />
    public partial class ModelsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoadingPoints_Contacts_ContactId",
                table: "LoadingPoints");

            migrationBuilder.AlterColumn<int>(
                name: "ContactId",
                table: "LoadingPoints",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoadingScheduleId",
                table: "ClientPayments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TransportedProducts_LoadingScheduleId",
                table: "TransportedProducts",
                column: "LoadingScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportedProducts_ProductId",
                table: "TransportedProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Remitances_LoadingScheduleId",
                table: "Remitances",
                column: "LoadingScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadingSchedules_DriverId",
                table: "LoadingSchedules",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_LoadingScheduleId",
                table: "Invoices",
                column: "LoadingScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditAllocations_LoadingScheduleId",
                table: "CreditAllocations",
                column: "LoadingScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientPayments_LoadingScheduleId",
                table: "ClientPayments",
                column: "LoadingScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientPayments_LoadingSchedules_LoadingScheduleId",
                table: "ClientPayments",
                column: "LoadingScheduleId",
                principalTable: "LoadingSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditAllocations_LoadingSchedules_LoadingScheduleId",
                table: "CreditAllocations",
                column: "LoadingScheduleId",
                principalTable: "LoadingSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_LoadingSchedules_LoadingScheduleId",
                table: "Invoices",
                column: "LoadingScheduleId",
                principalTable: "LoadingSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoadingPoints_Contacts_ContactId",
                table: "LoadingPoints",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoadingSchedules_Drivers_DriverId",
                table: "LoadingSchedules",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Remitances_LoadingSchedules_LoadingScheduleId",
                table: "Remitances",
                column: "LoadingScheduleId",
                principalTable: "LoadingSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportedProducts_LoadingSchedules_LoadingScheduleId",
                table: "TransportedProducts",
                column: "LoadingScheduleId",
                principalTable: "LoadingSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportedProducts_Products_ProductId",
                table: "TransportedProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientPayments_LoadingSchedules_LoadingScheduleId",
                table: "ClientPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditAllocations_LoadingSchedules_LoadingScheduleId",
                table: "CreditAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_LoadingSchedules_LoadingScheduleId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_LoadingPoints_Contacts_ContactId",
                table: "LoadingPoints");

            migrationBuilder.DropForeignKey(
                name: "FK_LoadingSchedules_Drivers_DriverId",
                table: "LoadingSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Remitances_LoadingSchedules_LoadingScheduleId",
                table: "Remitances");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportedProducts_LoadingSchedules_LoadingScheduleId",
                table: "TransportedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportedProducts_Products_ProductId",
                table: "TransportedProducts");

            migrationBuilder.DropIndex(
                name: "IX_TransportedProducts_LoadingScheduleId",
                table: "TransportedProducts");

            migrationBuilder.DropIndex(
                name: "IX_TransportedProducts_ProductId",
                table: "TransportedProducts");

            migrationBuilder.DropIndex(
                name: "IX_Remitances_LoadingScheduleId",
                table: "Remitances");

            migrationBuilder.DropIndex(
                name: "IX_LoadingSchedules_DriverId",
                table: "LoadingSchedules");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_LoadingScheduleId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_CreditAllocations_LoadingScheduleId",
                table: "CreditAllocations");

            migrationBuilder.DropIndex(
                name: "IX_ClientPayments_LoadingScheduleId",
                table: "ClientPayments");

            migrationBuilder.DropColumn(
                name: "LoadingScheduleId",
                table: "ClientPayments");

            migrationBuilder.AlterColumn<int>(
                name: "ContactId",
                table: "LoadingPoints",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_LoadingPoints_Contacts_ContactId",
                table: "LoadingPoints",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id");
        }
    }
}
