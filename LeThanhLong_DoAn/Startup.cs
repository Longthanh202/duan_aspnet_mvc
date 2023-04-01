using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.Cookies;
using LeThanhLong_DoAn.Identity;

[assembly: OwinStartup(typeof(LeThanhLong_DoAn.Startup))]

namespace LeThanhLong_DoAn
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            this.TaoRoleVaUser();
        }
        public void TaoRoleVaUser()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new AppDbContext()));
            var appDbContext = new AppDbContext();
            var appUserStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(appUserStore);
            if(!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
            if(userManager.FindByName("admin") == null)
            {
                var user = new AppUser();
                user.UserName = "longlt";
                user.Email = "longlt@gmail.com";
                string Pass = "long123";
                var chkUser = userManager.Create(user, Pass);
                if(chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }
            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);
            }
        }
    }
}
