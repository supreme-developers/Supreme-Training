using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSIDocumentControl.Data.Migrations
{
    public partial class UserrolesfolderRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblDocumentControl_FolderRoles_Matrix",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    FolderId = table.Column<int>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDocumentControl_FolderRoles_Matrix", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblDocumentControl_FolderRoles_Matrix_tblDocumentControl_Folders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "tblDocumentControl_Folders",
                        principalColumn: "FolderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblDocumentControl_FolderRoles_Matrix_tblDocumentControl_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tblDocumentControl_Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblDocumentControl_UserRoles_Matrix",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDocumentControl_UserRoles_Matrix", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblDocumentControl_UserRoles_Matrix_tblDocumentControl_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tblDocumentControl_Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblDocumentControl_UserRoles_Matrix_usysPasswords_UserId",
                        column: x => x.UserId,
                        principalTable: "usysPasswords",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblDocumentControl_FolderRoles_Matrix_FolderId",
                table: "tblDocumentControl_FolderRoles_Matrix",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDocumentControl_FolderRoles_Matrix_RoleId",
                table: "tblDocumentControl_FolderRoles_Matrix",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDocumentControl_UserRoles_Matrix_RoleId",
                table: "tblDocumentControl_UserRoles_Matrix",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDocumentControl_UserRoles_Matrix_UserId",
                table: "tblDocumentControl_UserRoles_Matrix",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblDocumentControl_FolderRoles_Matrix");

            migrationBuilder.DropTable(
                name: "tblDocumentControl_UserRoles_Matrix");
        }
    }
}
