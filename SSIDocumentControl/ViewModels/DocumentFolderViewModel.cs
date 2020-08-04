using SSIDocumentControl.Core;
using SSIDocumentControl.Core.DocumentAuthorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSIDocumentControl.ViewModels
{
    public class DocumentFolderViewModel
    {
        public int? FolderId { get; set; }
        [Required]
        [Display(Name = "Folder Name")]
        public string FolderName { get; set; }
        public int? ParentFolderId { get; set; }
        public string OldFolderName { get; set; }
        public int FolderStatusId { get; set; }

    }
}
