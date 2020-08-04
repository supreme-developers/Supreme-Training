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
    public class UserDirectoryViewComponent:ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserSession _userSession;

        public UserDirectoryViewComponent(IUnitOfWork unitOfWork, IUserSession userSession)
        {
            _unitOfWork = unitOfWork;
            _userSession = userSession;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? folderId, int? docId)
        {
            var userPaths = await _unitOfWork.Documents.GetUserPaths(_userSession.Id);

            if (folderId != null && folderId > 0)
            {
                //get top parent
                //userPaths.Where(p => p.ID == folderId)
                //         .ToList()
                //         .ForEach(x => x.Expanded = true);
                userPaths = ExpandFolders(userPaths.ToList(), folderId);
                ViewBag.SelectedId = new string[] { folderId.ToString()};
                ViewBag.SelectedDocId = docId != null ? new string[] { docId.ToString() }: new string[] { "0" };
            }
            else
            {
                ViewBag.SelectedId = new string[] { "0" };
                ViewBag.SelectedDocId = new string[] { "0" };
            }

            return View("UserDirectory",userPaths);
        }
        public static List<TreeViewDocViewModel> ExpandFolders(List<TreeViewDocViewModel> userTreeView, int? folderId)
        {
            int? parentFolderId = userTreeView.Where(t => t.ID == folderId).Select(p => p.ParentFolderID).SingleOrDefault();

           userTreeView.Where(p => p.ID == folderId)
                         .ToList()
                         .ForEach(x => x.Expanded = true);
            if (parentFolderId != null && parentFolderId > 0)
                return ExpandFolders(userTreeView, parentFolderId);
            else
                return userTreeView;
        }

        

    }
}
