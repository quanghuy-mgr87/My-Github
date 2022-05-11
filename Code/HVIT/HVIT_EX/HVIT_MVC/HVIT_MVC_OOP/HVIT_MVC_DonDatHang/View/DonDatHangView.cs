using HVIT_MVC_DonDatHang.Controller;
using HVIT_MVC_DonDatHang.Helper;
using HVIT_MVC_DonDatHang.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_MVC_DonDatHang.View
{
    class DonDatHangView
    {
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("" +
                "------------ Menu ------------\n" +
                "1. Them don dat hang\n" +
                "2. Them san pham\n" +
                "3. Them chi tiet don dat hang\n" +
                "4. Hien thi thong tin don dat hang\n" +
                "5. Thoat");
            Console.Write("Nhap chuc nang: ");
            char c = Console.ReadKey().KeyChar;
            Console.WriteLine();
            ThucThi(c);
        }
        private static void ThucThi(char c)
        {
            switch (c)
            {
                case '1':
                    {
                        errorHelper.log(DonDatHangController.ThemDonDatHang(new DonDatHang()));
                    }
                    break;
                case '2':
                    {
                        errorHelper.log(DonDatHangController.ThemSanPham(new SanPham()));
                    }
                    break;
                case '3':
                    {
                        errorHelper.log(DonDatHangController.ThemChiTietDonDatHang(new ChiTietDonDatHang()));
                    }
                    break;
                case '4':
                    {
                        int maDDH = inputHelper.InputInt(res.inputMaDDH, res.errorMaDDH);
                        errorHelper.log(DonDatHangController.HienThiDon(maDDH));
                    }
                    break;
                case '5':
                    return;
                default:
                    break;
            }
            Console.ReadKey();
            Menu();
        }
    }
}
