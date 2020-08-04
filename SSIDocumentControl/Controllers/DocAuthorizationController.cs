using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SSIDocumentControl.Core;
using SSIDocumentControl.Core.DocumentAuthorization;
using SSIDocumentControl.Core.DocumentControl;
using SSIDocumentControl.Models.SystemModels;
using SSIDocumentControl.Repositories;
using SSIDocumentControl.ViewModels;

namespace SSIDocumentControl.Controllers
{
    [Authorize(Policy = "Administrator")]
    public class DocAuthorizationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserSession _userSession;

        public DocAuthorizationController(IUnitOfWork unitOfWork, IUserSession userSession)
        {
            _unitOfWork = unitOfWork;
            _userSession = userSession;
        }
        public async Task<IActionResult> Index()
        {
            
            var roles = await _unitOfWork.AuthorizationRepo.GetRolesAsync();
            
            return View(roles);
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(RoleSetupViewModel roleSetup)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Role role = await SaveRole(roleSetup);
                    await ManageRoleRelationships(roleSetup, role);
                    return Redirect(Request.Headers["Referer"].ToString());
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }
     
        public async Task<IActionResult> DeleteRole(int id)
        {
            try
            {
                var deletedFolderRoles = await _unitOfWork.AuthorizationRepo.GetExistingFolderRoles(id);
                    _unitOfWork.AuthorizationRepo.DeleteFolderRoles(deletedFolderRoles);
                var deletedUserRoles = await _unitOfWork.AuthorizationRepo.GetExistingUserRoles(id);                    
                    _unitOfWork.AuthorizationRepo.DeleteUserRoles(deletedUserRoles);
                Role role = await _unitOfWork.AuthorizationRepo.GetRoleByIdAsync(id);
                    _unitOfWork.AuthorizationRepo.DeleteRole(role);

                await _unitOfWork.CompleteAsync();
            }
            catch (Exception)
            {

                throw;
            }
            // return Redirect(Request.Headers["Referer"].ToString());
            return RedirectToAction("Index");
        }

        private async Task ManageRoleRelationships(RoleSetupViewModel roleSetup, Role role)
        {
            await ManageUserRoles(roleSetup, role);
            await ManageFolderRoles(roleSetup, role);
            await _unitOfWork.CompleteAsync();
        }

        private async Task ManageFolderRoles(RoleSetupViewModel roleSetup, Role role)
        {
            //null string list throws exception
            var existingFolderRoles = await _unitOfWork.AuthorizationRepo.GetExistingFolderRoles(role.RoleId);
            roleSetup.AssignedFolerRoles = roleSetup.AssignedFolerRoles == null ? "" : roleSetup.AssignedFolerRoles;   
            List<int> assignedFolderRoleId = JsonConvert.DeserializeObject<List<int>>(roleSetup.AssignedFolerRoles);

            if (existingFolderRoles.Count() > 0 && roleSetup.AssignedFolerRoles != "")
            {
                _unitOfWork.AuthorizationRepo.DeleteFolderRoles(existingFolderRoles);
                await _unitOfWork.CompleteAsync();
            }
            //create list of User role OBjects to insert into FolderRoles_Matrix
            if (assignedFolderRoleId != null)
            {
                var assignedFolderRoles = assignedFolderRoleId
                                    .Select(fr => new FolderRole
                                    {
                                        Role = role,
                                        FolderId = fr,
                                        CreateDateTime = DateTime.Now,
                                        CreateUserId = _userSession.Id
                                    });
                await _unitOfWork.AuthorizationRepo.CreateFolderRoles(assignedFolderRoles);
            }
        }

        private async Task ManageUserRoles(RoleSetupViewModel roleSetup, Role role)
        {
            var existingUserroles = await _unitOfWork.AuthorizationRepo.GetExistingUserRoles(role.RoleId); //-> 199
            roleSetup.AssignedUsersStringList = roleSetup.AssignedUsersStringList == null ? "" : roleSetup.AssignedUsersStringList; //empty s            
            List<RentUser> assignedUsers = JsonConvert.DeserializeObject<List<RentUser>>(roleSetup.AssignedUsersStringList);//null

            //Delete old user roles only when the assigned user list has been changed meaning AssignedUsersStringList will not be empty
            if (existingUserroles.Count() > 0 && roleSetup.AssignedUsersStringList != "")
            {
                _unitOfWork.AuthorizationRepo.DeleteUserRoles(existingUserroles);
                await _unitOfWork.CompleteAsync();
            }

            if (assignedUsers != null)
            {
                List<UserRole> userRoles = assignedUsers
                                .Select(u => new UserRole
                                {
                                    UserId = u.UserId,
                                    Role = role,
                                    CreateDateTime = DateTime.Now,
                                    CreateUserId = _userSession.Id
                                }).ToList();

                await _unitOfWork.AuthorizationRepo.CreateUserRoles(userRoles);
            }
        }

        private async Task<Role> SaveRole(RoleSetupViewModel roleSetup)
        {

            var role = new Role();
            if (roleSetup.Id != null)
                role = await _unitOfWork.AuthorizationRepo.GetRoleByIdAsync(Convert.ToInt32(roleSetup.Id));

            role.CreateDateTime = DateTime.Now;
            role.CreateUserId = _userSession.Id;
            role.Name = roleSetup.Name;
            role.Description = roleSetup.Description;

            if (roleSetup.Id != null)
                _unitOfWork.AuthorizationRepo.UpdateRole(role);
            else
                await _unitOfWork.AuthorizationRepo.CreateRole(role);

            await _unitOfWork.CompleteAsync();
            return role;
        }

        public IActionResult ManageRole(int? roleId)
        {
             return ViewComponent("CreateRole", roleId);
        }
    }
}