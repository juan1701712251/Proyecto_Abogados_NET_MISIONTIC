using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto.App.Persistencia.Migrations
{
    public partial class Prueba3_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abogados",
                columns: table => new
                {
                    abogadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    numeroTarjetaProf = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    anioIngreso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abogados", x => x.abogadoId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    clienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    edad = table.Column<int>(type: "int", nullable: false),
                    genero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.clienteId);
                });

            migrationBuilder.CreateTable(
                name: "FaseCasos",
                columns: table => new
                {
                    faseCasoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreFase = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaseCasos", x => x.faseCasoId);
                });

            migrationBuilder.CreateTable(
                name: "Casos",
                columns: table => new
                {
                    casoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clienteId = table.Column<int>(type: "int", nullable: true),
                    abogadoId = table.Column<int>(type: "int", nullable: true),
                    faseCasoId = table.Column<int>(type: "int", nullable: true),
                    fechaInicioCaso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    descripcionCaso = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    cantidadTestigos = table.Column<int>(type: "int", nullable: false),
                    direccionJuzgadoAsignado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casos", x => x.casoId);
                    table.ForeignKey(
                        name: "FK_Casos_Abogados_abogadoId",
                        column: x => x.abogadoId,
                        principalTable: "Abogados",
                        principalColumn: "abogadoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Casos_Clientes_clienteId",
                        column: x => x.clienteId,
                        principalTable: "Clientes",
                        principalColumn: "clienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Casos_FaseCasos_faseCasoId",
                        column: x => x.faseCasoId,
                        principalTable: "FaseCasos",
                        principalColumn: "faseCasoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Casos_abogadoId",
                table: "Casos",
                column: "abogadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Casos_clienteId",
                table: "Casos",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Casos_faseCasoId",
                table: "Casos",
                column: "faseCasoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Casos");

            migrationBuilder.DropTable(
                name: "Abogados");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "FaseCasos");
        }
    }
}
