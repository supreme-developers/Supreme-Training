using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIDocumentControl.Models.SystemModels
{
 public interface IUserSession
    {
        bool IsAuthenticated { get; }
        int Id { get; }
        string FirstName { get; }
        string LastName { get; }
        string UserName { get; }
        string FullName { get; }
        int OfficeId { get; }
    }
}
