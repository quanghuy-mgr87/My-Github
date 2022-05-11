using QLBanHang.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Interface
{
    internal interface IHoaDonServices
    {
        DataTable LayDSHoaDon(int maHoaDon = 0, DateTime? ngayLapHoaDon = null, int nguoiMuaHangId = 0);
        HoaDon LayThongTinHoaDonTheoMa(int maHoaDon = 0);
        bool ThemHoaDon(HoaDon hoaDon);
        bool SuaHoaDon(HoaDon hoaDon);
        bool XoaHoaDon(int maHoaDon);
    }
}
