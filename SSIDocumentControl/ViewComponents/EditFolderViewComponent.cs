using Microsoft.AspNetCore.Mvc;
using SSIDocumentControl.Repositories;
using SSIDocumentControl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIDocumentControl.ViewComponents
{
    public class EditFolderViewComponent: ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditFolderViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IViewComponentResult> InvokeAsync(int folderId)
        {
            var folder = await _unitOfWork.Documents.GetFolderByIdAsync(folderId);
            var docFolder = new DocumentFolderViewModel();
            docFolder.FolderName = folder.Name;
            docFolder.OldFolderName = folder.Name;
            docFolder.FolderId = folder.FolderId;
            docFolder.ParentFolderId = folder.ParentFolderId;
            docFolder.FolderStatusId = Convert.ToInt32(folder.FolderStatusId);
            return View("EditFolder", docFolder);
        }
    }
}
