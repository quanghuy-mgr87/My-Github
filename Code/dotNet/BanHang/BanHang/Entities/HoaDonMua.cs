using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanHang.Entities
{
    public class HoaDonMua
    {
        public int id { get; set; }
        public string tenHoaDon { get; set; }
        public string moTa { get; set; }
        public DateTime? ngayMua { get; set; }
        public IEnumerable<HoaDonMuaChiTiet> hoaDonMuaChiTiets { get; set; }
        public HoaDonMua() { }
    }
}
