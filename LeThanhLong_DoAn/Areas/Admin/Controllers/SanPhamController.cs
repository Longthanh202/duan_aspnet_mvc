using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeThanhLong_DoAn.Models;
using System.IO;
using LeThanhLong_DoAn.Filter;

namespace LeThanhLong_DoAn.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        //
        // GET: /Admin/SanPham/
        KetNoi db = new KetNoi();
        [Authorization]
        public ActionResult Index(string search = "", int page = 1,
            string sortColumn = "MaSanPham", string Icon = "fa-sort-asc")
        {
            //search
            List<SanPham> lstSp = db.SanPham.Where(row => row.TenSanPham.Contains(search)).ToList();
            ViewBag.search = search;
            //phân trang
            int soMauTin = 3;
            int soTrang = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(lstSp.Count) / Convert.ToDouble(soMauTin)));
            int soSkip = (page - 1) * soMauTin;
            ViewBag.page = page;
            ViewBag.soTrang = soTrang;
            lstSp = lstSp.Skip(soSkip).Take(soMauTin).ToList();  
         
            //sort
            ViewBag.sortColumn = sortColumn;
            ViewBag.Icon = Icon;
            if(sortColumn == "MaSanPham")
            {
                if(Icon == "fa-sort-asc")
                {
                    lstSp = lstSp.OrderBy(row => row.MaSanPham).ToList();
                }
                else
                {
                    lstSp = lstSp.OrderByDescending(row => row.MaSanPham).ToList();
                }
            }
            else if(sortColumn == "TenSanPham")
            {
                if (Icon == "fa-sort-asc")
                {
                    lstSp = lstSp.OrderBy(row => row.TenSanPham).ToList();
                }
                else
                {
                    lstSp = lstSp.OrderByDescending(row => row.TenSanPham).ToList();
                }
            }
            else if (sortColumn == "Gia")
            {
                if (Icon == "fa-sort-asc")
                {
                    lstSp = lstSp.OrderBy(row => row.Gia).ToList();
                }
                else
                {
                    lstSp = lstSp.OrderByDescending(row => row.Gia).ToList();
                }
            }
            return View(lstSp);
        }
        public ActionResult Them()
        {
            ViewBag.ThuongHieu = db.ThuongHieu.ToList();
            ViewBag.DanhMuc = db.DanhMuc.ToList();
            ViewBag.CauHinh = db.CauHinh.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Them(SanPham p, HttpPostedFileBase imgFile)
        {

            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/img/"), Path.GetFileName(imgFile.FileName));
                imgFile.SaveAs(path);
                SanPham temp = p;
                temp.HinhAnh = imgFile.FileName;
                db.SanPham.Add(temp);
                db.SaveChanges();
                return RedirectToAction("index", "SanPham");
            }
            else
            {
                return RedirectToAction("them", "sanpham");
            }

        }
        public ActionResult ChiTietSanPham(int id)
        {
            SanPham sp = db.SanPham.Where(row => row.MaSanPham == id).FirstOrDefault();
            return View(sp);
        }
        public ActionResult Xoa(int id)
        {
            SanPham p = db.SanPham.Where(row => row.MaSanPham == id).FirstOrDefault();
            return View(p);
        }
        [HttpPost]
        public ActionResult Xoa(int id, SanPham temp)
        {
            SanPham p = db.SanPham.Where(row => row.MaSanPham == id).FirstOrDefault();
            db.SanPham.Remove(p);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult CapNhat(int id)
        {
            SanPham p = db.SanPham.Where(row => row.MaSanPham == id).FirstOrDefault();
            ViewBag.ThuongHieu = db.ThuongHieu.ToList();
            ViewBag.DanhMuc = db.DanhMuc.ToList();
            ViewBag.CauHinh = db.CauHinh.ToList();
            return View(p);
        }
        [HttpPost]
        public ActionResult CapNhat(SanPham p, HttpPostedFileBase img)
        {
            string path = Path.Combine(Server.MapPath("~/img/"), Path.GetFileName(img.FileName));
            img.SaveAs(path);          
            SanPham sp = db.SanPham.Where(row => row.MaSanPham == p.MaSanPham).FirstOrDefault();
            SanPham tam = p;
            tam.HinhAnh = img.FileName;
            sp.TenSanPham = tam.TenSanPham;
            sp.Gia = tam.Gia;
            sp.ChiTietSanPham = tam.ChiTietSanPham;
            sp.MaThuongHieu = tam.MaThuongHieu;
            sp.MaDanhMuc = tam.MaDanhMuc;
            sp.MaCauHinh = tam.MaCauHinh;
            db.SaveChanges();
            return View(sp);
        }
	}
}