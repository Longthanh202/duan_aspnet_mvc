using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LeThanhLong_DoAn.Identity
{
    public class AppUser: IdentityUser
    {
        public DateTime? NgaySinh { get; set; }
        public string DiaChi { get; set; }
    }
}