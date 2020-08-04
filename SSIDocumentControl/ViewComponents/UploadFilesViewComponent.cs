using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIDocumentControl.ViewComponents
{
    public class UploadFilesViewComponent:ViewComponent
    {
        public UploadFilesViewComponent()
        {
             
        }

        public IViewComponentResult Invoke(int? parentFolderId)
        {
            return View("UploadFiles",parentFolderId);
        }
    }
}
