using HVITQuanLyHS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVITQuanLyHS.Services
{
    interface ILopService
    {
        IEnumerable<Lop> LayDanhSachLop(string keyword = null);
        Lop LayLopTheoMa(int lopId);
        Lop SuaThongTinLop(int lopId, Lop lop);
    }
}
