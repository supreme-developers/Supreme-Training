using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSIDocumentControl.Data.Migrations
{
    public partial class modifiedTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "tblDocumentControl_Folders",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDatetime",
                table: "tblDocumentControl_Documents",
                type: "datetime",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "tblDocumentControl_Folders");

            migrationBuilder.DropColumn(
                name: "ModifiedDatetime",
                table: "tblDocumentControl_Documents");
        }
    }
}
