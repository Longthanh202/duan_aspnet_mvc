using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LeThanhLong_DoAn.Models
{
    public class HoaDon
    {
        [Key]
        public long MaHoaDon { get; set; }
        public DateTime? NgayLap { get; set; }

        public Nullable<long> MaKhachHang { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}