using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSIDocumentControl.Core.DocumentAuthorization
{
   public class FolderRoleViewModel
    {
        public string FolderName { get; set; }
        public int FolderId { get; set; }
        public bool Assigned { get; set; }
        public int? RoleId { get; set; }
        [NotMapped]
        public string NameWIcon
        {
            get { return "fas fa-folder text-warning fa-2x";  }
        }
    }
}
