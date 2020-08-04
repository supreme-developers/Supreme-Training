using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSIDocumentControl.Core.DocumentAuthorization
{
    [Table("tblDocumentControl_UserRoles_Matrix")]
    public class UserRole
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public DateTime CreateDateTime { get; set; }
        public int CreateUserId { get; set; }
    }
}
