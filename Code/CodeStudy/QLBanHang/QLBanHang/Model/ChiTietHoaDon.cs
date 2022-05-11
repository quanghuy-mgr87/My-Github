using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Model
{
    internal class ChiTietHoaDon
    {
        public int ChiTietHoaDonId { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien { get; set; }
        public int HoaDonId { get; set; }
        public int MaHang { get; set; }

        public ChiTietHoaDon()
        {
        }

        public ChiTietHoaDon(int chiTietHoaDonId, int soLuong, double thanhTien, int hoaDonId, int maHang)
        {
            ChiTietHoaDonId = chiTietHoaDonId;
            SoLuong = soLuong;
            ThanhTien = thanhTien;
            HoaDonId = hoaDonId;
            MaHang = maHang;
        }
    }
}
