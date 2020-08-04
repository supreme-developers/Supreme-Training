using Microsoft.AspNetCore.Mvc;
using SSIDocumentControl.Core.DocumentControl;
using SSIDocumentControl.Models.SystemModels;
using SSIDocumentControl.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIDocumentControl.ViewComponents
{
    public class SearchDirectoryViewComponent:ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserSession _userSession;

        public SearchDirectoryViewComponent(IUnitOfWork unitOfWork, IUserSession userSession)
        {
            _unitOfWork = unitOfWork;
            _userSession = userSession;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var searchDirectory =  await _unitOfWork.Documents.GetSearchDirectory(_userSession.Id);

            return View("SearchDirectory", searchDirectory.ToList());
        }

    }
}
