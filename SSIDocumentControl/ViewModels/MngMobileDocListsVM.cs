using SSIDocumentControl.Core.DocumentControl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIDocumentControl.ViewModels
{
    public class MngMobileDocListsVM
    {
        public List<DocVM> NonMobileDocs { get; set; }
        public List<DocVM> MobileDocs { get; set; }
        public string AssignedMobileDocs { get; set; }
    }
}
