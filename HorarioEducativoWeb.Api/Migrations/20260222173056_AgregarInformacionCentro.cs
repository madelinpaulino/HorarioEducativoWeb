using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HorarioEducativoWeb.API.Migrations
{
    /// <inheritdoc />
    public partial class AgregarInformacionCentro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "InformacionCentro",
                columns: new[] { "Id", "Direccion", "Nombre", "RNC" },
                values: new object[] { 1, "Av. Principal #123, Ciudad Educativa", "Centro Educativo Central", "101-00000-1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InformacionCentro",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
