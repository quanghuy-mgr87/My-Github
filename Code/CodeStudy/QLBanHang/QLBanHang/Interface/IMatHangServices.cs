using QLBanHang.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Interface
{
    internal interface IMatHangServices
    {
        DataTable LayDSMatHang(int maMatHang = 0, string tenMatHang = null, int maDonVi = 0);
        MatHang LayThongTinMatHangTheoMa(int maMatHang = 0);
        bool ThemMatHang(MatHang matHang);
        bool SuaMatHang(MatHang matHang);
        bool XoaMatHang(int matHangId);
    }
}
