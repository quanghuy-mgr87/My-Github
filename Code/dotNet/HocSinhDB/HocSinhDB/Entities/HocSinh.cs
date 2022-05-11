using System;
using System.Collections.Generic;
using System.Text;

namespace HocSinhDB.Entities
{
    public class HocSinh
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string TenLop { get; set; }
        public string Email { get; set; }
        public virtual QuanLyHS QuanLyHS { get; set; } 
    }
}
