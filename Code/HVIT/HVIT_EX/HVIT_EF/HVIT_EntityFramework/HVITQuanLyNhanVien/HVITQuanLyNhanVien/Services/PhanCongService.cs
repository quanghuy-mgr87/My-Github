using HVITQuanLyNhanVien.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVITQuanLyNhanVien.Services
{
    class PhanCongService : IPhanCongService
    {
        private QuanLyNhanVienDbContext qLNVDbContext { get; }
        public PhanCongService()
        {
            qLNVDbContext = new QuanLyNhanVienDbContext();
        }
        public PhanCong CapNhatPhanCong(int phanCongId, PhanCong phanCong)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PhanCong> DanhSachPhanCong(int duAnId = int.MinValue, int nhanVienId = int.MinValue)
        {
            var query = qLNVDbContext.PhanCong.AsQueryable();
            if (duAnId != int.MinValue || nhanVienId != int.MinValue)
            {
                query = query.Where(phanCong => (phanCong.NhanVienId == nhanVienId || phanCong.DuAnId == duAnId));
            }
            return query;
        }

        public PhanCong ThemMoiPhanCong(PhanCong phanCong)
        {
            bool ok = qLNVDbContext.NhanVien.Any(val => val.Id == phanCong.NhanVienId);
            ok = qLNVDbContext.DuAn.Any(val => val.Id == phanCong.DuAnId);
            if (ok)
            {
                qLNVDbContext.PhanCong.Add(phanCong);
                qLNVDbContext.SaveChanges();
                return phanCong;
            }
            else
            {
                throw new Exception($"Ma du an hoac ma nhan vien sai!");
            }
        }

        public PhanCong TimPhanCongTheoId(int phanCongId)
        {
            throw new NotImplementedException();
        }

        public double TinhLuong(int nhanVienId)
        {
            if (qLNVDbContext.PhanCong.Any(phanCong => phanCong.NhanVienId == nhanVienId))
            {
                INhanVienService nhanVienService = new NhanVienService();
                var currentNV = nhanVienService.TimNhanVienTheoId(nhanVienId);
                var DSCongViec = DanhSachPhanCong(int.MinValue, nhanVienId);
                double TongLuong = 0;
                foreach (var val in DSCongViec)
                {
                    TongLuong += (double)currentNV.HeSoLuong * 15 * (double)val.SoGioLam;
                }
                return TongLuong;
            }
            else
            {
                throw new Exception($"Phan cong khong ton tai!");
            }
        }
    }
}
