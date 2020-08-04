using System;
using System.Collections.Generic;
using System.Text;

namespace SSIDocumentControl.Core.DocumentControl
{
   public class TreeViewDocViewModel
    {
        public int ID { get; set; }
        public int? ParentFolderID { get; set; }
        public string Name { get; set; }
        public int? SortID { get; set; }
        public int Level { get; set; }
        public string Icon { get; set; }
        public string Path { get; set; }
        public bool HasChild { get; set; }
        public bool? Expanded { get; set; }

    }
}
