using QLBanHang.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Model
{
    public class HoaDon
    {
        public int HoaDonId { get; set; }
        public DateTime NgayLapHoaDon { get; set; }
        public double ThueSuat
        {
            get { return TongTienHang * 10.0 / 100; }
        }
        public double TongTienHang { get; set; }
        public string TongTienBangChu
        {
            get { return new DocSoHelper().DocSo((int)TongTienThanhToan); }
        }
        public double ThueGTGT
        {
            get { return TongTienHang * 1.0 / 100; }
        }
        public double TongTienThanhToan
        {
            get { return TongTienHang - ThueSuat - ThueGTGT; }
        }
        public int NguoiMuaHangId { get; set; }

        public HoaDon()
        {
        }

        public HoaDon(int hoaDonId, DateTime ngayLapHoaDon, double tongTienHang, int nguoiMuaHangId)
        {
            HoaDonId = hoaDonId;
            NgayLapHoaDon = ngayLapHoaDon;
            TongTienHang = tongTienHang;
            NguoiMuaHangId = nguoiMuaHangId;
        }
    }
}
