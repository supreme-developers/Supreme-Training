using Microsoft.AspNetCore.Mvc;
using SSIDocumentControl.Core.DocumentControl;
using SSIDocumentControl.Models;
using SSIDocumentControl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIDocumentControl.ViewComponents
{
    public class AdminDirectoryViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(FolderItemsViewModel folderItems)
        {
            //int pageSize = 2;
            //var pagedFolders = await PaginatedList<DocumentFolder>
            //                .CreateAsync(folderItems.Folders.ToList().Union(folderItems.Documents.ToList()).ToList(), folderItems.PageId ?? 1, pageSize);

            //folderItems.Folders = pagedFolders;

            return View("AdminDirectory", folderItems);
        }
    }
}
