using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn.Entities
{
    class HangHoa
    {
        public int id { get; set; }
        public int? loaiHangId { get; set; }
        public int? donViTinhId { get; set; }
        public string tenHang { get; set; }
        public double donGiaBan { get; set; }
        public string moTa { get; set; }
        public virtual IEnumerable<ChiTietHoaDonBan> ChiTietHoaDonBans { get; set; }
        public virtual IEnumerable<ChiTietHoaDonMua> ChiTietHoaDonMuas { get; set; }
        public virtual DonViTinh DonViTinh { get; set; }
        public virtual LoaiHang LoaiHang { get; set; }
        public virtual IEnumerable<ChiTietKho> ChiTietKhos { get; set; }
    }
}
