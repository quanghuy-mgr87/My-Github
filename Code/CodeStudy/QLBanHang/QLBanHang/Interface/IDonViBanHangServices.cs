using QLBanHang.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Interface
{
    internal interface IDonViBanHangServices
    {
        DataTable LayDSDonViBanHang(int maDonVi = 0, string tenDonVi = null, string sdt = null);
        DonViBanHang TimDonViTheoMa(int maDonVi = 0, string sdt = null);
        bool ThemDonViBanHang(DonViBanHang donViBanHang);
        bool SuaDonViBanHang(DonViBanHang donViBanHang);
        bool XoaDonViBanHang(int donViBangHangId);
    }
}
