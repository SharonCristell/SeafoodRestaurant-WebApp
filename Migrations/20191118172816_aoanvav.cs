using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoPM.Migrations
{
    public partial class aoanvav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "Compras",
                newName: "UserName");

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "Compras",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ProductoId",
                table: "Compras",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Productos_ProductoId",
                table: "Compras",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Productos_ProductoId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_ProductoId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Compras");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Compras",
                newName: "IdCliente");
        }
    }
}
