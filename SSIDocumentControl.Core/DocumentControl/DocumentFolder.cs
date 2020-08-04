using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSIDocumentControl.Core.DocumentControl
{
    [Table("tblDocumentControl_Folders")]
    public partial class DocumentFolder
    {
        public DocumentFolder()
        {
            InverseParentFolder = new HashSet<DocumentFolder>();
            Document = new HashSet<Document>();
        }

        [Key]
        [Column("FolderID")]
        public int FolderId { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        [Column("SortID")]
        public int? SortId { get; set; }
        [Column("ParentFolderID")]
        public int? ParentFolderId { get; set; }
        [Column("CreateUserID")]
        public int? CreateUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "datetime")]
        [Display(Name= "Modified")]
        public DateTime? ModifiedDateTime { get; set; }

        [Column("FolderStatusID")]
        public int? FolderStatusId { get; set; }

        [ForeignKey("ParentFolderId")]
        [InverseProperty("InverseParentFolder")]
        public virtual DocumentFolder ParentFolder { get; set; }
        [InverseProperty("ParentFolder")]
        public virtual ICollection<DocumentFolder> InverseParentFolder { get; set; }
        [InverseProperty("Folder")]
        public virtual ICollection<Document> Document { get; set; }
    }
}