using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSIDocumentControl.ViewModels
{
    public class RolesViewModel
    {
        public int RoleId { get; set; }
        [StringLength(100)]      
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }

        [Display(Name = "Total Cabinets")]
        public int TotalCabinetFolders { get; set; }

        [Display(Name = "Total Members")]
        public int TotalMembers { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
    }
}
