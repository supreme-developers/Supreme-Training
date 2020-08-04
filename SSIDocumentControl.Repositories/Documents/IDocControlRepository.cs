using SSIDocumentControl.Core.DocumentControl;
using SSIDocumentControl.Core.DocumentControl.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SSIDocumentControl.Repositories.Documents
{
    public interface IDocControlRepository
    {
        Task CreateFolder(DocumentFolder newFolder);
        void UpdateFolder(DocumentFolder folder);
        bool FolderExists(int folderId);
        Task<IEnumerable<DocumentFolder>> GetAllFoldersAsync();
        void DeleteFolder(int folderID);
        Task<int> GetFolderIdByName(string folderName);
        Task<IEnumerable<DocumentFolder>> GetDocumentFolders();            
        Task<IEnumerable<DocumentFolder>> GetFoldersByParentId(int? parentId);
        Task<IEnumerable<Document>> GetDocumentsByParentId(int? parentId, int? documentId);
        Task AddDocument(Document doc);
        void UpdateDocument(Document doc);
        Task<DocumentFolder> GetFolderByIdAsync(int parentId);
        DocumentFolder GetFolderById(int parentId);
        Task UpdateDocumentStatusByIdAsync(int docId, string status);
        void DeleteDocument(Document doc);
        int GetDocumentsMaxSort(int folderId);
        Task<Document> GetDocumentByIdAsync(int docId);       
        Task<int> GetDocumentStatusIdAsync(string code);
        Task<IDictionary<int?, string>> GetParentFolders(int? folderId);
        Task<string> GetCurrentPath(int? parentFolderId);
        Task<IEnumerable<TreeViewDocViewModel>> GetUserPaths(int UserId);
        Task<IEnumerable<Document>> GetUserDocumentsByParentIdAsync(int folderId);
        List<DocVM> GetNonMobileDocuments();
        List<DocVM> GetMobileDocuments();
        Task SendNotification(int docId, int userId);
        Task<IEnumerable<DirectorySearchViewModel>> GetSearchDirectory(int UserId);
        Task RemoveAllMobileDocs();
        Task AddMobileDocuments(List<MobileDocs> docs);
    }
}
