using Microsoft.EntityFrameworkCore;
using SSIDocumentControl.Core.DocumentControl;
using SSIDocumentControl.Core.DocumentControl.ViewModels;
using SSIDocumentControl.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSIDocumentControl.Repositories.Documents
{
    public class DocControlRepository : IDocControlRepository
    {        
        private readonly DocumentContext _context;

        public DocControlRepository(DocumentContext context)
        {
            _context = context;
        }
        public async Task CreateFolder(DocumentFolder newFolder)
        {
            await _context.DocumentFolder.AddAsync(newFolder);
        }
        public void UpdateFolder(DocumentFolder folder)
        {
            _context.DocumentFolder.Update(folder);
        }
        public bool FolderExists(int folderId)
        {
            return _context.DocumentFolder.Any(e => e.FolderId == folderId);
        }
        public async Task<IEnumerable<DocumentFolder>> GetAllFoldersAsync()
        {
            var statusId = await _context.DocumentStatus.Where(s => s.Code == "Active")
                                       .Select(s => s.DocStatusId)
                                       .SingleOrDefaultAsync();
            return await _context.DocumentFolder
                        .Where(f => f.FolderStatusId == statusId)
                        .Select(f=> new DocumentFolder{
                            FolderId = f.FolderId,
                            Name = f.Name,
                            SortId = f.SortId, 
                            ParentFolderId = f.ParentFolderId
                        })
                      
                        .OrderBy(f => f.SortId)
                        .ThenBy(f=> f.Name)
                        .ToListAsync();
        }
        public async Task<IEnumerable<DocumentFolder>> GetDocumentFolders()
        {
            try
            {
                var folders = new List<DocumentFolder>();
                var statusId = await _context.DocumentStatus.Where(s => s.Code == "Active")
                                        .Select(s => s.DocStatusId)
                                        .SingleOrDefaultAsync();

                folders = await _context.DocumentFolder
                                .Where(f => f.ParentFolderId == null &&
                                        f.FolderStatusId == statusId)
                                .ToListAsync();
                
                return folders;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> GetFolderIdByName(string parentFolderName)
        {
            return await _context.DocumentFolder
                                .Where(p => p.Name == parentFolderName)
                                .Select(p => p.FolderId)
                                .SingleOrDefaultAsync();
        }
        public async Task<IEnumerable<DocumentFolder>> GetFoldersByParentId(int? parentId)
        {
            return await _context.DocumentFolder
                                 .Join(_context.DocumentStatus,
                                    folder => folder.FolderStatusId,
                                    status => status.DocStatusId,
                                    (folder, status) => new { DocumentFolder = folder, DocumentStatus = status})
                                .Where(fs => fs.DocumentFolder.ParentFolderId == parentId 
                                        && fs.DocumentStatus.Code == "Active")
                                .Select(fs=> fs.DocumentFolder)
                                .OrderBy(p=> p.Name)
                                .ToListAsync();
        }
        public async Task<IEnumerable<Document>> GetDocumentsByParentId(int? parentId, int? documentId)
        {
            var activeStatusId = _context.DocumentStatus.Where(s => s.Code == "Active")
                                    .Select(s => s.DocStatusId).SingleOrDefault();

            var docTasks = await _context.Document
                                .Where(d=> d.FolderId == parentId 
                                        && d.DocStatusId == activeStatusId)
                                .ToListAsync();
            //filter by Id if searching by document
            docTasks = documentId != null ? docTasks.Where(d => d.DocId == documentId).ToList() : docTasks.OrderBy(t=> t.DocumentNumber).ToList();

            return docTasks;
        }
        public List<DocVM> GetNonMobileDocuments()
        {
            try
            {
                var activeStatusId = _context.DocumentStatus.Where(s => s.Code == "Active")
                                         .Select(s => s.DocStatusId).SingleOrDefault();
                var mobileDocIds = _context.MobileDocs.Select(m => m.DocId);
                //get non-mobile docs
                var documents =  _context.Document
                                    .OrderBy(d=> d.Folder.Name ).ThenBy(d=> d.DocumentName)
                                    .Where(d => d.DocStatusId == activeStatusId && !mobileDocIds.Contains(d.DocId))
                                    .Select(r => new DocVM
                                    {
                                        DocId = r.DocId,
                                        DocName = r.DocumentNumber + " - " + r.DocumentName,
                                        DocNumber = r.DocumentNumber
                                    })
                                    .ToList();

                return documents;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public List<DocVM> GetMobileDocuments()
        {
            var activeStatusId = _context.DocumentStatus.Where(s => s.Code == "Active")
                                    .Select(s => s.DocStatusId).SingleOrDefault();

            var documents = _context.Document.Join(
                                                        _context.MobileDocs,
                                                        d => d.DocId,
                                                        m => m.DocId,
                                                        (d,m)=> new {d, m})
                                .Where(d => d.d.DocStatusId == activeStatusId)
                                .Select(r => new DocVM
                                {
                                    DocId = r.m.DocId,
                                    DocName = r.d.DocumentNumber + " - " + r.d.DocumentName,
                                    DocNumber = r.d.DocumentNumber
                                })
                                .ToList();

            return documents;
        }
        public async Task AddDocument (Document doc)
        {
            await _context.Document.AddAsync(doc);
        }
        public async Task RemoveAllMobileDocs()
        {
            var alldocs = await _context.MobileDocs.ToListAsync();
             _context.MobileDocs.RemoveRange(alldocs);
        }
        public async Task AddMobileDocuments(List<MobileDocs> docs)
        {
            await _context.MobileDocs.AddRangeAsync(docs);
        }
        public void UpdateDocument(Document doc)
        {
             _context.Document.Update(doc);
        }
        public async Task UpdateDocumentStatusByIdAsync(int docId, string status)
        {
            var doc = await _context.Document.Where(d => d.DocId == docId).SingleOrDefaultAsync();
            doc.DocStatusId = await GetDocumentStatusIdAsync(status);
        }
        public void DeleteDocument(Document doc)
        {
            
            _context.Document.Update(doc);
        }
        public void DeleteFolder(int folderID)
        {
            _context.DocumentFolder
                .Where(f => f.FolderId == folderID)
                .ToList()
                .ForEach(f => 
                        f.FolderStatusId = (_context
                        .DocumentStatus
                            .Where(s => s.Code == "Delete")
                            .Select(s => s.DocStatusId)
                            .SingleOrDefault()));
            
        }
        public int GetDocumentsMaxSort(int folderId)
        {
            int? max = _context.Document
                        .Where(d=> d.FolderId == folderId)
                        .Max(d => d.SortId);
            return max != null ? Convert.ToInt32(max) : 0;
        }
        public async Task<int> GetDocumentStatusIdAsync(string code)
        {
            return await _context.DocumentStatus
                    .Where(s => s.Code == code)
                    .Select(s => s.DocStatusId)
                    .SingleOrDefaultAsync();
        }
        public async Task<Document> GetDocumentByIdAsync(int docId)
        {
            return await _context.Document.Where(d => d.DocId == docId).SingleOrDefaultAsync();

        }

        public async Task<DocumentFolder> GetFolderByIdAsync(int parentId)
        {
            return await _context.DocumentFolder.Where(f => f.FolderId == parentId).SingleOrDefaultAsync();
        }
        public DocumentFolder GetFolderById(int parentId)
        {
            return  _context.DocumentFolder.Where(f => f.FolderId == parentId).SingleOrDefault();
        }
        public async Task<string> GetCurrentPath(int? parentFolderId)
        {
            string path = "";
            var invalidChars = Path.GetInvalidFileNameChars();
            while (parentFolderId != null)
            {
                DocumentFolder parent = await _context.DocumentFolder
                                        .Where(f=> f.FolderId == Convert.ToInt32(parentFolderId))
                                        .SingleOrDefaultAsync();
                parentFolderId = parent.ParentFolderId;
                path = new string(parent.Name
                            .Where(x => !invalidChars.Contains(x))
                                            .ToArray()) + "\\" + path;
            }
            return path;
        }
        public async Task<IDictionary<int?, string>> GetParentFolders(int? folderId)
        {
            var parents = new Dictionary<int?, string>();
            while (folderId != null)
            {
                DocumentFolder parent = await _context.DocumentFolder
                                        .Where(f => f.FolderId == folderId)
                                        .SingleOrDefaultAsync();
                parents.Add(parent.FolderId, parent.Name);
                folderId = parent.ParentFolderId;             
            }
            return parents;
        }
        public async Task<IEnumerable<TreeViewDocViewModel>> GetUserPaths(int UserId)
        {
            try
            {
                var userPaths = await _context.TreeViewDocViewModel.FromSql($"exec sp_DocumentControl_GetUserDocPaths {UserId}").ToListAsync();
                return userPaths;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task<IEnumerable<Document>> GetUserDocumentsByParentIdAsync(int folderId)
        {
            var activeStatusId = _context.DocumentStatus.Where(s => s.Code == "Active")
                                  .Select(s => s.DocStatusId).SingleOrDefault();
            var docs = await _context.Document
                        .Where(d => d.FolderId == folderId && d.DocStatusId == activeStatusId)
                        .OrderBy(d=> d.DocumentNumber)
                        .ToListAsync();
            return docs;
        }
        public async Task SendNotification(int docId, int userId)
        {
            var docIdParam = new SqlParameter("@DocID", docId);
            var userIdParam = new SqlParameter("@UserId", userId);
            await _context.Database.ExecuteSqlCommandAsync("sp_DocumentControl_SendUpdateNotifications @DocID, @UserID", docIdParam, userIdParam);
        }
        public async Task<IEnumerable<DirectorySearchViewModel>> GetSearchDirectory(int UserId)
        {
            try
            {
                var dir = await _context.DirectorySearchViewModel.FromSql($"sp_DocumentControl_DirectorySearch {UserId}").ToListAsync();
                return dir;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //public int GetFolderIdByName(string folderName)
        //{
        //    return  _context.DocumentFolder
        //                .Where(f => f.Name == folderName)
        //                .Select(f => f.FolderId)
        //                .SingleOrDefault();
        //}
    }
}
