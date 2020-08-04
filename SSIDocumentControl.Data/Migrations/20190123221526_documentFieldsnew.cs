using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSIDocumentControl.Data.Migrations
{
    public partial class documentFieldsnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentNumber",
                table: "tblDocumentControl_Documents",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EffectiveDate",
                table: "tblDocumentControl_Documents",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "tblDocumentControl_Documents",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MimeType",
                table: "tblDocumentControl_Documents",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "tblDocumentControl_Documents",
                maxLength: 8000,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "tblDocumentControl_Documents",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Revision",
                table: "tblDocumentControl_Documents",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentNumber",
                table: "tblDocumentControl_Documents");

            migrationBuilder.DropColumn(
                name: "EffectiveDate",
                table: "tblDocumentControl_Documents");

            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "tblDocumentControl_Documents");

            migrationBuilder.DropColumn(
                name: "MimeType",
                table: "tblDocumentControl_Documents");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "tblDocumentControl_Documents");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "tblDocumentControl_Documents");

            migrationBuilder.DropColumn(
                name: "Revision",
                table: "tblDocumentControl_Documents");
        }
    }
}
