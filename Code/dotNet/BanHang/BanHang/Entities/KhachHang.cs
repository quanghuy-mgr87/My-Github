using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanHang.Entities
{
    public class KhachHang
    {
        public int id { get; set; }
        public string tenKhachHang { get; set; }
        public string dienThoai { get; set; }
        public string email { get; set; }
        public string diaChi { get; set; }
        public int? maLoaiKhachHang { get; set; }
        public LoaiKhachHang loaiKhachHang { get; set; }
        public IEnumerable<HoaDonBan> hoaDonBans { get; set; }
        public KhachHang() { }
    }
}
