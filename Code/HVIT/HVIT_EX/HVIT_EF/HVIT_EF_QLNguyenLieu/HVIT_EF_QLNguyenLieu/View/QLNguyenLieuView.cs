using HVIT_EF_QLNguyenLieu.Helper;
using HVIT_EF_QLNguyenLieu.Services;
using HVIT_EF_QLNguyenLieu.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLNguyenLieu.View
{
    class QLNguyenLieuView
    {
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("" +
                "------------ Menu ------------\n" +
                "1. Them nguyen lieu thuoc mot loai nguyen lieu da ton tai\n" +
                "2. Them mot danh sach chi tiet phieu cho mot phieu thu cu the\n" +
                "3. Them mot phieu thu\n" +
                "4. Xoa mot phieu thu\n" +
                "5. Lay thong tin cac phieu thu theo thoi gian\n" +
                "6. Thoat.");
            Console.Write("Chon chuc nang: ");
            char chon = Console.ReadKey().KeyChar;
            Console.WriteLine();
            DoAction(chon);
        }
        private void DoAction(char c)
        {
            ChiTietPhieuThuService chiTietPhieuThuService = new ChiTietPhieuThuService();
            NguyenLieuService nguyenLieuService = new NguyenLieuService();
            PhieuThuService phieuThuService = new PhieuThuService();
            switch (c)
            {
                case '1':
                    {
                        errHelper.log(nguyenLieuService.ThemNguyenLieu(new NguyenLieu(inputType.ThemNguyenLieu)));
                    }
                    break;
                case '2':
                    {
                        errHelper.log(chiTietPhieuThuService.ThemDSChiTietPhieu(new ChiTietPhieuThu(inputType.ThemChiTietPhieuThu)));
                    }
                    break;
                case '3':
                    {
                        errHelper.log(phieuThuService.ThemPhieuThu(new PhieuThu(inputType.ThemPhieuThu)));
                    }
                    break;
                case '4':
                    {
                        errHelper.log(phieuThuService.XoaPhieuThu(new PhieuThu(inputType.XoaPhieuThu)));
                    }
                    break;
                case '5':
                    {
                        errHelper.log(phieuThuService.LayRaThongTinPhieuTheoThoiGian(new PhieuThu(inputType.LayThongTinPhieuThuTheoThoiGian)));
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
