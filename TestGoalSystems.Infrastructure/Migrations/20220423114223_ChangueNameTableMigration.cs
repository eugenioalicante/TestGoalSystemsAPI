using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestGoalSystems.Infrastructure.Migrations
{
    public partial class ChangueNameTableMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_TypeInventory_TypeInventoryId",
                table: "Inventory");

            migrationBuilder.RenameColumn(
                name: "TypeInventoryId",
                table: "Inventory",
                newName: "InventoryTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_TypeInventoryId",
                table: "Inventory",
                newName: "IX_Inventory_InventoryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_TypeInventory_InventoryTypeId",
                table: "Inventory",
                column: "InventoryTypeId",
                principalTable: "TypeInventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_TypeInventory_InventoryTypeId",
                table: "Inventory");

            migrationBuilder.RenameColumn(
                name: "InventoryTypeId",
                table: "Inventory",
                newName: "TypeInventoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_InventoryTypeId",
                table: "Inventory",
                newName: "IX_Inventory_TypeInventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_TypeInventory_TypeInventoryId",
                table: "Inventory",
                column: "TypeInventoryId",
                principalTable: "TypeInventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
