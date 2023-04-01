using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LeThanhLong_DoAn.Models
{
    public class DanhMuc
    {
        [Key]
        public long MaDanhMuc { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được bỏ trống")]
        public string TenDanhMuc { get; set; }
    }
}