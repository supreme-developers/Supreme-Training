using SSIDocumentControl.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIDocumentControl.Models.SystemModels
{
   public interface ISignInManager
    {
        Task SignInAsync(RentUser user);
        Task SignOutAsync();
    }
}
