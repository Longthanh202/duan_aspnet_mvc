using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeThanhLong_DoAn.Filter;

namespace LeThanhLong_DoAn.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Admin/Home/
        [Authorization]
        public ActionResult Index()
        {
            return View();
        }
	}
}