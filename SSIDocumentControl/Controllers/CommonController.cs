using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SSIDocumentControl.Controllers
{
    public class CommonController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult ProgramError()
        {
            return View();
        }
    }
}