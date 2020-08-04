using Microsoft.AspNetCore.Mvc;
using SSIDocumentControl.Core.DocumentControl;
using SSIDocumentControl.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIDocumentControl.ViewComponents
{
    public class CreateFileViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateFileViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IViewComponentResult> InvokeAsync(int docId)
        {
            var doc = docId > 0 ? await _unitOfWork.Documents.GetDocumentByIdAsync(docId) : new Document();


            int folderId = 0;
            Int32.TryParse(HttpContext.Request.Path.ToString().Split('/').Last(), out folderId);
            doc.FolderId = folderId;
            ViewBag.data = await _unitOfWork.Documents.GetAllFoldersAsync();
            return View("CreateFile",doc);
        }
    }
}
