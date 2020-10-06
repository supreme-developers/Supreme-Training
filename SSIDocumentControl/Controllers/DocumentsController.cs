using System;

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SSIDocumentControl.Core.DocumentControl;
using SSIDocumentControl.Data;
using SSIDocumentControl.Models.SystemModels;
using SSIDocumentControl.Repositories;
using SSIDocumentControl.ViewModels;
using SSIDocumentControl.Models;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System.Text;
using SSIDocumentControl.Core.DocumentAuthorization;
using SSIDocumentControl.Models.Constants;
using System.Diagnostics;
using System.Net.Mime;
using UAParser;
using System.Security;

namespace SSIDocumentControl.Controllers
{
    [Authorize]
    public class DocumentsController : Controller
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserSession _userSession;
        private IHostingEnvironment _hostingEnv;
        private string _networkDocPath = "";

        public DocumentsController(IUnitOfWork unitOfWork,IUserSession userSession, IHostingEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _userSession = userSession;
            _hostingEnv = env;
            _networkDocPath = _unitOfWork.SystemRepo.GetUploadPath();


        }
        public async Task<IActionResult> Index(int? folderId, int? docId)
        {
            var folders = await _unitOfWork.Documents.GetDocumentFolders();
            var folderItems = new FolderItemsViewModel();
            folderItems.Folders = folders;
            folderItems.Documents = Enumerable.Empty<Document>();
            folderItems.ParentFolder = null;
            folderItems.SearchFolderId = folderId != null && folderId > 0 ? folderId : 0;
            folderItems.SearchDocId = docId;
           // folderItems.PageId = pageId;

            return View(folderItems);
        }
        // GET: Documents/Details/5
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Details(int? id, int? docId, int? pageId)
        {
            if (id == null)
            {
                return NotFound();
            }
          
            var parentFolder = await _unitOfWork.Documents.GetFolderByIdAsync(Convert.ToInt32(id));

            var folderItems = new FolderItemsViewModel();
            var crumbs = new Dictionary<int?, string>();
            folderItems.Folders = docId == null ? await _unitOfWork.Documents.GetFoldersByParentId(id) : new List<DocumentFolder>();
            folderItems.Documents = await _unitOfWork.Documents.GetDocumentsByParentId(id, docId);
            folderItems.PageId = pageId;
            folderItems.ParentFolder = parentFolder;

            var pathCrumbs = await GetCrumbs(id);
            folderItems.PathCrumbs = pathCrumbs.OrderByDescending(c => c.Sort);
            if (folderItems == null)
            {
                return NotFound();
            }

            return View(folderItems);
        }
        [HttpGet]
        public async Task<IEnumerable<DirectorySearchViewModel>> GetAllDirectoryItems()
        {
            return await _unitOfWork.Documents.GetSearchDirectory(_userSession.Id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DocumentFolderViewModel documentFolder)
        {
            var invalidChars = Path.GetInvalidFileNameChars();
            
            if (ModelState.IsValid)
            {
                string validFolderName = new string(documentFolder.FolderName
                                           .Where(x => !invalidChars.Contains(x))
                                           .ToArray());
                try
                {
                    string path = _networkDocPath + (await _unitOfWork.Documents.GetCurrentPath(documentFolder.ParentFolderId) +  @"\" + validFolderName);
                    //string path = _hostingEnv.WebRootPath + "\\UploadFiles\\" +
                    //               await _unitOfWork.Documents.GetCurrentPath(documentFolder.ParentFolderId) +
                    //            "\\" + validFolderName;

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    DocumentFolder newFolder = new DocumentFolder();
                    newFolder.Name = documentFolder.FolderName.TrimEnd();
                    newFolder.ParentFolderId = documentFolder.ParentFolderId;
                    newFolder.CreateUserId = _userSession.Id;
                    newFolder.ModifiedDateTime = DateTime.Now;
                    newFolder.CreateDate = DateTime.Now;
                    newFolder.FolderStatusId = await _unitOfWork.Documents.GetDocumentStatusIdAsync("Active");

                
                    await _unitOfWork.Documents.CreateFolder(newFolder);
                   
                    await _unitOfWork.CompleteAsync();
                    
                    if (newFolder.ParentFolderId != null)
                      return RedirectToAction("Details", "Documents", new { id = newFolder.ParentFolderId });
                    else
                        return Redirect(Request.Headers["Referer"].ToString());
                 
                }
                catch (Exception)
                {

                    throw;
                }
               
            }            
            return View(documentFolder);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateFolder(DocumentFolderViewModel documentFolder)
        {
            var invalidChars = Path.GetInvalidFileNameChars();
           
            string validFolderName = new string(documentFolder.FolderName
                                          .Where(x => !invalidChars.Contains(x))
                                          .ToArray());
            string oldValidFolderName =  new string(documentFolder.OldFolderName
                                          .Where(x => !invalidChars.Contains(x))
                                          .ToArray());
            if (ModelState.IsValid)
            {
                try
                {
                    //string root = _hostingEnv.WebRootPath + "\\UploadFiles\\";
                    string root = _networkDocPath;
                    string oldPath = root + await _unitOfWork.Documents.GetCurrentPath(documentFolder.ParentFolderId) +
                                 "\\" + oldValidFolderName;
                    string newPath = root + await _unitOfWork.Documents.GetCurrentPath(documentFolder.ParentFolderId) +
                                 "\\" + validFolderName;

                    if (Directory.Exists(oldPath))
                        Directory.Move(oldPath, newPath); //rename folder
                    else
                        Directory.CreateDirectory(newPath);

                    DocumentFolder updatedFolder = new DocumentFolder
                    {
                        Name = documentFolder.FolderName.TrimEnd(),
                        ParentFolderId = documentFolder.ParentFolderId,
                        CreateUserId = _userSession.Id,
                        ModifiedDateTime = DateTime.Now,
                        CreateDate = DateTime.Now,
                        FolderId = Convert.ToInt32(documentFolder.FolderId),
                        FolderStatusId = documentFolder.FolderStatusId
                    };

                    _unitOfWork.Documents.UpdateFolder(updatedFolder);
                        await _unitOfWork.CompleteAsync();

                    return Redirect(Request.Headers["Referer"].ToString());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }            
            return View(documentFolder);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFolder(int id)
        {
            _unitOfWork.Documents.DeleteFolder(id);
            await _unitOfWork.CompleteAsync();
            return Redirect(Request.Headers["Referer"].ToString());
        }
       
        [HttpPost]
        [AcceptVerbs("Post")]
        public async Task<IActionResult> CreateNewFile(IList<IFormFile> UploadFiles, Document doc)//pass doc instead
        {
            var invalidChars = Path.GetInvalidFileNameChars();
            try
            {   
                foreach (var file in UploadFiles)
                {
                    if (UploadFiles != null)
                    {
                        var filename = ContentDispositionHeaderValue
                            .Parse(file.ContentDisposition)
                            .FileName.Trim('"');

                        doc.MimeType = filename.Split('.').Last();
                        string validFileName = new string(doc.DocumentName
                                            .Where(x => !invalidChars.Contains(x))
                                            .ToArray());
                        filename = await GetFullPath(doc.FolderId, validFileName) + "." + doc.MimeType;

                        if (System.IO.File.Exists(filename))
                        {
                            return Json(new
                            {
                                success = false,
                                errors = "This File Already Exists!"
                            });
                        }
                        else
                        {
                            var dir = filename.Split(validFileName + "." + doc.MimeType)[0];
                            //this is needed in the case of a missing physical folder. 
                            if (!Directory.Exists(dir))
                            {
                                Directory.CreateDirectory(dir);
                            }
                            using (FileStream fs = System.IO.File.Create(filename))
                            {
                                 file.CopyTo(fs);

                                doc.Path = await GetRelativePath(doc.FolderId, validFileName + "." + doc.MimeType);

                                await InsertDocument(doc);
                                await _unitOfWork.Documents.SendNotification(doc.DocId, _userSession.Id);
                                return RedirectToAction("Details", "Documents", new { id = doc.FolderId });                                
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Clear();
                Response.StatusCode = 404;
                Response.Headers.Add("status", ex.Message);                
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFile(IList<IFormFile> UploadFiles, Document doc)//pass doc instead
        {
            var invalidChars = Path.GetInvalidFileNameChars();
            string validFileName = new string(doc.DocumentName
                                          .Where(x => !invalidChars.Contains(x))
                                          .ToArray());
            try
            {
                doc.DocStatusId = await _unitOfWork.Documents.GetDocumentStatusIdAsync("Active");
                foreach (var file in UploadFiles)
                {
                    var oldFilename = ContentDispositionHeaderValue
                        .Parse(file.ContentDisposition)
                        .FileName.Trim('"');
                   
                    doc.MimeType = oldFilename.Split('.').Last();
                    string oldFilePath = await GetFullPath(doc.FolderId, validFileName) + "." + doc.MimeType;
                    var newFileName = oldFilePath.Replace(oldFilename, validFileName);

                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath); // just fully remove and to upload again. an additional copy should already be saved on server
                    }
                    using (FileStream fs = System.IO.File.Create(newFileName))
                    {
                        await file.CopyToAsync(fs);
                        doc.Path = await GetRelativePath(doc.FolderId, validFileName + "." + doc.MimeType);
                        //the upload date is only set when a new file is uploaded. This will give the last "document revised" date.
                        doc.UploadDate = DateTime.Now;
                    }
                }

                //03.23.2020 network path 
                //string oldPath = _hostingEnv.WebRootPath + doc.Path;
                string oldPath = _networkDocPath + doc.Path;

                var relPath = await GetRelativePath(doc.FolderId, validFileName + "." + doc.MimeType);
                //03.23.2020 network path 
                //string newPath = _hostingEnv.WebRootPath + relPath;
                string newPath = _networkDocPath + relPath;
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Move(oldPath, newPath);//rename file
                }

                doc.Path = relPath;
                await UpdateDocument(doc);

                if (doc.SendNotification)
                    await _unitOfWork.Documents.SendNotification(doc.DocId, _userSession.Id);

                return Redirect(Request.Headers["Referer"].ToString());
            }
            catch (Exception ex)
            {                
                Response.Clear();
                Response.StatusCode = 404;
                Response.Headers.Add("status", ex.Message);
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }
        [HttpPost]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            var doc = await _unitOfWork.Documents.GetDocumentByIdAsync(id);
            doc.DocStatusId = await _unitOfWork.Documents.GetDocumentStatusIdAsync("Delete");

            var docPath = await GetFullPath(doc.FolderId, doc.DocumentName) + "." + doc.MimeType;

            if (System.IO.File.Exists(docPath))
            {
                System.IO.File.Delete(docPath);
            }

            _unitOfWork.Documents.DeleteDocument(doc);
            await _unitOfWork.CompleteAsync();
            return Redirect(Request.Headers["Referer"].ToString());
        }
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public async Task<IActionResult> SetPdfExpiration(int id)
        {
            var invalidChars = Path.GetInvalidFileNameChars();
            Document doc = await _unitOfWork.Documents.GetDocumentByIdAsync(id);
            var expDate = DateTime.Now.AddDays(2);
            doc.ExpiryDate = expDate;
            PdfJavaScriptAction scriptAction = BuildExpireJSFunc(doc);
            string saveAs = await GetFullPath(doc.FolderId, doc.DocumentName + "." + doc.MimeType);
            //this key is what the new pdf with the expiration function attached to it will be renamed with
            var expKey = SystemConstants.ExpiryKey;

            //03.23.2020 network path
            string userPath =_networkDocPath + _userSession.FirstName + _userSession.LastName + _userSession.Id + "\\";
            //string userPath = _hostingEnv.WebRootPath + "\\UploadFiles\\" + _userSession.FirstName + _userSession.LastName + _userSession.Id + "\\";


            if (!Directory.Exists(userPath))
                Directory.CreateDirectory(userPath);
            else
            {
                DeleteOldDirectoryFiles(userPath);
            }
            string expPath = "";
            try
            {
                //03.23.2020 network path _hostingEnv.WebRootPath + "\\"
                using (FileStream fs = new FileStream(doc.Path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    if (doc.MimeType == "pdf")
                    {
                        PdfLoadedDocument loadedDocument = new PdfLoadedDocument(fs);

                        PdfDocument document = new PdfDocument();
                        PdfDocument.Merge(document, loadedDocument);
                        string validFileName = new string(doc.DocumentName
                                          .Where(x => !invalidChars.Contains(x))
                                          .ToArray());

                        if (doc.DocId > 0)
                            document.Actions.AfterOpen = scriptAction;

                        doc.Path = await GetRelativePath(doc.FolderId, validFileName + "." + doc.MimeType);
                        expPath = userPath + validFileName + "." + doc.MimeType;

                        if (System.IO.File.Exists(expPath))
                            System.IO.File.Delete(expPath);
                      //  FileStream outputStream = new FileStream(expPath, FileMode.CreateNew);
                        using (FileStream outputStream = new FileStream(expPath, FileMode.CreateNew))
                        {
                            document.Save(outputStream);
                            document.Close(true);
                            loadedDocument.Close(true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            var pdfPaths = new PdfViewerViewModel
            {
                ReadOnlyPath = doc.Path,
                DownloadPath = expPath
            };
            var userAgent = Request.Headers["User-Agent"];
            string uaString = Convert.ToString(userAgent[0]);
            var uaParser = Parser.GetDefault();
            ClientInfo c = uaParser.Parse(uaString);
            //if (c.UserAgent.Family == "IE")
            //{
            //    return RedirectToAction("Download", "Documents", new { docPath = pdfPaths.DownloadPath, ieDownload = true });
            //}
            //else
            //{
            //    return RedirectToAction("Index", "PdfViewer", pdfPaths);
            //}

            var stream = new FileStream(pdfPaths.ReadOnlyPath, FileMode.Open);


            ////return File(stream, "application/pdf","test.pdf");

            //return new FileStreamResult(stream, "application/pdf");

            //ProcessStartInfo info = new ProcessStartInfo();
            //info.Verb = "Open";
            //info.FileName = @"C:\Program Files (x86)\Adobe\Acrobat Reader DC\Reader\AcroRd32.exe";
            ////info.FileName = @"C:\Program Files (x86)\Adobe\Reader 11.0\Reader\AcroRd32.exe";
            ////info.Arguments = String.Format(@"/p /h {0}", pdfPaths.DownloadPath);
            //info.CreateNoWindow = false;
            //info.WindowStyle = ProcessWindowStyle.Hidden;
            //info.UseShellExecute = true;

            //info.Arguments = String.Format(pdfPaths.DownloadPath);
            //Process p = Process.Start(info);
            pdfPaths.DownloadPath = @"D:\test.pdf";

            return RedirectToAction("Index", "PdfViewer", pdfPaths);
            //return new FileStreamResult(stream, "application/pdf");


        }
        private SecureString ConvertToSecureString(string pw)
        {
            var password = new SecureString();
            foreach(char c in pw.ToCharArray())
            {
                password.AppendChar(c);
            }
            return password;
        }

        public IActionResult Print(string docPath)
        {
            try
            {
                //ProcessStartInfo info = new ProcessStartInfo();
                //info.Verb = "print";
                //info.FileName = @"C:\Program Files (x86)\Adobe\Reader 11.0\Reader\AcroRd32.exe";
                //info.CreateNoWindow = false;
                //info.WindowStyle = ProcessWindowStyle.Hidden;
                //info.UseShellExecute = false;
                //info.Arguments = String.Format(@"/p /h {0}", docPath);

                //Process p = Process.Start(info);
                ////p.StartInfo = info;
                ////p.Start(info);

                ////p.WaitForInputIdle();
                //if (p.HasExited == false)
                //{
                //    p.WaitForExit(10000);
                //}
                //p.EnableRaisingEvents = true;

                //p.Close();
                //KillAdobe("AcroRd32");



                return Redirect(Request.Headers["Referer"].ToString());
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message; 
                return RedirectToAction("ProgramError", "Common");
            }
        }
        private static bool KillAdobe(string name)
        {
            foreach (Process clsProcess in Process.GetProcesses().Where(
                         clsProcess => clsProcess.ProcessName.StartsWith(name)))
            {
                clsProcess.Kill();
                return true;
            }
            return false;
        }
    
    public IActionResult Download(string docPath, bool? ieDownload)
        {
            string filename = Path.GetFileName(docPath);
            string filepath = docPath;
            byte[] filedata = System.IO.File.ReadAllBytes(filepath);
            string contentType = MediaTypeNames.Application.Pdf;
            if (ieDownload == null || Convert.ToBoolean(ieDownload) == false)
            {
                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = filename,
                    Inline = false,
                };
                HttpContext.Response.Headers["Content-Disposition"] = cd.ToString();
            }


            return File(filedata, contentType);
        }
        private static void DeleteOldDirectoryFiles(string userPath)
        {
            string[] files = Directory.GetFiles(userPath);

            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.LastAccessTime < DateTime.Now.AddDays(-2))
                    fi.Delete();
            }
        }

        private static PdfJavaScriptAction BuildExpireJSFunc(Document doc)
        {
            return new PdfJavaScriptAction("function Expire(){ " +
                        "var rightNow = new Date();  " +
                        "var endDate = new Date(" + Convert.ToDateTime(doc.ExpiryDate).Year +
                                             ", " + (Convert.ToInt32(Convert.ToDateTime(doc.ExpiryDate).Month) - 1).ToString() +
                                             ", " + Convert.ToDateTime(doc.ExpiryDate).Day + ");      " +
                        "if (rightNow > endDate)   {  " +
                            "app.alert(\"This Document has Expired. Please get the latest document on the web.\"); " +
                            "this.closeDoc();   window.close();  " +
                        "}     " +
                    "}    " +
                    " Expire();");
        }
        private async Task<string> GetFullPath(int? folderId, string filename)
        {
            //filename = _hostingEnv.WebRootPath + "\\UploadFiles\\" +
            filename = _networkDocPath +  await _unitOfWork.Documents.GetCurrentPath(folderId) +
                        "\\" + filename;
            return filename;
        }
        private async Task<string> GetRelativePath(int? folderId, string filename)
        {
            //filename = "\\UploadFiles\\" +
            // _networkDocPath +
            filename = _networkDocPath + "\\" + await _unitOfWork.Documents.GetCurrentPath(folderId) + "\\" + filename;
            return filename;
        }
        private async Task InsertDocument(Document doc)
        {
            try
            {
                doc.ModifiedDatetime = DateTime.Now;
                doc.DocStatusId = await _unitOfWork.Documents.GetDocumentStatusIdAsync("Active"); 
                doc.CreateDateTime = DateTime.Now;
                doc.CreateUserId = _userSession.Id;
                doc.SortId = _unitOfWork.Documents.GetDocumentsMaxSort(Convert.ToInt32(doc.FolderId)) + 10;
                doc.UploadDate = DateTime.Now;
                await _unitOfWork.Documents.AddDocument(doc);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> SetDocumentStatus(int docId, string statusCode)
        {
            try
            {
                await _unitOfWork.Documents.UpdateDocumentStatusByIdAsync(docId, statusCode);
                await _unitOfWork.CompleteAsync();
                return Json(new
                {
                    success = true
                });
            }
            catch (Exception ex)
            {

                return Json(new
                {
                    success = false,
                    errors = ex.Message
                });
            }            
        }
        private async Task UpdateDocument(Document doc)
        {
            try
            {
                doc.ModifiedDatetime = DateTime.Now;
                doc.DocStatusId = await _unitOfWork.Documents.GetDocumentStatusIdAsync("Active");
                doc.CreateDateTime = DateTime.Now;
                doc.CreateUserId = _userSession.Id;
                 _unitOfWork.Documents.UpdateDocument(doc);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }            
        private bool DocumentFolderExists(int id)
        {
            return _unitOfWork.Documents.FolderExists(id);
        }        
        public async Task<List<FolderCrumbs>> GetCrumbs(int? folderId)
        {
            var parents = new List<FolderCrumbs>();
            int sort = 0;
            while (folderId != null)
            {
                DocumentFolder parent = await _unitOfWork.Documents.GetFolderByIdAsync(Convert.ToInt32(folderId));
                parents.Add(new FolderCrumbs
                            {
                                Id = parent.FolderId,
                                Name = parent.Name,
                                Sort =  sort
                            });
                folderId = parent.ParentFolderId;
                sort++;
            }
            return parents;
        }

        //Call View Components

        public IActionResult ViewFolderDocuments(int parentId, int? docId)
        {
            return ViewComponent("UserDocuments", new { parentId, docId });
        }
        public IActionResult ReviseDocument(int? docId)
        {
            return ViewComponent("EditFile", docId);
        }
        public IActionResult EditFolder(int folderId)
        {
            return ViewComponent("EditFolder", folderId);
        }

    }
}
