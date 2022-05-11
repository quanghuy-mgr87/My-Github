using System;
using System.Collections.Generic;
using System.Text;
using HVIT_MVC_SoHoc.Controller;
using HVIT_MVC_SoHoc.Helper;
using HVIT_MVC_SoHoc.Model;

namespace HVIT_MVC_SoHoc.View
{
    class SoHocView
    {
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("" +
                "1. Tao so\n" +
                "2. Hien thi tat ca\n" +
                "3. Hien thi so chan\n" +
                "4. Hien thi so le\n" +
                "5. Hien thi so nguyen to\n" +
                "6. Hien thi so doi xung\n" +
                "7. Thoat.");
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
                        int soLuong = inputHeper.InputInt("Nhap so luong so: ", "So nhap vao phai la so nguyen!");
                        SoHocController.TaoNgauNhien(soLuong);
                    }
                    break;
                case '2':
                    {
                        Console.WriteLine("Danh sach so vua nhap:");
                        SoHocController.HienThi(LoaiSo.BatKy);
                    }
                    break;
                case '3':
                    {
                        Console.WriteLine("Danh sach so chan:");
                        SoHocController.HienThi(LoaiSo.SoChan);
                    }
                    break;
                case '4':
                    {
                        Console.WriteLine("Danh sach so le:");
                        SoHocController.HienThi(LoaiSo.SoLe);
                    }
                    break;
                case '5':
                    {
                        Console.WriteLine("Danh sach so nguyen to:");
                        SoHocController.HienThi(LoaiSo.SoNT);
                    }
                    break;
                case '6':
                    {
                        Console.WriteLine("Danh sach so doi xung:");
                        SoHocController.HienThi(LoaiSo.SoDoiXung);
                    }
                    break;
                case '7':
                    return;
                default:
                    break;
            }
            Console.ReadKey();
            Menu();
        }
    }
}
