using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSIDocumentControl.Core.DocumentAuthorization
{
  public class RoleViewModel
    {
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
        [Display(Name = "Total Cabinets")]
        public int? TotalCabinetFolders { get; set; }

        [Display(Name = "Total Members")]
        public int? TotalMembers { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
    }
}
