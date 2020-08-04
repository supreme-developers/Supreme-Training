using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSIDocumentControl.Core.DocumentAuthorization
{
    [Table("tblDocumentControl_Roles")]
   public class Role
    {
        [Key]
        [Column("RoleID")]
        public int RoleId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "datetime")]        
        public DateTime? CreateDateTime { get; set; }

        [Column("CreateUserID")]
        public int? CreateUserId { get; set; }
    }
}
