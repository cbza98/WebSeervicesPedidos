using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSUSPedido.Migrations
{
    public partial class New1905 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OPE_USUARIO",
                columns: table => new
                {
                    CODIGO_EMPRESA = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CODIGO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NOMBRE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SUPERUSUARIO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ADMINISTRADOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONTRASENA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ESTADO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CAJERO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USUARIO_CREACION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FECHA_CREACION = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USUARIO_MODIFICACION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FECHA_MODIFICACION = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IMAGEN1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA12 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA13 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA14 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA15 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA16 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA17 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA18 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA19 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA20 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA21 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA22 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA23 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA24 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA25 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA26 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA27 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA28 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA29 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA30 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA31 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA32 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA33 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA34 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REFERENCIA35 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPE_USUARIO", x => x.CODIGO_EMPRESA);
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
                    OPE_USUARIOCODIGO_EMPRESA = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_OPE_USUARIO_OPE_USUARIOCODIGO_EMPRESA",
                        column: x => x.OPE_USUARIOCODIGO_EMPRESA,
                        principalTable: "OPE_USUARIO",
                        principalColumn: "CODIGO_EMPRESA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_OPE_USUARIOCODIGO_EMPRESA",
                table: "RefreshToken",
                column: "OPE_USUARIOCODIGO_EMPRESA");
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
