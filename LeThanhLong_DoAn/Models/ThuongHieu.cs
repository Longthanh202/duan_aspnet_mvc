using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LeThanhLong_DoAn.Models
{
    public class ThuongHieu
    {
        [Key]   
        public long MaThuongHieu { get; set; }
        [Required(ErrorMessage = "Tên thương hiệu không được bỏ trống")]
        public string TenThuongHieu { get; set; }
       
        public string HinhAnh { get; set; }
    }
}