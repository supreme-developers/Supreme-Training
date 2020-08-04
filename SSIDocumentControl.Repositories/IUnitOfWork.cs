using System.Threading.Tasks;
using SSIDocumentControl.Repositories.DocumentAuthorization;
using SSIDocumentControl.Repositories.Documents;
using SSIDocumentControl.Repositories.System;
using SSIDocumentControl.Repositories.Users;

namespace SSIDocumentControl.Repositories
{
    public interface IUnitOfWork
    {
        IDocControlRepository Documents { get; }
        IUserRepository Users { get; }
        IAuthorizationRepository AuthorizationRepo { get; }
        ISystemRepository SystemRepo { get; }
        void Complete();
        Task CompleteAsync();
    }
}