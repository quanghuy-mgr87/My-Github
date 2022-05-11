using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QuanLyPhongBan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyPhongBan.Service
{
    public class NhanVienService : INhanVienService
    {
        private QuanLyPhongBanDbContext quanLyPhongBanDbContext { get; }
        public NhanVienService()
        {
            quanLyPhongBanDbContext = new QuanLyPhongBanDbContext();
        }
        public NhanVien CapNhatNhanVien(int nhanVienId, NhanVien nhanVien)
        {
            if (quanLyPhongBanDbContext.NhanVien.Any(nhanVien => nhanVien.Id == nhanVienId))
            {
                var currentNhanVien = LayNhanVienTheoMa(nhanVienId);
                currentNhanVien.HoTen = nhanVien.HoTen;
                currentNhanVien.DiaChi = nhanVien.DiaChi;
                currentNhanVien.SoDienThoai = nhanVien.SoDienThoai;
                currentNhanVien.Email = nhanVien.Email;
                currentNhanVien.PhongBanId = nhanVien.PhongBanId;
                quanLyPhongBanDbContext.SaveChanges();
                return currentNhanVien;
            }
            else
            {
                throw new Exception($"Nhan vien {nhanVienId} khong ton tai!");
            }
        }

        public IEnumerable<NhanVien> LayDanhSachNhanVien(string keyword = null)
        {
            var query = quanLyPhongBanDbContext.NhanVien.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();
                query = query.Where(nhanVien => nhanVien.HoTen.ToLower().Contains(keyword));
            }
            return query;
        }

        public NhanVien LayNhanVienTheoMa(int nhanVienId)
        {
            var nhanVien = quanLyPhongBanDbContext.NhanVien.Find(nhanVienId);
            return nhanVien;
        }

        public NhanVien TaoNhanVien(NhanVien nhanVien)
        {
            quanLyPhongBanDbContext.NhanVien.Add(nhanVien);
            quanLyPhongBanDbContext.SaveChanges();
            return nhanVien;
        }

        public void XoaNhanVien(int nhanVienId)
        {
            if (quanLyPhongBanDbContext.NhanVien.Any(nhanVien => nhanVien.Id == nhanVienId))
            {
                var currentNhanVien = LayNhanVienTheoMa(nhanVienId);
                quanLyPhongBanDbContext.NhanVien.Remove(currentNhanVien);
                quanLyPhongBanDbContext.SaveChanges();
            }
            else
            {
                throw new Exception($"Nhan vien {nhanVienId} khong ton tai!");
            }
        }
    }
}
