using QuanLyPhongBan.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyPhongBan.Service
{
    interface INhanVienService
    {
        IEnumerable<NhanVien> LayDanhSachNhanVien(string keyword = null);
        NhanVien LayNhanVienTheoMa(int nhanVienId);
        NhanVien TaoNhanVien(NhanVien nhanVien);
        NhanVien CapNhatNhanVien(int nhanVienId, NhanVien nhanVien);
        void XoaNhanVien(int nhanVienId);
    }
}
