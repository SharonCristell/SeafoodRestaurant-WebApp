using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoPM.Migrations
{
    public partial class ReservaModificacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Reservas",
                nullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Precio",
                table: "Productos",
                nullable: false,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Reservas");

            migrationBuilder.AlterColumn<double>(
                name: "Precio",
                table: "Productos",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
