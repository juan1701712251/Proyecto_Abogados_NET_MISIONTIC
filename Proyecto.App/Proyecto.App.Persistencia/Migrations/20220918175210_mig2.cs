using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto.App.Persistencia.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ciudadId",
                table: "Clientes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "paisId",
                table: "Clientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    ciudadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreCiudad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.ciudadId);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    paisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombrePais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.paisId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ciudadId",
                table: "Clientes",
                column: "ciudadId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_paisId",
                table: "Clientes",
                column: "paisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Ciudad_ciudadId",
                table: "Clientes",
                column: "ciudadId",
                principalTable: "Ciudad",
                principalColumn: "ciudadId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Pais_paisId",
                table: "Clientes",
                column: "paisId",
                principalTable: "Pais",
                principalColumn: "paisId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Ciudad_ciudadId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Pais_paisId",
                table: "Clientes");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_ciudadId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_paisId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ciudadId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "paisId",
                table: "Clientes");
        }
    }
}
