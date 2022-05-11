using HVIT_EF_QLNgayHoc.Entities;
using HVIT_EF_QLNgayHoc.Helper;
using HVIT_EF_QLNgayHoc.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVIT_EF_QLNgayHoc.Services
{
    class KhoaHocService : IKhoaHocService
    {
        private QLKhoaHocDbContext dbContext { get; }
        public KhoaHocService()
        {
            dbContext = new QLKhoaHocDbContext();
        }
        public errType ThemNgayChoKhoaHoc(KhoaHoc khoaHoc)
        {
            KhoaHoc khoaHoc1 = dbContext.khoaHocs.SingleOrDefault(x => x.Id == khoaHoc.Id);
            if (khoaHoc1 == null)
            {
                return errType.KhoaHocKhongTonTai;
            }
            int ngay = khoaHoc1.ngayKetThuc.Subtract(khoaHoc1.ngayBatDau).Days;
            if (ngay >= 15)
            {
                return errType.SoNgayToiDa;
            }
            else
            {
                khoaHoc1.ngayKetThuc = khoaHoc1.ngayKetThuc.AddDays(1);
                dbContext.SaveChanges();
                return errType.ThanhCong;
            }
        }

        public errType TinhDoanhThu()
        {
            int thang = inputHelper.InputInt(res.inputThang, res.errorThang, 1, 12);
            int nam = inputHelper.InputInt(res.inputNam, res.errorNam);
            List<KhoaHoc> lstKhoaHoc = dbContext.khoaHocs.Where(x => x.ngayBatDau.Month == thang && x.ngayBatDau.Year == nam).ToList();
            double doanhThu = 0;
            for (int i = 0; i < lstKhoaHoc.Count(); i++)
            {
                doanhThu += dbContext.hocViens.Where(x => x.khoaHocId == lstKhoaHoc[i].Id).Count() * (int)lstKhoaHoc[i].hocPhi;
            }
            Console.WriteLine($"Doanh thu thang {thang}: {doanhThu}");
            return errType.ThanhCong;
        }

        public errType TinhDoanhThuTheoNam()
        {
            int nam = inputHelper.InputInt(res.inputNam, res.errorNam);
            List<KhoaHoc> lstKhoaHoc = dbContext.khoaHocs.Where(x => x.ngayBatDau.Year == nam).ToList();
            double doanhThu = 0;
            for (int i = 0; i < lstKhoaHoc.Count(); i++)
            {
                doanhThu += dbContext.hocViens.Where(x => x.khoaHocId == lstKhoaHoc[i].Id).Count() * (int)lstKhoaHoc[i].hocPhi;
            }
            Console.WriteLine($"Doanh thu theo nam {nam}: {doanhThu}");
            return errType.ThanhCong;
        }

        public errType XoaKhoaHoc(KhoaHoc khoaHoc)
        {
            KhoaHoc khoaHoc1 = dbContext.khoaHocs.SingleOrDefault(x => x.Id == khoaHoc.Id);
            if (khoaHoc1 == null)
            {
                return errType.KhoaHocKhongTonTai;
            }
            else
            {
                List<HocVien> lstHocVien = dbContext.hocViens.Where(x => x.khoaHocId == khoaHoc.Id).ToList();
                lstHocVien.ForEach(x => dbContext.hocViens.Remove(x));
                dbContext.SaveChanges();

                List<NgayHoc> lstNgayHoc = dbContext.ngayHocs.Where(x => x.khoaHocId == khoaHoc.Id).ToList();
                lstNgayHoc.ForEach(x => dbContext.ngayHocs.Remove(x));
                dbContext.SaveChanges();

                dbContext.khoaHocs.Remove(khoaHoc1);
                dbContext.SaveChanges();

                return errType.ThanhCong;
            }
        }
    }
}
