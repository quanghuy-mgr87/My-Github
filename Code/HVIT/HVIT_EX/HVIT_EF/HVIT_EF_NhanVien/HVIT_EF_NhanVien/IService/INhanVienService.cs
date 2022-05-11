using HVIT_EF_NhanVien.Entities;
using HVIT_EF_NhanVien.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_NhanVien.IService
{
    interface INhanVienService
    {
        public errType ThemMoiNhanVien(NhanVien nhanVien);
        public errType XoaNhanVien(NhanVien nhanVien);
        public void TinhLuong(NhanVien nhanVien);
    }
}
