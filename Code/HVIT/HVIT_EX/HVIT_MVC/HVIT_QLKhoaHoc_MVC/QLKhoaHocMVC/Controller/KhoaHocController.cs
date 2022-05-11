using QLKhoaHocMVC.Helper;
using QLKhoaHocMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLKhoaHocMVC.Controller
{
    class KhoaHocController
    {
        public static errType XoaKhoaHoc(KhoaHoc khoaHoc)
        {
            using (var db = new BusinessContext())
            {
                KhoaHoc khoaHoc1 = db.khoaHocs.SingleOrDefault(x => x.KhoahocID == khoaHoc.KhoahocID);
                if (khoaHoc1 == null)
                {
                    return errType.KhoaHocKhongTonTai;
                }
                else
                {
                    List<HocVien> lstHocVien = db.hocViens.Where(x => x.KhoahocID == khoaHoc.KhoahocID).ToList();
                    lstHocVien.ForEach(x => db.hocViens.Remove(x));
                    db.SaveChanges();

                    List<NgayHoc> lstNgayHoc = db.ngayHocs.Where(x => x.KhoahocID == khoaHoc.KhoahocID).ToList();
                    lstNgayHoc.ForEach(x => db.ngayHocs.Remove(x));
                    db.SaveChanges();

                    db.khoaHocs.Remove(khoaHoc1);
                    db.SaveChanges();

                    return errType.ThanhCong;
                }
            }
        }
        public static errType TinhDoanhThu()
        {
            using (var db = new BusinessContext())
            {
                int thang = inputHelper.InputInt("Nhap thang: ", "Loi!", 1, 12);
                int nam = inputHelper.InputInt("Nhap nam: ", "Loi!");
                List<KhoaHoc> lstKhoaHoc = db.khoaHocs.Where(x => x.Ngaybatdau.Month == thang && x.Ngaybatdau.Year == nam).ToList();
                double doanhThu = 0;
                for (int i = 0; i < lstKhoaHoc.Count(); i++)
                {
                    doanhThu += db.hocViens.Where(x => x.KhoahocID == lstKhoaHoc[i].KhoahocID).Count() * lstKhoaHoc[i].Hocphi;
                }
                Console.WriteLine($"Doanh thu thang {thang}: {doanhThu}");
                return errType.ThanhCong;
            }
        }
        public static errType TinhDoanhThuTheoNam()
        {
            using (var db = new BusinessContext())
            {
                int nam = inputHelper.InputInt("Nhap nam: ", "Loi!");
                List<KhoaHoc> lstKhoaHoc = db.khoaHocs.Where(x => x.Ngaybatdau.Year == nam).ToList();
                double doanhThu = 0;
                for (int i = 0; i < lstKhoaHoc.Count(); i++)
                {
                    doanhThu += db.hocViens.Where(x => x.KhoahocID == lstKhoaHoc[i].KhoahocID).Count() * lstKhoaHoc[i].Hocphi;
                }
                Console.WriteLine($"Doanh thu theo nam {nam}: {doanhThu}");
                return errType.ThanhCong;
            }
        }
        public static errType ThemNgayChoKhoaHoc(KhoaHoc khoaHoc)
        {
            using (var db = new BusinessContext())
            {
                KhoaHoc khoaHoc1 = db.khoaHocs.SingleOrDefault(x => x.KhoahocID == khoaHoc.KhoahocID);
                if (khoaHoc1 == null)
                {
                    return errType.KhoaHocKhongTonTai;
                }
                int ngay = khoaHoc1.Ngayketthuc.Subtract(khoaHoc1.Ngaybatdau).Days;
                if (ngay >= 15)
                {
                    return errType.SoNgayToiDa;
                }
                else
                {
                    khoaHoc1.Ngayketthuc = khoaHoc1.Ngayketthuc.AddDays(1);
                    db.SaveChanges();
                    return errType.ThanhCong;
                }
            }
        }
    }
}
