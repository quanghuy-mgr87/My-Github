using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn.Entities
{
    class NhanVien
    {
        public int id { get; set; }
        public int? chucVuId { get; set; }
        public int? phongBanId { get; set; }
        public string hoTen { get; set; }
        public string diaChi { get; set; }
        public DateTime? ngaySinh { get; set; }
        public string soDienThoai { get; set; }
        public DateTime? ngayBatDau { get; set; }
        public virtual PhongBan PhongBan { get; set; }
        public virtual IEnumerable<ThongTinDiemDanh> ThongTinDiemDanhs { get; set; }
        public virtual ChucVu ChucVu { get; set; }
        public virtual IEnumerable<HoaDonBan> HoaDonBans { get; set; }

    }
}
