using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSIDocumentControl.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "tblDocumentControl_DocumentStatus",
            //    columns: table => new
            //    {
            //        DocStatusID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Description = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        Code = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
            //        CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
            //        CreateUserID = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tblDocumentControl_DocumentStatus", x => x.DocStatusID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tblDocumentControl_Folders",
            //    columns: table => new
            //    {
            //        FolderID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
            //        SortID = table.Column<int>(nullable: true),
            //        ParentFolderID = table.Column<int>(nullable: true),
            //        CreateUserID = table.Column<int>(nullable: true),
            //        CreateDate = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tblDocumentControl_Folders", x => x.FolderID);
            //        table.ForeignKey(
            //            name: "FK_tblDocumentControl_Folders_tblDocumentControl_Folders",
            //            column: x => x.ParentFolderID,
            //            principalTable: "tblDocumentControl_Folders",
            //            principalColumn: "FolderID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "usysPasswords",
            //    columns: table => new
            //    {
            //        UserID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Id = table.Column<string>(nullable: true),
            //        UserName = table.Column<string>(nullable: true),
            //        NormalizedUserName = table.Column<string>(nullable: true),
            //        Email = table.Column<string>(nullable: true),
            //        NormalizedEmail = table.Column<string>(nullable: true),
            //        EmailConfirmed = table.Column<bool>(nullable: false),
            //        PasswordHash = table.Column<string>(nullable: true),
            //        SecurityStamp = table.Column<string>(nullable: true),
            //        ConcurrencyStamp = table.Column<string>(nullable: true),
            //        PhoneNumber = table.Column<string>(nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
            //        LockoutEnabled = table.Column<bool>(nullable: false),
            //        AccessFailedCount = table.Column<int>(nullable: false),
            //        USER = table.Column<string>(type: "varchar(50)", nullable: false),
            //        PASSWORD = table.Column<string>(type: "varchar(50)", nullable: true, defaultValueSql: "'NEWUSER'"),
            //        FirstName = table.Column<string>(type: "varchar(50)", nullable: true),
            //        LastName = table.Column<string>(type: "varchar(50)", nullable: true),
            //        OfficeId = table.Column<int>(nullable: true),
            //        Active = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_usysPasswords", x => x.UserID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tblDocumentControl_Documents",
            //    columns: table => new
            //    {
            //        DocID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Version = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        DocumentName = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
            //        UploadDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        Path = table.Column<string>(unicode: false, nullable: true),
            //        SortID = table.Column<int>(nullable: true),
            //        DocStatusID = table.Column<int>(nullable: true),
            //        FolderID = table.Column<int>(nullable: true),
            //        CreateUserID = table.Column<int>(nullable: true),
            //        CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tblDocumentControl_DocStatus", x => x.DocID);
            //        table.ForeignKey(
            //            name: "FK_tblDocumentControl_Documents_tblDocumentControl_Documents",
            //            column: x => x.FolderID,
            //            principalTable: "tblDocumentControl_Folders",
            //            principalColumn: "FolderID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_tblDocumentControl_Documents_FolderID",
            //    table: "tblDocumentControl_Documents",
            //    column: "FolderID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tblDocumentControl_Folders_ParentFolderID",
            //    table: "tblDocumentControl_Folders",
            //    column: "ParentFolderID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_usysPasswords",
            //    table: "usysPasswords",
            //    column: "USER",
            //    unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "tblDocumentControl_Documents");

            //migrationBuilder.DropTable(
            //    name: "tblDocumentControl_DocumentStatus");

            //migrationBuilder.DropTable(
            //    name: "usysPasswords");

            //migrationBuilder.DropTable(
            //    name: "tblDocumentControl_Folders");
        }
    }
}
