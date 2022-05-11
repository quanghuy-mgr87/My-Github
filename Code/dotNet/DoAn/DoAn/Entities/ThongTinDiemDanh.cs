using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn.Entities
{
    class ThongTinDiemDanh
    {
        public int id { get; set; }
        public int? nhanVienId { get; set; }
        public int? chiTietBangLuongId { get; set; }
        public DateTime? ngayDiemDanh { get; set; }
        public int? diemDanh { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual ChiTietBangLuong ChiTietBangLuong { get; set; }
    }
}
