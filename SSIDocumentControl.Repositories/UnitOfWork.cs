using SSIDocumentControl.Data;
using SSIDocumentControl.Repositories.DocumentAuthorization;
using SSIDocumentControl.Repositories.Documents;
using SSIDocumentControl.Repositories.System;
using SSIDocumentControl.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SSIDocumentControl.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DocumentContext _context;
        public IDocControlRepository Documents { get; private set; }
        public IUserRepository Users { get; private set; }
        public IAuthorizationRepository AuthorizationRepo { get; set; }
        public ISystemRepository SystemRepo { get; set; }

        public UnitOfWork(DocumentContext context)
        {
            _context = context;
            Documents = new DocControlRepository(context);
            Users = new UserRepository(context);
            AuthorizationRepo = new AuthorizationRepository(context);
            SystemRepo = new SystemRepository(context);
        }

        public async Task CompleteAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void Complete()
        {
            _context.SaveChanges();
        }




    }
}
