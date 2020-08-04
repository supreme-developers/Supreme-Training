using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSIDocumentControl.Data.Migrations
{
    public partial class Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Revision",
                table: "tblDocumentControl_Documents",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "tblDocumentControl_Documents",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentNumber",
                table: "tblDocumentControl_Documents",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentName",
                table: "tblDocumentControl_Documents",
                unicode: false,
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "tblDocumentControl_Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateUserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDocumentControl_Roles", x => x.RoleID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblDocumentControl_Roles");

            migrationBuilder.AlterColumn<string>(
                name: "Revision",
                table: "tblDocumentControl_Documents",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "tblDocumentControl_Documents",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentNumber",
                table: "tblDocumentControl_Documents",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentName",
                table: "tblDocumentControl_Documents",
                unicode: false,
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 500);
        }
    }
}
