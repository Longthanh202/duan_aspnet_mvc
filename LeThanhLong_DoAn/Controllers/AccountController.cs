using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeThanhLong_DoAn.ViewModels;
using LeThanhLong_DoAn.Identity;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace LeThanhLong_DoAn.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterVM rvm)
        {
            if(ModelState.IsValid)
            {
                var appDbContext = new AppDbContext();
                var userStore = new AppUserStore(appDbContext);
                var userManager = new AppUserManager(userStore);
                var passHash = Crypto.HashPassword(rvm.PassWord);
                var user = new AppUser()
                {
                    Email = rvm.Email,
                    UserName = rvm.UserName,
                    PasswordHash = passHash,
                    DiaChi = rvm.DiaChi,
                    PhoneNumber = rvm.Sdt
                };
                IdentityResult Iresult = userManager.Create(user);
                if(Iresult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "User");
                    var authenManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                }
                return RedirectToAction("index", "Home");
            }
            else
            {
                ModelState.AddModelError("New Error", "Dữ liệu không hợp lệ");
                return View();
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login lg)
        {
            var appDbContext = new AppDbContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);
            var user = userManager.Find(lg.UserName, lg.PassWord);
            if(user != null)
            {
                var authenManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                if(userManager.IsInRole(user.Id, "Admin"))
                {
                    return RedirectToAction("index", "Home", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("index", "home");
                }              
            }
            else
            {
                ModelState.AddModelError("New Error", "UserName và PassWord không hợp lệ");
                return View();
            }
        }
        public ActionResult Logout()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToAction("index", "home");
        }        
	}
}