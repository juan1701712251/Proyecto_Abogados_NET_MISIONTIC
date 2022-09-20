using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto.App.Persistencia.Migrations
{
    public partial class paises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Pais_paisId",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pais",
                table: "Pais");

            migrationBuilder.RenameTable(
                name: "Pais",
                newName: "Paises");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Paises",
                table: "Paises",
                column: "paisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Paises_paisId",
                table: "Clientes",
                column: "paisId",
                principalTable: "Paises",
                principalColumn: "paisId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Paises_paisId",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Paises",
                table: "Paises");

            migrationBuilder.RenameTable(
                name: "Paises",
                newName: "Pais");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pais",
                table: "Pais",
                column: "paisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Pais_paisId",
                table: "Clientes",
                column: "paisId",
                principalTable: "Pais",
                principalColumn: "paisId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
