using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Equipment.Admin.MVC.UI.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            Equipment.Get.Core.Helpers.Out.AppUser appUser = new Get.Core.Helpers.Out.AppUser();
            return View(appUser);
        }

        [HttpPost]
        public IActionResult Login(Get.Core.Helpers.Out.AppUser appUser)
        {
            AppApiServices appApiServices = new AppApiServices();            
            //Check the user name and password
            //Here can be implemented checking logic from the database  
            ClaimsIdentity identity = null;
            bool isAuthenticated = false;

            if (appApiServices.AppLoginService(appUser) != null)
            {

                //Create the identity for the user  
                identity = new ClaimsIdentity(new[] {
                   new Claim(ClaimTypes.Name, appUser.UserID),
                    new Claim(ClaimTypes.Role, "Admin")
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                isAuthenticated = true;
            }

            if (isAuthenticated)
            {
                var principal = new ClaimsPrincipal(identity);

                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("dashboard","Home");
            }
            else
            {
                ViewBag.Message = "Invalid Username/Password!";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
