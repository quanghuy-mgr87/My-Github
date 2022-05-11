using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyPhongBan.Entities
{
    public class NhanVien
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public int PhongBanId { get; set; }
        public virtual PhongBan PhongBan { get; set; }
    }
}
