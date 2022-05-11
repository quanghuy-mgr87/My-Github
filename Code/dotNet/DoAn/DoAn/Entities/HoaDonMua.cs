using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn.Entities
{
    class HoaDonMua
    {
        public int id { get; set; }
        public int? nhaCungCapId { get; set; }
        public string soTaiKhoan { get; set; }
        public DateTime? ngayLap { get; set; }
        public double? tongTien { get; set; }
        public virtual IEnumerable<ChiTietHoaDonMua> ChiTietHoaDonMuas { get; set; }
        public virtual NhaCungCap NhaCungCap { get; set; }
    }
}
