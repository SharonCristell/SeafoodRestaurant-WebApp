using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoPM.Migrations
{
    public partial class mesas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "N_Mesas",
                table: "Sucursales",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "N_Mesas",
                table: "Sucursales");
        }
    }
}
