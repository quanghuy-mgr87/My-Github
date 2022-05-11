using HVIT_EF_NhanVien.Entities;
using HVIT_EF_NhanVien.Helper;
using HVIT_EF_NhanVien.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVIT_EF_NhanVien.Service
{
    class NhanVienService : INhanVienService
    {
        private DuAnDbContext dbContext { get; }
        public NhanVienService()
        {
            dbContext = new DuAnDbContext();
        }

        public void TinhLuong(NhanVien nhanVien)
        {
            NhanVien nhanVien1 = dbContext.nhanViens.SingleOrDefault(x => x.Id == nhanVien.Id);
            if (nhanVien1 == null)
            {
                errHelper.log(errType.KhongTonTaiNhanVien);
            }
            else
            {
                double luong = (double)nhanVien1.heSoLuong * 15 * dbContext.phanCongs.Where(x => (int)x.nhanVienId == nhanVien.Id).Sum(x => (int)x.soGioLam);
                Console.WriteLine($"Luong cua nhan vien {nhanVien1.hoTen} la: {luong}");
            }
        }

        public errType XoaNhanVien(NhanVien nhanVien)
        {
            if (dbContext.nhanViens.Any(x => x.Id == nhanVien.Id))
            {
                List<PhanCong> lstPhanCong = dbContext.phanCongs.Where(x => x.nhanVienId == nhanVien.Id).ToList();
                lstPhanCong.ForEach(x => dbContext.phanCongs.Remove(x));
                dbContext.SaveChanges();   //xoá xong trong bảng phân công xong phải update thì mới xoá đc ở bảng nhân viên
                NhanVien currentNhanVien = dbContext.nhanViens.Find(nhanVien.Id);
                dbContext.nhanViens.Remove(currentNhanVien);
                dbContext.SaveChanges();
                return errType.ThanhCong;
            }
            else
            {
                return errType.KhongTonTaiNhanVien;
            }
        }

        public errType ThemMoiNhanVien(NhanVien nhanVien)
        {
            nhanVien.Id = 0;
            dbContext.nhanViens.Add(nhanVien);
            dbContext.SaveChanges();
            return errType.ThanhCong;
        }
    }
}
