using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSIDocumentControl.Core.DocumentControl
{
    [Table("tblDocumentControl_DocumentStatus")]
    public partial class DocumentStatus
    {
        [Key]
        [Column("DocStatusID")]
        public int DocStatusId { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(10)]
        public string Code { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDateTime { get; set; }
        [Column("CreateUserID")]
        public int? CreateUserId { get; set; }
    }
}