using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanHang.Entities
{
    public class HoaDonBanChiTiet
    {
        public int id { get; set; }
        public int? maHoaDon { get; set; }
        public int? maHang { get; set; }
        public int? soLuong { get; set; }
        public int? giaBan { get; set; }
        public HoaDonBan hoaDonBan { get; set; }
        public HangHoa hangHoa { get; set; }
        public HoaDonBanChiTiet() { }
    }
}
