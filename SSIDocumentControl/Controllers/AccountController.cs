using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SSIDocumentControl.Core;
using SSIDocumentControl.Data;
using SSIDocumentControl.Models.SystemModels;
using SSIDocumentControl.Repositories;
using SSIDocumentControl.Repositories.Users;
using SSIDocumentControl.ViewModels;

namespace SSIDocumentControl.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISignInManager _signInManager;        
        private readonly IUnitOfWork _unitOfWork;
         
        public AccountController(ISignInManager signInManager, IUnitOfWork unitOfWork)
        {            
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (await _unitOfWork.Users.ValidateCredentials(model.User, model.Password))
                {
                    var user = await _unitOfWork.Users.GetByUserName(model.User);
                    try
                    {
                        await _signInManager.SignInAsync(user);
                        await _unitOfWork.SystemRepo.LogSignIn(returnUrl, user.UserId);

                        if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl) && returnUrl != "/")
                            return Redirect(returnUrl);
                        else
                            return RedirectToAction("Index", "Documents");

                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    } 
                }

            }
            ModelState.AddModelError("", "The user name / password not found! :(");
            return View(model);

        }

       
        public async Task<IActionResult> Signout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
