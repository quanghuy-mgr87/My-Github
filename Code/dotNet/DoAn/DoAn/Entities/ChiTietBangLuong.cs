using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn.Entities
{
    class ChiTietBangLuong
    {
        public int id { get; set; }
        public int? bangLuongId { get; set; }
        public double? luongCoBan { get; set; }
        public double? phuCap { get; set; }
        public double? baoHiem { get; set; }
        public double? heSoLuong { get; set; }
        public int? tongNgayCong { get; set; }
        public virtual IEnumerable<ThongTinDiemDanh> ThongTinDiemDanhs { get; set; }
        public virtual BangLuong BangLuong { get; set; }
    }
}
