using HVITQuanLyNhanVien.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVITQuanLyNhanVien.Services
{
    interface INhanVienService
    {
        public IEnumerable<NhanVien> HienThiDSNhanVien(string keyword = null);
        public NhanVien TimNhanVienTheoId(int nhanVienId);
        public NhanVien ThemNhanVien(NhanVien nhanVien);
        public NhanVien SuaNhanVien(int nhanVienId, NhanVien nhanVien);
        public void XoaNhanVien(int nhanVienId);
    }
}
