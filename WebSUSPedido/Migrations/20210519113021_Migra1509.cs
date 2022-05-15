using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSUSPedido.Migrations
{
    public partial class Migra1509 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_OPE_USER_MOBILE_Ope_Usuario_MobileId",
                table: "RefreshToken");

            migrationBuilder.DropTable(
                name: "OPE_USER_MOBILE");

            migrationBuilder.DropIndex(
                name: "IX_RefreshToken_Ope_Usuario_MobileId",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "Ope_Usuario_MobileId",
                table: "RefreshToken");

            migrationBuilder.AddColumn<string>(
                name: "OPE_USUARIOCODIGO",
                table: "RefreshToken",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "OPE_USUARIO",
                columns: table => new
                {
                    CODIGO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NOMBRE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CODIGO_EMPRESA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA35 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPE_USUARIO", x => x.CODIGO);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_OPE_USUARIOCODIGO",
                table: "RefreshToken",
                column: "OPE_USUARIOCODIGO");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_OPE_USUARIO_OPE_USUARIOCODIGO",
                table: "RefreshToken",
                column: "OPE_USUARIOCODIGO",
                principalTable: "OPE_USUARIO",
                principalColumn: "CODIGO",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_OPE_USUARIO_OPE_USUARIOCODIGO",
                table: "RefreshToken");

            migrationBuilder.DropTable(
                name: "OPE_USUARIO");

            migrationBuilder.DropIndex(
                name: "IX_RefreshToken_OPE_USUARIOCODIGO",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "OPE_USUARIOCODIGO",
                table: "RefreshToken");

            migrationBuilder.AddColumn<int>(
                name: "Ope_Usuario_MobileId",
                table: "RefreshToken",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OPE_USER_MOBILE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPE_USER_MOBILE", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_Ope_Usuario_MobileId",
                table: "RefreshToken",
                column: "Ope_Usuario_MobileId");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_OPE_USER_MOBILE_Ope_Usuario_MobileId",
                table: "RefreshToken",
                column: "Ope_Usuario_MobileId",
                principalTable: "OPE_USER_MOBILE",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
