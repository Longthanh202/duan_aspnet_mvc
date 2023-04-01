using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeThanhLong_DoAn.Models;
using LeThanhLong_DoAn.Filter;

namespace LeThanhLong_DoAn.Areas.Admin.Controllers
{
    public class DanhMucController : Controller
    {
        //
        // GET: /Admin/DanhMuc/
        [Authorization]
        public ActionResult Index()
        {
            KetNoi db = new KetNoi();
            List<DanhMuc> lstDm = db.DanhMuc.ToList();
            return View(lstDm);
        }
	}
}