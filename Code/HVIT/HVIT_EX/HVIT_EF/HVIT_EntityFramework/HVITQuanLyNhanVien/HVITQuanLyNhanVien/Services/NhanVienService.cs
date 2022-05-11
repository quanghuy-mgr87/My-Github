using HVITQuanLyNhanVien.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVITQuanLyNhanVien.Services
{
    class NhanVienService : INhanVienService
    {
        private QuanLyNhanVienDbContext qLNVDbContext { get; }
        public NhanVienService()
        {
            qLNVDbContext = new QuanLyNhanVienDbContext();
        }
        public IEnumerable<NhanVien> HienThiDSNhanVien(string keyword = null)
        {
            var query = qLNVDbContext.NhanVien.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();
                query = query.Where(nhanVien => nhanVien.HoTen.ToLower().Contains(keyword));
            }
            return query;
        }

        public NhanVien SuaNhanVien(int nhanVienId, NhanVien nhanVien)
        {
            if (qLNVDbContext.NhanVien.Any(nhanVien => nhanVien.Id == nhanVienId))
            {
                var currentNV = TimNhanVienTheoId(nhanVienId);
                currentNV.HoTen = nhanVien.HoTen;
                currentNV.SDT = nhanVien.SDT;
                currentNV.DiaChi = nhanVien.DiaChi;
                currentNV.Email = nhanVien.Email;
                currentNV.HeSoLuong = nhanVien.HeSoLuong;
                currentNV.PhanCongId = nhanVien.PhanCongId;
                qLNVDbContext.NhanVien.Update(currentNV);
                qLNVDbContext.SaveChanges();
                return currentNV;
            }
            else
            {
                throw new Exception($"Nhan vien khong ton tai!");
            }
        }

        public NhanVien ThemNhanVien(NhanVien nhanVien)
        {
            qLNVDbContext.NhanVien.Add(nhanVien);
            qLNVDbContext.SaveChanges();
            return nhanVien;
        }

        public NhanVien TimNhanVienTheoId(int nhanVienId)
        {
            var nhanVien = qLNVDbContext.NhanVien.Find(nhanVienId);
            return nhanVien;
        }

        public void XoaNhanVien(int nhanVienId)
        {
            if (qLNVDbContext.NhanVien.Any(nhanVien => nhanVien.Id == nhanVienId))
            {
                var currentNV = TimNhanVienTheoId(nhanVienId);
                qLNVDbContext.NhanVien.Remove(currentNV);
                qLNVDbContext.SaveChanges();
            }
        }
    }
}
