using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LeThanhLong_DoAn.Models
{
    public class SanPham
    {
        [Key]
        public long MaSanPham { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được bỏ trống")]
        public string TenSanPham { get; set; }

        [DisplayFormat(DataFormatString="{0:C}")]
        [Required(ErrorMessage = "Giá sản phẩm không được bỏ trống")]
        public float Gia { get; set; }

        [Required(ErrorMessage = "Chi tiết sản phẩm không được bỏ trống")]
        public string ChiTietSanPham { get; set; }
        
        public string HinhAnh { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn thương hiệu")]
        public Nullable<long> MaThuongHieu { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn danh mục")]
        public Nullable<long> MaDanhMuc { get; set; }

        public Nullable<long> MaCauHinh { get; set; }

        public virtual ThuongHieu ThuongHieu { get; set; }
        public virtual DanhMuc DanhMuc { get; set; }
        public virtual CauHinh CauHinh { get; set; }
    
    }
}