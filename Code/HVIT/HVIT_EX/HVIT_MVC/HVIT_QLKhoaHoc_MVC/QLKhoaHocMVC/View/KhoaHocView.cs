using QLKhoaHocMVC.Controller;
using QLKhoaHocMVC.Helper;
using QLKhoaHocMVC.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLKhoaHocMVC.View
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
            char c = Console.ReadKey().KeyChar;
            Console.WriteLine();
            DoAction(c);
        }
        private void DoAction(char c)
        {
            switch (c)
            {
                case '1':
                    {
                        errHelper.log(KhoaHocController.ThemNgayChoKhoaHoc(new KhoaHoc(inputType.ThemNgayHocVaoKhoaHoc)));
                    }
                    break;
                case '2':
                    {
                        errHelper.log(HocVienController.ThemHocVien(new HocVien(inputType.ThemHocVien)));
                    }
                    break;
                case '3':
                    {
                        errHelper.log(HocVienController.SuaThongTinHocVien(new HocVien(inputType.SuaThongTinHocVien)));
                    }
                    break;
                case '4':
                    {
                        errHelper.log(KhoaHocController.XoaKhoaHoc(new KhoaHoc(inputType.XoaKhoaHoc)));
                    }
                    break;
                case '5':
                    {
                        errHelper.log(HocVienController.TimHocVien(new HocVien(inputType.TimHocVienTheoHoTenVaKhoaHoc)));
                    }
                    break;
                case '6':
                    {
                        errHelper.log(KhoaHocController.TinhDoanhThu());
                    }
                    break;
                case '7':
                    {
                        errHelper.log(KhoaHocController.TinhDoanhThuTheoNam());
                    }
                    return;
                default:
                    break;
            }
        }
    }
}
