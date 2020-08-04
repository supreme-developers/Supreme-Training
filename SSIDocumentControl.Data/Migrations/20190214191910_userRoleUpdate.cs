using Microsoft.EntityFrameworkCore.Migrations;

namespace SSIDocumentControl.Data.Migrations
{
    public partial class userRoleUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblDocumentControl_UserRoles_Matrix_usysPasswords_UserId",
                table: "tblDocumentControl_UserRoles_Matrix");

            migrationBuilder.DropIndex(
                name: "IX_tblDocumentControl_UserRoles_Matrix_UserId",
                table: "tblDocumentControl_UserRoles_Matrix");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "tblDocumentControl_UserRoles_Matrix",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "tblDocumentControl_UserRoles_Matrix",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_tblDocumentControl_UserRoles_Matrix_UserId",
                table: "tblDocumentControl_UserRoles_Matrix",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblDocumentControl_UserRoles_Matrix_usysPasswords_UserId",
                table: "tblDocumentControl_UserRoles_Matrix",
                column: "UserId",
                principalTable: "usysPasswords",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
