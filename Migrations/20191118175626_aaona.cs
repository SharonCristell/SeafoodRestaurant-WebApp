using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoPM.Migrations
{
    public partial class aaona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Productos_ProductoId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "IdProduct",
                table: "Compras");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "Compras",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Productos_ProductoId",
                table: "Compras",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Productos_ProductoId",
                table: "Compras");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "Compras",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IdProduct",
                table: "Compras",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Productos_ProductoId",
                table: "Compras",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
