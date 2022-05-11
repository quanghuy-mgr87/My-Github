using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn.Entities
{
    class ChiTietHoaDonBan
    {
        public int id { get; set; }
        public int? hangHoaId { get; set; }
        public int? hoaDonBanId { get; set; }
        public int? soLuong { get; set; }
        public double? thanhTien { get; set; }
        public virtual HoaDonBan HoaDonBan { get; set; }
        public virtual HangHoa HangHoa { get; set; }
    }
}
