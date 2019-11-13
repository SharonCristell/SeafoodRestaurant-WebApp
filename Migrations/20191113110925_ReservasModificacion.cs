using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoPM.Migrations
{
    public partial class ReservasModificacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Distrito",
                table: "Sucursales",
                newName: "Foto");

            migrationBuilder.AddColumn<int>(
                name: "DistritoId",
                table: "Sucursales",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Distritos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distritos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sucursales_DistritoId",
                table: "Sucursales",
                column: "DistritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sucursales_Distritos_DistritoId",
                table: "Sucursales",
                column: "DistritoId",
                principalTable: "Distritos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sucursales_Distritos_DistritoId",
                table: "Sucursales");

            migrationBuilder.DropTable(
                name: "Distritos");

            migrationBuilder.DropIndex(
                name: "IX_Sucursales_DistritoId",
                table: "Sucursales");

            migrationBuilder.DropColumn(
                name: "DistritoId",
                table: "Sucursales");

            migrationBuilder.RenameColumn(
                name: "Foto",
                table: "Sucursales",
                newName: "Distrito");
        }
    }
}
