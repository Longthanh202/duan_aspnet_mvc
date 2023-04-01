using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LeThanhLong_DoAn.Models
{
    public class ChiTiet
    {
        [Key]
        public Nullable<long> MaSp { get; set; }
        public Nullable<long> MaHd{ get; set; }
        public Nullable<int> SoLuong { get; set; }
        public virtual SanPham SanPham { get; set; }
        public virtual HoaDon HoaDon { get; set; }
    }
}