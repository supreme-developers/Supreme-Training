using System;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata;
using SSIDocumentControl.Core;
using SSIDocumentControl.Core.DocumentAuthorization;
using SSIDocumentControl.Core.DocumentControl;
using SSIDocumentControl.Core.DocumentControl.ViewModels;

namespace SSIDocumentControl.Data
{
    public partial class DocumentContext : DbContext
    {
        public virtual DbSet<RentUser> Users { get; set; }
        public virtual DbSet<DocumentStatus> DocumentStatus { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<DocumentFolder> DocumentFolder { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<FolderRole> FolderRole { get; set; }
        public virtual DbSet<MobileDocs> MobileDocs { get; set; }
        public DbQuery<RoleViewModel> RoleViewModel { get; set; }
        public DbQuery<FolderRoleViewModel> FolderRoleViewModel { get; set; }
        public DbQuery<TreeViewDocViewModel> TreeViewDocViewModel { get; set; }
        
        public DbQuery<DirectorySearchViewModel> DirectorySearchViewModel { get; set; }
        public DocumentContext(DbContextOptions<DocumentContext> options): base (options)
        {

        }

        public DocumentContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_usysPasswords");

                entity.ToTable("usysPasswords");

                entity.HasIndex(e => e.User)
                    .HasName("IX_usysPasswords")
                    .IsUnique();
                entity.Property(e => e.UserId).HasColumnName("UserID");
                entity.Property(e => e.FirstName).HasColumnType("varchar(50)");

                entity.Property(e => e.LastName).HasColumnType("varchar(50)");
                entity.Property(e => e.Active).HasColumnName("Active");
                entity.Property(e => e.Password)
                    .HasColumnName("PASSWORD")
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("'NEWUSER'");


                entity.Property(e => e.User)
                    .IsRequired()
                    .HasColumnName("USER")
                    .HasColumnType("varchar(50)");
            });
            modelBuilder.Entity<DocumentStatus>(entity =>
            {
                entity.HasKey(e => e.DocStatusId);

                entity.ToTable("tblDocumentControl_DocumentStatus");

                entity.Property(e => e.DocStatusId).HasColumnName("DocStatusID");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<MobileDocs>(entity =>
            {
                entity.ToTable("tblDocumentControl_MobileDocs");
                entity.HasKey(e => e.DocId);
            });
            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.DocId)
                    .HasName("PK_tblDocumentControl_DocStatus");

                entity.ToTable("tblDocumentControl_Documents");

                entity.Property(e => e.DocId).HasColumnName("DocID");

                entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.DocStatusId).HasColumnName("DocStatusID");

                entity.Property(e => e.DocumentName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FolderId).HasColumnName("FolderID");

                entity.Property(e => e.Path).IsUnicode(false);

                entity.Property(e => e.SortId).HasColumnName("SortID");

                entity.Property(e => e.UploadDate).HasColumnType("datetime");

                entity.Property(e => e.Version)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.FolderId)
                    .HasConstraintName("FK_tblDocumentControl_Documents_tblDocumentControl_Documents");
            });
            modelBuilder.Entity<DocumentFolder>(entity =>
            {
                entity.HasKey(e => e.FolderId);

                entity.ToTable("tblDocumentControl_Folders");

                entity.Property(e => e.FolderId).HasColumnName("FolderID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ParentFolderId).HasColumnName("ParentFolderID");

                entity.Property(e => e.SortId).HasColumnName("SortID");

                entity.HasOne(d => d.ParentFolder)
                    .WithMany(p => p.InverseParentFolder)
                    .HasForeignKey(d => d.ParentFolderId)
                    .HasConstraintName("FK_tblDocumentControl_Folders_tblDocumentControl_Folders");
            });            
        }
    }
}
