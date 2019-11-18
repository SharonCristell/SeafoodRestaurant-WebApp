using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoPM.Migrations
{
    public partial class CambioBDPed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidosProductos");

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "Pedidos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "Pedidos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ProductoId",
                table: "Pedidos",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Productos_ProductoId",
                table: "Pedidos",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Productos_ProductoId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ProductoId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Pedidos");

            migrationBuilder.CreateTable(
                name: "PedidosProductos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CantidadProd = table.Column<int>(nullable: false),
                    MontoProd = table.Column<double>(nullable: false),
                    PedidoId = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosProductos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidosProductos_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidosProductos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidosProductos_PedidoId",
                table: "PedidosProductos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosProductos_ProductoId",
                table: "PedidosProductos",
                column: "ProductoId");
        }
    }
}
