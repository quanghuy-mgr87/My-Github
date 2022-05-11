using QLBanHang.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Interface
{
    internal interface INguoiMuaHangServices
    {
        DataTable LayDSNguoiMuaHang(int nguoiMuaHangId = 0, string hoTen = null, string maSoThue = null, string stk = null);
        NguoiMuaHang TimThongTinNguoiMuaTheoMa(int nguoiMuaHangId = 0, string stk = null);
        bool ThemNguoiMuaHang(NguoiMuaHang nguoiMuaHang);
        bool SuaThongTinNguoiMuaHang(NguoiMuaHang nguoiMuaHang);
        bool XoaNguoiMuaHang(int nguoiMuaHangId);
    }
}
