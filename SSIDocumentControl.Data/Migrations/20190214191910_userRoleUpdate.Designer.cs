﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SSIDocumentControl.Data;

namespace SSIDocumentControl.Data.Migrations
{
    [DbContext(typeof(DocumentContext))]
    [Migration("20190214191910_userRoleUpdate")]
    partial class userRoleUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SSIDocumentControl.Core.DocumentAuthorization.FolderRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<int>("CreateUserId");

                    b.Property<int?>("FolderId");

                    b.Property<int?>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("FolderId");

                    b.HasIndex("RoleId");

                    b.ToTable("tblDocumentControl_FolderRoles_Matrix");
                });

            modelBuilder.Entity("SSIDocumentControl.Core.DocumentAuthorization.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RoleID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("datetime");

                    b.Property<int?>("CreateUserId")
                        .HasColumnName("CreateUserID");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("RoleId");

                    b.ToTable("tblDocumentControl_Roles");
                });

            modelBuilder.Entity("SSIDocumentControl.Core.DocumentAuthorization.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<int>("CreateUserId");

                    b.Property<int?>("RoleId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("tblDocumentControl_UserRoles_Matrix");
                });

            modelBuilder.Entity("SSIDocumentControl.Core.DocumentControl.Document", b =>
                {
                    b.Property<int>("DocId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DocID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("datetime");

                    b.Property<int?>("CreateUserId")
                        .HasColumnName("CreateUserID");

                    b.Property<int?>("DocStatusId")
                        .HasColumnName("DocStatusID");

                    b.Property<string>("DocumentName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("EffectiveDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("ExpiryDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("FolderId")
                        .HasColumnName("FolderID");

                    b.Property<string>("MimeType")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("ModifiedDatetime")
                        .HasColumnType("datetime");

                    b.Property<string>("Notes")
                        .HasMaxLength(8000);

                    b.Property<string>("Path")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Revision")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("SortId")
                        .HasColumnName("SortID");

                    b.Property<DateTime?>("UploadDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Version")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("DocId")
                        .HasName("PK_tblDocumentControl_DocStatus");

                    b.HasIndex("FolderId");

                    b.ToTable("tblDocumentControl_Documents");
                });

            modelBuilder.Entity("SSIDocumentControl.Core.DocumentControl.DocumentFolder", b =>
                {
                    b.Property<int>("FolderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FolderID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("CreateUserId")
                        .HasColumnName("CreateUserID");

                    b.Property<DateTime?>("ModifiedDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .IsUnicode(false);

                    b.Property<int?>("ParentFolderId")
                        .HasColumnName("ParentFolderID");

                    b.Property<int?>("SortId")
                        .HasColumnName("SortID");

                    b.HasKey("FolderId");

                    b.HasIndex("ParentFolderId");

                    b.ToTable("tblDocumentControl_Folders");
                });

            modelBuilder.Entity("SSIDocumentControl.Core.DocumentControl.DocumentStatus", b =>
                {
                    b.Property<int>("DocStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DocStatusID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("datetime");

                    b.Property<int?>("CreateUserId")
                        .HasColumnName("CreateUserID");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("DocStatusId");

                    b.ToTable("tblDocumentControl_DocumentStatus");
                });

            modelBuilder.Entity("SSIDocumentControl.Core.RentUser", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UserID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<bool>("Active")
                        .HasColumnName("Active");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Id");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<int?>("OfficeId");

                    b.Property<string>("Password")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PASSWORD")
                        .HasColumnType("varchar(50)")
                        .HasDefaultValueSql("'NEWUSER'");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnName("USER")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserName");

                    b.HasKey("UserId")
                        .HasName("PK_usysPasswords");

                    b.HasIndex("User")
                        .IsUnique()
                        .HasName("IX_usysPasswords");

                    b.ToTable("usysPasswords");
                });

            modelBuilder.Entity("SSIDocumentControl.Core.DocumentAuthorization.FolderRole", b =>
                {
                    b.HasOne("SSIDocumentControl.Core.DocumentControl.DocumentFolder", "Folder")
                        .WithMany()
                        .HasForeignKey("FolderId");

                    b.HasOne("SSIDocumentControl.Core.DocumentAuthorization.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("SSIDocumentControl.Core.DocumentAuthorization.UserRole", b =>
                {
                    b.HasOne("SSIDocumentControl.Core.DocumentAuthorization.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("SSIDocumentControl.Core.DocumentControl.Document", b =>
                {
                    b.HasOne("SSIDocumentControl.Core.DocumentControl.DocumentFolder", "Folder")
                        .WithMany("Document")
                        .HasForeignKey("FolderId")
                        .HasConstraintName("FK_tblDocumentControl_Documents_tblDocumentControl_Documents");
                });

            modelBuilder.Entity("SSIDocumentControl.Core.DocumentControl.DocumentFolder", b =>
                {
                    b.HasOne("SSIDocumentControl.Core.DocumentControl.DocumentFolder", "ParentFolder")
                        .WithMany("InverseParentFolder")
                        .HasForeignKey("ParentFolderId")
                        .HasConstraintName("FK_tblDocumentControl_Folders_tblDocumentControl_Folders");
                });
#pragma warning restore 612, 618
        }
    }
}
