using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class shops3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItem_Foods_foodId",
                table: "ShopCartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopCartItem",
                table: "ShopCartItem");

            migrationBuilder.RenameTable(
                name: "ShopCartItem",
                newName: "ShopCartItems");

            migrationBuilder.RenameIndex(
                name: "IX_ShopCartItem_foodId",
                table: "ShopCartItems",
                newName: "IX_ShopCartItems_foodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopCartItems",
                table: "ShopCartItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItems_Foods_foodId",
                table: "ShopCartItems",
                column: "foodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItems_Foods_foodId",
                table: "ShopCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopCartItems",
                table: "ShopCartItems");

            migrationBuilder.RenameTable(
                name: "ShopCartItems",
                newName: "ShopCartItem");

            migrationBuilder.RenameIndex(
                name: "IX_ShopCartItems_foodId",
                table: "ShopCartItem",
                newName: "IX_ShopCartItem_foodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopCartItem",
                table: "ShopCartItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItem_Foods_foodId",
                table: "ShopCartItem",
                column: "foodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
