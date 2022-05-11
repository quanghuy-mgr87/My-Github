using HVITQuanLyNhanVien.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVITQuanLyNhanVien.Services
{
    interface IDuAnService
    {
        public IEnumerable<DuAn> HienThiDSDuAn(string keyword = null);
        public DuAn TimDuAnTheoId(int duAnId);
        public DuAn ThemDuAn(DuAn duAn);
        public DuAn SuaDuAn(int duAnId, DuAn duAn);
        public void XoaDuAn(int duAnId);
    }
}
