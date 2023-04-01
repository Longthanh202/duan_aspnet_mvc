using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeThanhLong_DoAn.Models;

namespace LeThanhLong_DoAn.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            //KetNoi db = new KetNoi();
            //ViewBag.ThuongHieu = db.ThuongHieu.ToList();
            //ViewBag.SanPham = db.SanPham.ToList();
            return View();
        }  
        public ActionResult ThuongHieu()
        {
            KetNoi db = new KetNoi();
            List<ThuongHieu> lst = db.ThuongHieu.ToList();
            return PartialView(lst);
        }

        public ActionResult SanPhamNoiBac()
        {
            KetNoi db = new KetNoi();
            List<SanPham> lst = db.SanPham.Take(10).ToList();
            return PartialView(lst);
        }

        public ActionResult SanPhamTheoThuongHieu(int id)
        {
            KetNoi db = new KetNoi();
            List<SanPham> lst = db.SanPham.Where(row => row.MaThuongHieu == id).ToList();
            return View(lst);
        }

        public List<GioHang> LayGioHang()
        {
            List<GioHang> ds_gioHang = Session["GioHang"] as List<GioHang>;
            if (ds_gioHang == null)
            {
                ds_gioHang = new List<GioHang>();
                Session["GioHang"] = ds_gioHang;
            }
            return ds_gioHang;
        }
        public ActionResult ThemVaoGioHang(int id)
        {
            List<GioHang> ds_gioHang = LayGioHang();
            GioHang sanpham = ds_gioHang.Find(GioHang => GioHang.MaSP == id);
            if (sanpham == null)
            {
                sanpham = new GioHang(id);
                ds_gioHang.Add(sanpham);
                Session["soluong"] = ds_gioHang.Count.ToString();
                return RedirectToAction("Index", "Home");
            }
            sanpham.SoLuong += 1;
            Session["soluong"] = ds_gioHang.Count.ToString();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                ViewBag.giohang = "gio hang rong";
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> ds_GioHang = LayGioHang();
            return View(ds_GioHang);
        }
        public ActionResult XoaSanPhamKhoiGioHang(int id)
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> ds_gioHang = Session["GioHang"] as List<GioHang>;
            foreach (var item in ds_gioHang)
            {
                if (item.MaSP == id)
                {
                    ds_gioHang.Remove(item);
                    return RedirectToAction("GioHang", "Home", ds_gioHang);
                }
            }
            return View("GioHang", ds_gioHang);
        }
        [HttpPost]
        public ActionResult LuuGioHang(FormCollection colect, int id)
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            int soluong = int.Parse(colect.Get("sl"));
            List<GioHang> ds_gioHang = Session["GioHang"] as List<GioHang>;
            foreach (var item in ds_gioHang)
            {
                if (item.MaSP == id)
                {
                    item.SoLuong = soluong;
                    return RedirectToAction("GioHang", "Home", ds_gioHang);
                }
            }
            return View("GioHang", ds_gioHang);
        }
        public ActionResult XacNhanDatHang()
        {
            KhachHang k = new KhachHang();
            if (Session["k"] != null)
            {
                k = (KhachHang)Session["k"];
            }
            else
            {
                k.TenKhachHang = "";
                k.SDT = "";
                ViewBag.Dn = "Chưa đăng nhập";
            }
            return View(k);
        }
        [HttpPost]
        public ActionResult XacNhanDatHang(FormCollection colect)
        {
            if (Session["k"] != null)
            {
                KhachHang k = (KhachHang)Session["k"];
                if (k.TenKhachHang != "")
                {
                    DonDatHang d = new DonDatHang();
                    DateTime now = DateTime.Now;
                    string cachNhanHang = colect.Get("pt");
                    int max = dl.DonDatHangs.Max(i => i.idDDH);
                    d.idDDH = max + 1;
                    d.idKhachHang = k.idKH;
                    d.NgayDatHang = now;
                    d.HinhThucGiaoHang = cachNhanHang;
                    d.GhiChu = colect.Get("yeucau");
                    dl.DonDatHangs.InsertOnSubmit(d);
                    dl.SubmitChanges();
                    List<GioHang> ds_gioHang = Session["GioHang"] as List<GioHang>;
                    foreach (var item in ds_gioHang)
                    {
                        ChiTietDDH ct = new ChiTietDDH();
                        ct.idDDH = d.idDDH;
                        ct.idSP = item.MaSP;
                        ct.SoLuong = item.SoLuong;
                        dl.ChiTietDDHs.InsertOnSubmit(ct);
                        dl.SubmitChanges();
                    }
                    RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("GioHang", "Home");
        }
	}
}