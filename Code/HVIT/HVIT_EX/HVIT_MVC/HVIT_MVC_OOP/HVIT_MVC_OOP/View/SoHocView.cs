using HVIT_MVC_OOP.Controller;
using HVIT_MVC_OOP.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_MVC_OOP.View
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
            List<SoHoc> lstSoHoc = new List<SoHoc>();
            SoHocController soHocController = new SoHocController();
            switch (c)
            {
                case '1':
                    {
                        Console.Write("Nhap so luong so: ");
                        int soLuong = int.Parse(Console.ReadLine());
                        soHocController.TaoNgauNhien(soLuong);
                    }
                    break;
                case '2':
                    {
                        soHocController.HienThi(LoaiSo.BatKy);
                    }
                    break;
                case '3':
                    {
                        soHocController.HienThi(LoaiSo.SoChan);
                    }
                    break;
                case '4':
                    {
                        soHocController.HienThi(LoaiSo.SoLe);
                    }
                    break;
                case '5':
                    {
                        soHocController.HienThi(LoaiSo.SoNT);
                    }
                    break;
                case '6':
                    {
                        soHocController.HienThi(LoaiSo.SoDoiXung);
                    }
                    break;
                case '7':
                    break;
                default:
                    break;
            }
            Menu();
        }
    }
}
