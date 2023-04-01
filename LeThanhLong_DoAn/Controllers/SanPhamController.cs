using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeThanhLong_DoAn.Models;

namespace LeThanhLong_DoAn.Controllers
{
    public class SanPhamController : Controller
    {
        //
        // GET: /SanPham/
        public ActionResult Index(string search = "", int page = 1)
        {
            KetNoi db = new KetNoi();
            List<SanPham> lstSp = db.SanPham.Where(row => row.TenSanPham.Contains(search)).ToList();
            ViewBag.search = search;
            //phân trang
            int soMauTin = 10;
            int soTrang = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(lstSp.Count) / Convert.ToDouble(soMauTin)));
            int soSkip = (page - 1) * soMauTin;
            ViewBag.page = page;
            ViewBag.soTrang = soTrang;
            lstSp = lstSp.Skip(soSkip).Take(soMauTin).ToList(); 
            return View(lstSp);
        }        
	}
}