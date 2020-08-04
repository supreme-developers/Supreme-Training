using SSIDocumentControl.Core.DocumentControl;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSIDocumentControl.Core.DocumentAuthorization
{
    [Table("tblDocumentControl_FolderRoles_Matrix")]
    public class FolderRole
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        [ForeignKey("FolderId")]
        public int FolderId { get; set;  }
        public virtual DocumentFolder Folder { get; set; }

        public DateTime CreateDateTime { get; set; }
        public int CreateUserId { get; set; }


    }
}
