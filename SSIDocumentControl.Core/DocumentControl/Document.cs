using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSIDocumentControl.Core.DocumentControl
{
    [Table("tblDocumentControl_Documents")]
    public partial class Document
    {
        [Column("DocID")]
        public int DocId { get; set; }
        [StringLength(50)]
        [Required]
        [Display(Name = "Document Number")]
        public string DocumentNumber { get; set; }
        [StringLength(50)]
        public string Version { get; set; }
        [StringLength(50)]
        [Required]
        public string Revision { get; set; }
        [StringLength(255)]
        public string MimeType { get; set; }
        [StringLength(500)]
        [Required]
        [Display(Name = "Title")]
        public string DocumentName { get; set; }
        [StringLength(8000)]
        public string Notes { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UploadDate { get; set; }
        [Display(Name = "Choose a File")]
        [Required]
        public string Path { get; set; }
        [Column("SortID")]
        public int? SortId { get; set; }
        [Column("DocStatusID")]
        public int? DocStatusId { get; set; }
        [Column("FolderID")]
        public int? FolderId { get; set; }
        [Column("CreateUserID")]
        public int? CreateUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ReleaseDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExpiryDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EffectiveDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDatetime { get; set; }

        [NotMapped]
        [Display(Name ="Send Notifications")]
        public bool SendNotification { get; set; }
        [ForeignKey("FolderId")]
        [InverseProperty("Document")]
        public virtual DocumentFolder Folder { get; set; }
    }
}