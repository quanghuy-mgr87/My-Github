using System;
using System.Collections.Generic;
using System.Text;
using HVIT_MVCTest.Model;
using HVIT_MVCTest.Helper;
using HVIT_MVCTest.Controller;

namespace HVIT_MVCTest.View
{
    class DuAnView
    {
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("" +
                 "-----------Quan Ly Du An-----------\n" +
                 "1. Sua Du An\n" +
                 "2. Them Nhan Vien\n" +
                 "3. Xoa Nhan Vien\n" +
                 "4. Tinh Luong\n" +
                 "5. Them Nhan Vien Vao Du An\n" +
                 "6. Thoat");
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
                        errHelper.log(DuAnController.SuaDuAn(new DuAn(inputType.SuaDuAn)));
                    }
                    break;
                case '2':
                    {
                        errHelper.log(NhanVienController.ThemMoiNhanVien(new NhanVien(inputType.ThemNhanVien)));
                    }
                    break;
                case '3':
                    {
                        errHelper.log(NhanVienController.XoaNhanVien(new NhanVien(inputType.XoaNhanVien)));
                    }
                    break;
                case '4':
                    {
                        NhanVienController.TinhLuong(new NhanVien(inputType.TinhLuong));
                    }
                    break;
                case '5':
                    {
                        errHelper.log(PhanCongController.ThemNhanVienVaoDuAn(new PhanCong(inputType.ThemNhanVienVaoDuAn)));
                    }
                    break;
                case '6':
                    return;

                default:
                    break;
            }
        }
    }
}
