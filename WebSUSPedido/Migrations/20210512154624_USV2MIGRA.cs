using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSUSPedido.Migrations
{
    public partial class USV2MIGRA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_Users_Ope_Usuario_MobileId",
                table: "RefreshToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "OPE_USER_MOBILE");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OPE_USER_MOBILE",
                table: "OPE_USER_MOBILE",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_OPE_USER_MOBILE_Ope_Usuario_MobileId",
                table: "RefreshToken",
                column: "Ope_Usuario_MobileId",
                principalTable: "OPE_USER_MOBILE",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_OPE_USER_MOBILE_Ope_Usuario_MobileId",
                table: "RefreshToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OPE_USER_MOBILE",
                table: "OPE_USER_MOBILE");

            migrationBuilder.RenameTable(
                name: "OPE_USER_MOBILE",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_Users_Ope_Usuario_MobileId",
                table: "RefreshToken",
                column: "Ope_Usuario_MobileId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
