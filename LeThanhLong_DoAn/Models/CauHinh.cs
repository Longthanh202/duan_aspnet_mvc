using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LeThanhLong_DoAn.Models
{
    public class CauHinh
    {
        [Key]
        public long MaCauHinh { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string OCung { get; set; }
        public string ManHinh { get; set; }
        public string CardManHinh { get; set; }
        public string KetNoi { get; set; }
        public string HeDieuHanh { get; set; }
    }
}