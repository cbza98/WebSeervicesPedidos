using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSUSPedido.Migrations
{
    public partial class MigraNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "OPE_USUARIO",
               
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

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OPE_USUARIOCODIGO = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_OPE_USUARIO_OPE_USUARIOCODIGO",
                        column: x => x.OPE_USUARIOCODIGO,
                        principalTable: "OPE_USUARIO",
                        principalColumn: "CODIGO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_OPE_USUARIOCODIGO",
                table: "RefreshToken",
                column: "OPE_USUARIOCODIGO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "OPE_USUARIO");
        }
    }
}
