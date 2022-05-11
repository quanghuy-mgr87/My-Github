using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn.Entities
{
    class ChiTietHoaDonMua
    {
        public int id { get; set; }
        public int? hangHoaId { get; set; }
        public int? hoaDonMuaId { get; set; }
        public int? soLuong { get; set; }
        public double? giaMua { get; set; }
        public double? thanhTien { get; set; }
        public virtual HangHoa HangHoa { get; set; }
        public virtual HoaDonMua HoaDonMua { get; set; }
    }
}
