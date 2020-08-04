using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;


using SSIDocumentControl.Core.DocumentControl;
using SSIDocumentControl.Core.DocumentControl.ViewModels;
using SSIDocumentControl.Models.Constants;
using SSIDocumentControl.Repositories;
using SSIDocumentControl.ViewModels;

namespace SSIDocumentControl.Controllers
{
    public class MobileDocsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _memoryCache;

        public MobileDocsController(IUnitOfWork unitOfWork, IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _memoryCache = memoryCache;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ManageMobileDocs()
        {
            List<DocVM> cachedNonMobileDocs = null;
            List<DocVM> mobileDocs = _unitOfWork.Documents.GetMobileDocuments();
            var mobileString = JsonConvert.SerializeObject(mobileDocs.ToArray());

            cachedNonMobileDocs = _memoryCache.GetOrCreate(CacheEntryConstants.DocumentCache, entry =>
               {
                   entry.SlidingExpiration = TimeSpan.FromDays(1);
                   entry.Priority = CacheItemPriority.High;
                   return _unitOfWork.Documents.GetNonMobileDocuments();
               }).Where(d => !mobileDocs.Select(m => m.DocId).Contains(d.DocId)).ToList();


            var mngMobiledocLists = new MngMobileDocListsVM
            {
                NonMobileDocs = cachedNonMobileDocs,
                MobileDocs = mobileDocs,
                AssignedMobileDocs = mobileString
            };

            //var assignedDocs
            return View(mngMobiledocLists);
        }
        public IActionResult GetNonMobileDocs()
        {
            var nonMobileDocs =  _unitOfWork.Documents.GetNonMobileDocuments();
           return Json(nonMobileDocs);
        }
        public IActionResult GetMobileDocs()
        {
            var mobileDocs =  _unitOfWork.Documents.GetMobileDocuments();
            return Json(mobileDocs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DesignateDocsAsync(MngMobileDocListsVM lists)
        {
            await ManageMobileDocs(lists);
            return Redirect(Request.Headers["Referer"].ToString());
        }
        private async Task ManageMobileDocs(MngMobileDocListsVM lists)
        {
            List<MobileDocs> assigneddocs = new List<MobileDocs>();

            if (lists.AssignedMobileDocs != null)
            {
                assigneddocs = JsonConvert.DeserializeObject<List<MobileDocs>>(lists.AssignedMobileDocs);
            }
             await _unitOfWork.Documents.RemoveAllMobileDocs();
               
        

            if (assigneddocs != null)
            {
                await _unitOfWork.Documents.AddMobileDocuments(assigneddocs);             
            }
            await _unitOfWork.CompleteAsync();
        }
    }
}