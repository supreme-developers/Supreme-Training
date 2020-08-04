using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SSIDocumentControl.Core;
using SSIDocumentControl.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SSIDocumentControl.Models.SystemModels
{
    public class SignInManager:ISignInManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public SignInManager(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public async Task SignInAsync(RentUser user)
        {
            var isAdmin = await _unitOfWork.Users.IsAdministrator(user);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.FirstName + ' ' + user.LastName),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim("OfficeID", user.OfficeId.ToString())
            };
            if (isAdmin)
                claims.Add(new Claim("Admin", "true"));

            var identity = new ClaimsIdentity(claims, "local", "name", "role");
            var principal = new ClaimsPrincipal(identity);
            await AuthenticationHttpContextExtensions.SignInAsync(_httpContextAccessor.HttpContext, principal);
            
           // await _httpContextAccessor.HttpContext.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        public async Task SignOutAsync()
        {
            await AuthenticationHttpContextExtensions.SignOutAsync(_httpContextAccessor.HttpContext);
        }
    }
}
