using Microsoft.AspNetCore.Mvc;
using SSIDocumentControl.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIDocumentControl.ViewComponents
{
    public class UserDocumentsViewComponent:ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserDocumentsViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IViewComponentResult> InvokeAsync(int parentId, int? docId)
        {
            var documents = await _unitOfWork.Documents.GetUserDocumentsByParentIdAsync(parentId);
            if (docId != null && docId > 0)
                documents = documents.Where(d => d.DocId == docId);

            return View("UserDocuments",documents);
        }
    }
}
