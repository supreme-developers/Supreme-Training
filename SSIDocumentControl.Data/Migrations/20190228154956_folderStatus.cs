using Microsoft.EntityFrameworkCore.Migrations;

namespace SSIDocumentControl.Data.Migrations
{
    public partial class folderStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblDocumentControl_FolderRoles_Matrix_tblDocumentControl_Folders_FolderId",
                table: "tblDocumentControl_FolderRoles_Matrix");

            migrationBuilder.AddColumn<int>(
                name: "FolderStatusID",
                table: "tblDocumentControl_Folders",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FolderId",
                table: "tblDocumentControl_FolderRoles_Matrix",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tblDocumentControl_FolderRoles_Matrix_tblDocumentControl_Folders_FolderId",
                table: "tblDocumentControl_FolderRoles_Matrix",
                column: "FolderId",
                principalTable: "tblDocumentControl_Folders",
                principalColumn: "FolderID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblDocumentControl_FolderRoles_Matrix_tblDocumentControl_Folders_FolderId",
                table: "tblDocumentControl_FolderRoles_Matrix");

            migrationBuilder.DropColumn(
                name: "FolderStatusID",
                table: "tblDocumentControl_Folders");

            migrationBuilder.AlterColumn<int>(
                name: "FolderId",
                table: "tblDocumentControl_FolderRoles_Matrix",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_tblDocumentControl_FolderRoles_Matrix_tblDocumentControl_Folders_FolderId",
                table: "tblDocumentControl_FolderRoles_Matrix",
                column: "FolderId",
                principalTable: "tblDocumentControl_Folders",
                principalColumn: "FolderID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
