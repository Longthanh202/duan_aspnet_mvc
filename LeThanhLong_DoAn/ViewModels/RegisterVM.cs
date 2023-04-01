using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LeThanhLong_DoAn.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage ="UserName không được bỏ trống")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "PassWord không được bỏ trống")]
        public string PassWord { get; set; }
        [Required(ErrorMessage = "ConfirmPassWord không được bỏ trống")]
        [Compare("PassWord", ErrorMessage = "PassWord và ConfirmPassWord do not match")]
        public string ConfirmPass { get; set; }

        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Số điện thoại không được bỏ trống")]
        public string Sdt { get; set; }
        public string DiaChi { get; set; }
    }
}