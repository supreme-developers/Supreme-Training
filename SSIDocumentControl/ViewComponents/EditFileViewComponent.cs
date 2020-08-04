using Microsoft.AspNetCore.Mvc;
using SSIDocumentControl.Core.DocumentControl;
using SSIDocumentControl.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIDocumentControl.ViewComponents
{
    public class EditFileViewComponent:ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditFileViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IViewComponentResult> InvokeAsync(int docId)
        {
            var doc = docId > 0 ? await _unitOfWork.Documents.GetDocumentByIdAsync(docId) : new Document();
            //freeze document
            doc.DocStatusId = await _unitOfWork.Documents.GetDocumentStatusIdAsync("Freeze");
            _unitOfWork.Documents.UpdateDocument(doc);
            await _unitOfWork.CompleteAsync();
            doc.Folder = _unitOfWork.Documents.GetFolderById(Convert.ToInt32(doc.FolderId));
            doc.SendNotification = true;
          
            return View("EditFile", doc);
        }
    }
}
