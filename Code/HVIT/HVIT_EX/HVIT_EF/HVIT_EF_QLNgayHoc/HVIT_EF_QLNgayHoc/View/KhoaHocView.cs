using HVIT_EF_QLNgayHoc.Entities;
using HVIT_EF_QLNgayHoc.Helper;
using HVIT_EF_QLNgayHoc.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLNgayHoc.View
{
    class KhoaHocView
    {
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("" +
                "----------------- Quan Ly Khoa Hoc -----------------\n" +
                "1. Them 1 ngay hoc vao mot khoa hoc.\n" +
                "2. Them hoc vien.\n" +
                "3. Sua thong tin hoc vien.\n" +
                "4. Xoa khoa hoc.\n" +
                "5. Tim kiem hoc vien theo ho ten va khoa hoc hoc vien do dang theo hoc.\n" +
                "6. Tinh doanh thu cua trung tam trong thang.\n" +
                "7. Tinh doanh thu cua trung tam trong nam.\n" +
                "8. Thoat.");
            Console.Write("Nhap chuc nang: ");
            char c = Console.ReadKey().KeyChar;
            Console.WriteLine();
            DoAction(c);
        }
        private void DoAction(char c)
        {
            KhoaHocService khoaHocService = new KhoaHocService();
            HocVienService hocVienService = new HocVienService();
            switch (c)
            {
                case '1':
                    {
                        errHelper.log(khoaHocService.ThemNgayChoKhoaHoc(new KhoaHoc(inputType.ThemNgayHocVaoKhoaHoc)));
                    }
                    break;
                case '2':
                    {
                        errHelper.log(hocVienService.ThemHocVien(new HocVien(inputType.ThemHocVien)));
                    }
                    break;
                case '3':
                    {
                        errHelper.log(hocVienService.SuaThongTinHocVien(new HocVien(inputType.SuaThongTinHocVien)));
                    }
                    break;
                case '4':
                    {
                        errHelper.log(khoaHocService.XoaKhoaHoc(new KhoaHoc(inputType.XoaKhoaHoc)));
                    }
                    break;
                case '5':
                    {
                        errHelper.log(hocVienService.TimHocVien(new HocVien(inputType.TimHocVienTheoHoTenVaKhoaHoc)));
                    }
                    break;
                case '6':
                    {
                        errHelper.log(khoaHocService.TinhDoanhThu());
                    }
                    break;
                case '7':
                    {
                        errHelper.log(khoaHocService.TinhDoanhThuTheoNam());
                    }
                    return;
                default:
                    break;
            }
            Console.ReadKey();
            Menu();
        }
    }
}
