using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSIDocumentControl.Core
{
   public class RentUser: IdentityUser
    {
        public int UserId { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? OfficeId { get; set; }
        public bool Active { get; set; }
        [NotMapped]
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

    }
}
