using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanHang.Entities
{
    public class HangHoa
    {
        public int id { get; set; }
        public string tenHang { get; set; }
        public string moTa { get; set; }
        public int? xuatXuId { get; set; }
        public IEnumerable<HoaDonBanChiTiet> hoaDonBanChiTiets { get; set; }
        public IEnumerable<HoaDonMuaChiTiet> hoaDonMuaChiTiets { get; set; }
        public QuocGia quocGia { get; set; }
        public HangHoa() { }
    }
}
