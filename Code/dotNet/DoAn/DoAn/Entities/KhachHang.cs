using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn.Entities
{
    class KhachHang
    {
        public int id { get; set; }
        public string hoTen { get; set; }
        public string diaChi { get; set; }
        public string soDienThoai { get; set; }
        public virtual IEnumerable<HoaDonBan> HoaDonBans { get; set; }
    }
}
