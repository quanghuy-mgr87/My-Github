using QLBanHang.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Interface
{
    internal interface IChiTietHoaDonServices
    {
        DataTable LayDSChiTietHoaDon(int maHang = 0, int maHoaDon = 0, int maChiTiet = 0);
        bool ThemChiTietHoaDon(ChiTietHoaDon chiTietHoaDon);
        bool SuaChiTietHoaDon(ChiTietHoaDon chiTietHoaDon);
        bool XoaChiTietHoaDon(int chiTietHoaDonId);
    }
}
