using HVIT_MVC_SanPham.Controller;
using HVIT_MVC_SanPham.Helper;
using HVIT_MVC_SanPham.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_MVC_SanPham.View
{
    class SanPhamView
    {
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("" +
                "1. Them san pham\n" +
                "2. Hien san pham cua loai\n" +
                "3. Hien san pham cua nha cung cap\n" +
                "4. Thoat");
            Console.Write("Chon chuc nang: ");
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
                        SanPham sanPham = new SanPham();
                        errorHelper.log(SanPhamController.ThemSanPham(sanPham));
                    }
                    break;
                case '2':
                    {
                        int loaiSP = inputHelper.InputInt(res.inputLoaiSP, res.errorLoaiSP);
                        errorHelper.log(SanPhamController.HienLoai(loaiSP));
                    }
                    break;
                case '3':
                    {
                        int nhaCC = inputHelper.InputInt(res.inputNhaCC, res.errorNhaCC);
                        errorHelper.log(SanPhamController.HienNCC(nhaCC));
                    }
                    break;
                case '4':
                    return;
                default:
                    break;
            }
            Console.ReadKey();
            Menu();
        }
    }
}
