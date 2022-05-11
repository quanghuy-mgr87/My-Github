using HVITQuanLyNhanVien.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVITQuanLyNhanVien.Services
{
    interface IPhanCongService
    {
        public IEnumerable<PhanCong> DanhSachPhanCong(int duAnId = int.MinValue, int nhanVienId = int.MinValue);
        public PhanCong TimPhanCongTheoId(int phanCongId);
        public PhanCong CapNhatPhanCong(int phanCongId, PhanCong phanCong);
        public PhanCong ThemMoiPhanCong(PhanCong phanCong);
        public double TinhLuong(int nhanVienId);
    }
}
