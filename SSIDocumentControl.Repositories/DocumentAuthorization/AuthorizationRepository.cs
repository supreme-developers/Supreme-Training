using Microsoft.EntityFrameworkCore;
using SSIDocumentControl.Core;
using SSIDocumentControl.Core.DocumentAuthorization;
using SSIDocumentControl.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSIDocumentControl.Repositories.DocumentAuthorization
{
   public class AuthorizationRepository : IAuthorizationRepository
    {
        private readonly DocumentContext _context;

        public AuthorizationRepository(DocumentContext context)
        {
            _context = context;
        }

        public async Task<Role> GetRoleByIdAsync(int roleId)
        {
            return await _context.Role.Where(r => r.RoleId == roleId).SingleAsync();
        }
       
        public async Task<IEnumerable<RoleViewModel>> GetRolesAsync()
        {
            try
            {
                var allRoles = await _context.RoleViewModel.FromSql("sp_DocumentControl_GetAllRoleInfo").ToListAsync();
             
                return allRoles;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task CreateRole(Role role)
        {
            await _context.Role.AddAsync(role);
        }      
        public void UpdateRole(Role role)
        {
            _context.Role.Update(role);
        }
        public void DeleteRole(Role role)
        {
            _context.Role.Remove(role);
        }    
        public async Task<IEnumerable<RentUser>> GetRoleAssignedUsers(int? roleId)
        {
            return await _context.UserRole
                .Join(_context.Users,
                    userRole => userRole.UserId,
                    users => users.UserId,
                    (userRole, user) => new { userRole, user})
               .Where(result => result.user.Active == true && result.userRole.Role.RoleId == roleId)
               .Select(result => new RentUser
               {
                   UserId = result.user.UserId,
                   User = result.user.User,
                   FirstName = result.user.FirstName,
                   LastName = result.user.LastName,
                   OfficeId = result.user.OfficeId,
                   Password = result.user.Password
               })
               .OrderBy(u => u.FirstName)
               .ToListAsync();
        }        
        
        public async Task CreateUserRole(UserRole userRole)
        {
            await _context.UserRole.AddAsync(userRole);
        }
        public async Task CreateUserRoles(IEnumerable<UserRole> userRoles)
        {
            try
            {
                await _context.UserRole.AddRangeAsync(userRoles);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<UserRole>> GetExistingUserRoles(int roleId)
        {
            return await _context.UserRole.Where(ur => ur.Role.RoleId == roleId).ToListAsync();
        }
        //public async Task<IEnumerable<UserRole>> GetUserRolesById(List<int> userRoleIds, int roleId)
        //{
        //    return await _context.UserRole
        //            .Where(ur => ur.Role.RoleId == roleId && userRoleIds
        //                .Contains(ur.UserId))
        //            .ToListAsync();
        //}
        public void UpdateUserRole(UserRole userRole)
        {
            _context.UserRole.Update(userRole);
        }
        public void DeleteUserRole(UserRole userRole)
        {
            _context.UserRole.Remove(userRole);
        }
        public void DeleteUserRoles(IEnumerable<UserRole> userRoles)
        {
            _context.UserRole.RemoveRange(userRoles);
        }

        public async Task<bool> FolderHasRole(int folderId, int roleId)
        {
            var hasRole = await _context.FolderRole.AnyAsync(f => f.Folder.FolderId == folderId && f.Role.RoleId == roleId);
            return hasRole;
        }        
        public async Task<IEnumerable<FolderRole>> GetExistingFolderRoles(int roleId)
        {
            return await _context.FolderRole.Where(fr => fr.Role.RoleId == roleId).ToListAsync();
        }
        public async Task<IEnumerable<FolderRoleViewModel>> GetAllFolderRoles(int? roleId)
        {
            var folderRoles = await _context.DocumentFolder
                            .Where(
                                f => f.ParentFolderId == null && 
                                    f.FolderStatusId == _context.DocumentStatus
                                                        .Where(s=> s.Description == "Active")
                                                        .Select(x=> x.DocStatusId)
                                                        .SingleOrDefault()
                                )
                            .GroupJoin(
                                _context.FolderRole.Where(fr => fr.Role.RoleId == roleId),
                                folder => folder.FolderId,
                                folderRole => folderRole.Folder.FolderId,
                                (x, y) => new { Folder = x, FolderRole = y })
                            .Select(result => new FolderRoleViewModel
                            {
                                FolderName = result.Folder.Name,
                                FolderId = result.Folder.FolderId,
                                Assigned = result.FolderRole.Any(r => r.Role.RoleId == roleId && r.Folder.FolderId == result.Folder.FolderId),
                                RoleId = roleId
                            })
                            .ToListAsync();
            return folderRoles;
        }
        public async Task CreateFolderRole(FolderRole folderRole)
        {
            await _context.FolderRole.AddAsync(folderRole);
        }
        public async Task CreateFolderRoles(IEnumerable<FolderRole> folderRoles)
        {
            await _context.FolderRole.AddRangeAsync(folderRoles);
        }
        public void UpdateFolderRole(FolderRole folderRole)
        {
            _context.FolderRole.Update(folderRole);
        }
        public void DeleteFolderRole(FolderRole folderRole)
        {
            _context.FolderRole.Remove(folderRole);
        }
        public void DeleteFolderRoles(IEnumerable<FolderRole> folderRoles)
        {
            _context.FolderRole.RemoveRange(folderRoles);
        }

       

    }
}
