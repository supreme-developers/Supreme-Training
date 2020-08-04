using SSIDocumentControl.Core;
using SSIDocumentControl.Core.DocumentAuthorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSIDocumentControl.ViewModels
{
    public class RoleSetupViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<RentUser> AllUsers { get; set; }
        public List<RentUser> AssignedUsers { get; set; }
        public List<FolderRoleViewModel> FolderRoles { get; set; }
        public string AssignedUsersStringList { get; set; }
        public string AssignedFolerRoles { get; set; }

    }
}
