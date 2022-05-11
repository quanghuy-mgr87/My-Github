using HVIT_EF_QLNgayHoc.Entities;
using HVIT_EF_QLNgayHoc.Helper;
using HVIT_EF_QLNgayHoc.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVIT_EF_QLNgayHoc.Services
{
    class HocVienService : IHocVienService
    {
        private QLKhoaHocDbContext dbContext { get; }
        public HocVienService()
        {
            dbContext = new QLKhoaHocDbContext();
        }
        public errType SuaThongTinHocVien(HocVien hocVien)
        {
            HocVien hocVien1 = dbContext.hocViens.SingleOrDefault(x => x.Id == hocVien.Id);
            KhoaHoc khoaHoc = dbContext.khoaHocs.SingleOrDefault(x => x.Id == hocVien.khoaHocId);
            if (khoaHoc == null)
            {
                return errType.KhoaHocKhongTonTai;
            }
            if (hocVien1 == null)
            {
                return errType.HocVienKhongTonTai;
            }
            else
            {
                hocVien1.khoaHocId = hocVien.khoaHocId;
                hocVien1.hoTen = hocVien.hoTen;
                hocVien1.ngaySinh = hocVien.ngaySinh;
                hocVien1.queQuan = hocVien.queQuan;
                hocVien1.diaChi = hocVien.diaChi;
                hocVien1.soDienThoai = hocVien.soDienThoai;
                dbContext.hocViens.Update(hocVien1);
                dbContext.SaveChanges();
                return errType.ThanhCong;
            }
        }

        public errType ThemHocVien(HocVien hocVien)
        {
            KhoaHoc khoaHoc = dbContext.khoaHocs.SingleOrDefault(x => x.Id == hocVien.khoaHocId);
            if (khoaHoc == null)
            {
                return errType.KhoaHocKhongTonTai;
            }
            else
            {
                hocVien.Id = 0;
                dbContext.hocViens.Add(hocVien);
                dbContext.SaveChanges();
                return errType.ThanhCong;
            }
        }

        public errType TimHocVien(HocVien hocVien)
        {
            HocVien hocVien1 = dbContext.hocViens.SingleOrDefault(x => x.hoTen.Contains(hocVien.hoTen) && x.khoaHocId == hocVien.khoaHocId);
            if (hocVien1 == null)
            {
                return errType.HocVienKhongTonTai;
            }
            Console.WriteLine($"Hoc vien can tim: Id: {hocVien1.Id}, ho ten: {hocVien1.hoTen}, khoa hoc id: {hocVien.khoaHocId}");
            return errType.ThanhCong;
        }
    }
}
