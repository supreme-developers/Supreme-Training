using System.Collections.Generic;
using System.Threading.Tasks;
using SSIDocumentControl.Core;
using SSIDocumentControl.Core.DocumentAuthorization;

namespace SSIDocumentControl.Repositories.DocumentAuthorization
{
    public interface IAuthorizationRepository
    {
        Task<Role> GetRoleByIdAsync(int roleId);
        Task<IEnumerable<RoleViewModel>> GetRolesAsync();
        Task CreateFolderRole(FolderRole folderRole);
        Task CreateFolderRoles(IEnumerable<FolderRole> folderRoles);
        Task CreateRole(Role role);
        Task<IEnumerable<RentUser>> GetRoleAssignedUsers(int? roleId);
        Task<IEnumerable<FolderRoleViewModel>> GetAllFolderRoles(int? roleId);
        Task CreateUserRole(UserRole userRole);
        Task CreateUserRoles(IEnumerable<UserRole> userRoles);
        Task<IEnumerable<UserRole>> GetExistingUserRoles(int roleId);
        //Task<IEnumerable<UserRole>> GetUserRolesById(List<int> userRoleIds, int roleId);
        Task<IEnumerable<FolderRole>> GetExistingFolderRoles(int roleId);
        void DeleteFolderRole(FolderRole folderRole);
        void DeleteFolderRoles(IEnumerable<FolderRole> folderRoles);
        void DeleteRole(Role role);
        void DeleteUserRole(UserRole userRole);
        void DeleteUserRoles(IEnumerable<UserRole> userRoles);
        void UpdateFolderRole(FolderRole folderRole);
        void UpdateRole(Role role);
        void UpdateUserRole(UserRole userRole);
    }
}