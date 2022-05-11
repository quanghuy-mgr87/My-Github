using HVIT_MVC_HinhHoc.Controller;
using HVIT_MVC_HinhHoc.Helper;
using HVIT_MVC_HinhHoc.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_MVC_HinhHoc.View
{
    class HinhHocView
    {
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("" +
                "1. Tao hinh\n" +
                "2. Hien thi tat ca\n" +
                "3. Hien thi cac hinh vuong\n" +
                "4. Hien thi cac hinh tam giac\n" +
                "5. Hien thi cac hinh chu nhat\n" +
                "6. Hien thi cac hinh thang\n" +
                "7. Thoat");
            Console.Write("Chon chuc nang: ");
            char c = Console.ReadKey().KeyChar;
            Console.WriteLine();
        }
        private static void ThucThi(char c)
        {
            switch (c)
            {
                case '1':
                    {
                        int soLuong = inputHelper.InputInt("Nhap so luong hinh: ", "So luong la so nguyen duong!", 1);
                        HinhHocController.TaoNgauNhien(soLuong);
                    }
                    break;
                case '2':
                    {
                        errorHelper.log(HinhHocController.KiemTraHinh())
                    }
                    break;
                case '3':
                    break;
                case '4':
                    break;
                case '5':
                    break;
                case '6':
                    break;
                case '7':
                    break;
                default:
                    break;
            }
        }
    }
}
