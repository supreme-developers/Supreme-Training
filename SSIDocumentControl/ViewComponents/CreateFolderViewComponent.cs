using Microsoft.AspNetCore.Mvc;
using SSIDocumentControl.Core.DocumentControl;
using SSIDocumentControl.Repositories;
using SSIDocumentControl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using SSIDocumentControl.Models.SystemModels;

namespace SSIDocumentControl.ViewComponents
{
   
    public class CreateFolderViewComponent: ViewComponent
    {

        public CreateFolderViewComponent(IUnitOfWork unitOfWork, IUserSession userSession)
        {
        }
        
        public  IViewComponentResult Invoke()
        {
            var folder = new DocumentFolderViewModel();
            var qsFolderId = HttpContext.Request.Query["id"].ToString();
            int folderId = 0;
            var folderIdString = qsFolderId != "" ? qsFolderId : HttpContext.Request.Path.ToString().Split('/').Last();

            
            Int32.TryParse(folderIdString, out folderId);
            //getID here in case searched by id
            if (folderId > 0)
                folder.ParentFolderId = Convert.ToInt32(folderId);

            return View("CreateFolder",folder);
            
        }
    }
}
