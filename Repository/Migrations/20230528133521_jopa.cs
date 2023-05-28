using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class jopa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Foods_foodID",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_orderID",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "orderID",
                table: "OrderDetails",
                newName: "orderId");

            migrationBuilder.RenameColumn(
                name: "foodID",
                table: "OrderDetails",
                newName: "foodId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_orderID",
                table: "OrderDetails",
                newName: "IX_OrderDetails_orderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_foodID",
                table: "OrderDetails",
                newName: "IX_OrderDetails_foodId");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Orders",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Foods_foodId",
                table: "OrderDetails",
                column: "foodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_orderId",
                table: "OrderDetails",
                column: "orderId",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Foods_foodId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_orderId",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "orderId",
                table: "OrderDetails",
                newName: "orderID");

            migrationBuilder.RenameColumn(
                name: "foodId",
                table: "OrderDetails",
                newName: "foodID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_orderId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_orderID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_foodId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_foodID");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Foods_foodID",
                table: "OrderDetails",
                column: "foodID",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_orderID",
                table: "OrderDetails",
                column: "orderID",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
