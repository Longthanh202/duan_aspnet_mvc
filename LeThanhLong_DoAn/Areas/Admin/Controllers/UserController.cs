using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeThanhLong_DoAn.Identity;
using LeThanhLong_DoAn.Filter;

namespace LeThanhLong_DoAn.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /Admin/User/
        [Authorization]
        public ActionResult Index()
        {
            AppDbContext db = new AppDbContext();
            List<AppUser> lst = db.Users.ToList();
            return View(lst);
        }
	}
}