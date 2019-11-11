using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoPM.Migrations
{
    public partial class SucursalId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SucursalId",
                table: "Reservas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_SucursalId",
                table: "Reservas",
                column: "SucursalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Sucursales_SucursalId",
                table: "Reservas",
                column: "SucursalId",
                principalTable: "Sucursales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Sucursales_SucursalId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_SucursalId",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "Reservas");
        }
    }
}
