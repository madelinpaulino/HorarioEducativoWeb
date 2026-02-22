using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HorarioEducativoWeb.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Asignaturas",
                columns: new[] { "Id", "HorasSemanales", "Nombre" },
                values: new object[,]
                {
                    { 1, 4, "Álgebra Lineal" },
                    { 2, 6, "Desarrollo Web con .NET" }
                });

            migrationBuilder.InsertData(
                table: "Aulas",
                columns: new[] { "Id", "Codigo" },
                values: new object[,]
                {
                    { 1, "Lab-101" },
                    { 2, "Aula-202" }
                });

            migrationBuilder.InsertData(
                table: "Docentes",
                columns: new[] { "Id", "Especialidad", "Nombre" },
                values: new object[,]
                {
                    { 1, "Matemáticas", "Juan Pérez" },
                    { 2, "Programación", "María García" }
                });

            migrationBuilder.InsertData(
                table: "Grupos",
                columns: new[] { "Id", "Modalidad", "Nombre" },
                values: new object[] { 1, "Media", "4to de Media" });

            migrationBuilder.InsertData(
                table: "Horarios",
                columns: new[] { "Id", "AsignaturaId", "AulaId", "DiaSemana", "DocenteId", "GrupoId", "HoraFin", "HoraInicio" },
                values: new object[] { 1, 1, 1, "Lunes", 1, 1, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Asignaturas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Aulas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Docentes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Asignaturas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Aulas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Docentes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Grupos",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
