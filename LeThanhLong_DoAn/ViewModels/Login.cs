using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LeThanhLong_DoAn.ViewModels
{
    public class Login
    {
        [Required(ErrorMessage = "UserName không được bỏ trống")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "PassWord không được bỏ trống")]
        public string PassWord { get; set; }
    }
}