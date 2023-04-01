using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeThanhLong_DoAn.Models;
using LeThanhLong_DoAn.Filter;

namespace LeThanhLong_DoAn.Areas.Admin.Controllers
{
    public class ThuongHieuController : Controller
    {
        //
        // GET: /Admin/ThuongHieu/
        [Authorization]
        public ActionResult Index()
        {
            KetNoi db = new KetNoi();
            List<ThuongHieu> lstTh = db.ThuongHieu.ToList();
            return View(lstTh);
        }
	}
}