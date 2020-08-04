using System;
using System.Collections.Generic;
using System.Text;

namespace SSIDocumentControl.Core.DocumentControl
{
  public  class DirectorySearchViewModel
    {
        public int? FolderID { get; set; }
        public string Name { get; set; }
        public int? ParentFolderId { get; set; }
        public int? DocumentId { get; set; }
        public string SearchType { get; set; }
        public string Icon { get; set; }
        public string DocumentNumber { get; set; }
    }
}
