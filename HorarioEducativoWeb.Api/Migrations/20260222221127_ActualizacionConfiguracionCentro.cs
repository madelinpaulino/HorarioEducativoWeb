using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HorarioEducativoWeb.API.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionConfiguracionCentro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horarios_Docentes_DocenteId",
                table: "Horarios");

            migrationBuilder.AddColumn<int>(
                name: "DocenteId1",
                table: "Horarios",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Grupos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Modalidad",
                value: "Técnico en Informática");

            migrationBuilder.UpdateData(
                table: "Horarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "DocenteId1",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_DocenteId1",
                table: "Horarios",
                column: "DocenteId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Horarios_Docentes_DocenteId",
                table: "Horarios",
                column: "DocenteId",
                principalTable: "Docentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Horarios_Docentes_DocenteId1",
                table: "Horarios",
                column: "DocenteId1",
                principalTable: "Docentes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horarios_Docentes_DocenteId",
                table: "Horarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Horarios_Docentes_DocenteId1",
                table: "Horarios");

            migrationBuilder.DropIndex(
                name: "IX_Horarios_DocenteId1",
                table: "Horarios");

            migrationBuilder.DropColumn(
                name: "DocenteId1",
                table: "Horarios");

            migrationBuilder.UpdateData(
                table: "Grupos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Modalidad",
                value: "Media");

            migrationBuilder.AddForeignKey(
                name: "FK_Horarios_Docentes_DocenteId",
                table: "Horarios",
                column: "DocenteId",
                principalTable: "Docentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
