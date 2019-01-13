using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrainingCentreManagement.Models;
using TrainingCentreManagement.Models.EntityModels;
using TrainingCentreManagement.Models.EntityModels.IdentityEntities;

namespace TrainingCentreManagement.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        
      
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login(string returnUrl)
        {
           
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(returnUrl))
                    {
                        returnUrl = "~/";
                    }

                    return LocalRedirect(returnUrl);
                }
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser()
                {
                    UserName = model.UserName,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var signInResult = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, false, false);
                    if (signInResult.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }


            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        
    }
}