using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSUSPedido.Migrations
{
    public partial class CopTitoDemo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TIPO_CAMBIO",
                table: "OPE_USUARIO",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TIPO_CAMBIO",
                table: "OPE_USUARIO");
        }
    }
}
