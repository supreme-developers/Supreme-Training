using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SSIDocumentControl.Core.DocumentAuthorization;
using SSIDocumentControl.Repositories;
using SSIDocumentControl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIDocumentControl.ViewComponents
{
    public class CreateRoleViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateRoleViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? roleId)
        {
            RoleSetupViewModel roleSetupVM = await BuildRoleSetupViewModel(roleId);
            return View("CreateRole", roleSetupVM);
        }

        private async Task<RoleSetupViewModel> BuildRoleSetupViewModel(int? roleId)
        {
            ViewBag.ButtonText = roleId != null ? "Save" : "Create";
            RoleSetupViewModel roleSetupVM = new RoleSetupViewModel();
            if (roleId != null) //pass Role Id and Name if Editing
            {
                Role role = new Role();
                role = await _unitOfWork.AuthorizationRepo.GetRoleByIdAsync(Convert.ToInt32(roleId));
                roleSetupVM.Id = role.RoleId;
                roleSetupVM.Name = role.Name;
                roleSetupVM.Description = role.Description;
            }

            //filter out all assigned users if role exists and is being edited.
            var users = roleId != null ? await _unitOfWork.Users.GetActiveUsersNotAssignedToRole(Convert.ToInt32(roleId)) : 
                                         await _unitOfWork.Users.GetAllActiveUsers();
            var assignedUsers = await _unitOfWork.AuthorizationRepo.GetRoleAssignedUsers(roleId);          
            var folderRoles = await _unitOfWork.AuthorizationRepo.GetAllFolderRoles(roleId);

            roleSetupVM.AllUsers = users.ToList();
            roleSetupVM.AssignedUsers = assignedUsers.ToList();
            roleSetupVM.FolderRoles = folderRoles.ToList();
            //roleSetupVM.AssignedUsersStringList = JsonConvert.SerializeObject(assignedUsers);
            //roleSetupVM.AssignedFolerRoles = JsonConvert.SerializeObject(folderRoles.Select(fr=> fr.FolderId));
            roleSetupVM.AssignedUsersStringList = "";
            roleSetupVM.AssignedFolerRoles = "";

            ViewBag.checkedNodes = GetAssignedFolderIds(folderRoles);


            return roleSetupVM;
        }

        private static string[] GetAssignedFolderIds(IEnumerable<FolderRoleViewModel> folderRoles)
        {
            var listOfAssignedFolders = folderRoles.Where(fr => fr.Assigned == true).Select(x => x.FolderId).ToList();
            var assignedIds = new string[listOfAssignedFolders.Count];
            for (int i = 0; i < listOfAssignedFolders.Count; i++)
            {
                assignedIds[i] = listOfAssignedFolders[i].ToString();
            }

            return assignedIds;
        }
    }
}
