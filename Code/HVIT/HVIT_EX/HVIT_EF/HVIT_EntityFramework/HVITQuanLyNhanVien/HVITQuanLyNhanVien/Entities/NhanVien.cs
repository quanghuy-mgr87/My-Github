using System;
using System.Collections.Generic;
using System.Text;

namespace HVITQuanLyNhanVien.Entities
{
    public class NhanVien
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public double? HeSoLuong { get; set; }
        public int? PhanCongId { get; set; }
        public virtual PhanCong PhanCong { get; set; }
    }
}
