using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSIDocumentControl.ViewModels
{
    public class LoginViewModel
    {

        [Required]
        [Display(Name = "User Names")]

        public string User { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
