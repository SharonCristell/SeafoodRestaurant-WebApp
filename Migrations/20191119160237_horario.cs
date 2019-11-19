using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoPM.Migrations
{
    public partial class horario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Fecha",
                table: "Reservas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Horario",
                table: "Reservas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Mesa",
                table: "Reservas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Horario",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Mesa",
                table: "Reservas");
        }
    }
}
