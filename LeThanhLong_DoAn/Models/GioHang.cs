    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeThanhLong_DoAn.Models
{
    public class GioHang
    {
        KetNoi db = new KetNoi();
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public double DonGia { get; set; }
        public string HinhAnh { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien { get { return SoLuong * DonGia; } }

        public GioHang(int masp)
        {
            this.MaSP = masp;
            SanPham s = db.SanPham.FirstOrDefault(i => i.MaSanPham == this.MaSP);
            TenSP = s.TenSanPham;
            DonGia = double.Parse(s.Gia.ToString());
            HinhAnh = s.HinhAnh;
            SoLuong = 1;
        }
        public GioHang(int masp, int soluong)
        {
            this.MaSP = masp;
            SanPham s = db.SanPham.FirstOrDefault(i => i.MaSanPham == this.MaSP);
            TenSP = s.TenSanPham;
            DonGia = double.Parse(s.Gia.ToString());
            HinhAnh = s.HinhAnh;
            SoLuong = soluong;
        }
    }
}