using System.Collections.Generic;
using System.Threading.Tasks;
using SSIDocumentControl.Core;

namespace SSIDocumentControl.Repositories.Users
{
    public interface IUserRepository
    {
        Task<RentUser> GetByUserId(int? userId);
        Task<RentUser> GetByUserName(string userName);
        Task<bool> ValidateCredentials(string userName, string password);
        Task<IEnumerable<RentUser>> GetAllActiveUsers();
        Task<IEnumerable<RentUser>> GetActiveUsersNotAssignedToRole(int roleId);
        Task<bool> IsAdministrator(RentUser user);
    }
}