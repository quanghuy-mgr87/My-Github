using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn.Entities
{
    class HoaDonBan
    {
        public int id { get; set; }
        public int? khachHangId { get; set; }
        public int? nhanVienId { get; set; }
        public string diaChi { get; set; }
        public string maSoThue { get; set; }
        public string soTaiKhoan { get; set; }
        public DateTime? ngayBan { get; set; }
        public double? tongTien { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual IEnumerable<ChiTietHoaDonBan> ChiTietHoaDonBans { get; set; }
    }
}
