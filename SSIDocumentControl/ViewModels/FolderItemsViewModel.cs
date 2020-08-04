using SSIDocumentControl.Core.DocumentControl;
using SSIDocumentControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIDocumentControl.ViewModels
{
    public class FolderItemsViewModel
    {
        public IEnumerable<DocumentFolder> Folders { get; set; }
        public IEnumerable<Document> Documents { get; set; }
        public DocumentFolder ParentFolder { get; set; }
        public IEnumerable<FolderCrumbs> PathCrumbs { get; set; }
        public IEnumerable<DirectorySearchViewModel> DirectorySearchViewModel { get; set; }
        public int? SearchFolderId { get; set; }
        public int? SearchDocId { get; set; }
        public int? PageId { get; set; }

    }
}
