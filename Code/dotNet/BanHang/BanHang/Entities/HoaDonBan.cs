using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanHang.Entities
{
    public class HoaDonBan
    {
        public int id { get; set; }
        public string tenHoaDon { get; set; }
        public string moTa { get; set; }
        public DateTime? ngayBan { get; set; }
        public int? maKhachHang { get; set; }
        public KhachHang khachHang { get; set; }
        public IEnumerable<HoaDonBanChiTiet> hoaDonBanChiTiets { get; set; }
        public HoaDonBan() { }
    }
}
