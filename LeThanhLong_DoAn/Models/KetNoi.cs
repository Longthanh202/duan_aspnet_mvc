using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LeThanhLong_DoAn.Models
{
    public class KetNoi: DbContext
    {
        public KetNoi() : base("MyConnect") { }
        public DbSet<ThuongHieu> ThuongHieu { get; set; }
        public DbSet<SanPham> SanPham { get; set; }

        public DbSet<DanhMuc> DanhMuc { get; set; }
        public DbSet<CauHinh> CauHinh { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<ChiTiet> ChiTiet { get; set; }
    }
}