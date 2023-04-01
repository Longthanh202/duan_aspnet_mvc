using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeThanhLong_DoAn.Models
{
    public class CartItem
    {
        public long Masp { get; set; }
        public string Tensp { get; set; }
        public string Anh { get; set; }
        public double Gia { get; set; }
        public int Soluong { get; set; }
        public double ThanhTien
        {
            get { return Soluong * Gia; }
        }
        KetNoi db = new KetNoi();
        public CartItem (int MaSp)
        {
            SanPham sp = db.SanPham.Where(row => row.MaSanPham == MaSp).FirstOrDefault();
            if(sp != null)
            {
                Masp = MaSp;
                Tensp = sp.TenSanPham;
                Anh = sp.HinhAnh;
                Gia = Convert.ToDouble(sp.Gia.ToString());
                Soluong = 1;
            }
        }
    }
}