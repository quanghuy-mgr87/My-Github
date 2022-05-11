using HVIT_EF_NhanVien.Entities;
using HVIT_EF_NhanVien.Helper;
using HVIT_EF_NhanVien.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_NhanVien.View
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
            Console.Write("Nhap chuc nang: ");
            char c = Console.ReadKey().KeyChar;
            Console.WriteLine();
            DoAction(c);
        }
        private void DoAction(char c)
        {
            DuAnService duAnService = new DuAnService();
            NhanVienService nhanVienService = new NhanVienService();
            PhanCongService phanCongService = new PhanCongService();
            switch (c)
            {
                case '1':
                    {
                        errHelper.log(duAnService.SuaDuAn(new DuAn(inputType.SuaDuAn)));
                    }
                    break;
                case '2':
                    {
                        errHelper.log(nhanVienService.ThemMoiNhanVien(new NhanVien(inputType.ThemNhanVien)));
                    }
                    break;
                case '3':
                    {
                        errHelper.log(nhanVienService.XoaNhanVien(new NhanVien(inputType.XoaNhanVien)));
                    }
                    break;
                case '4':
                    {
                        nhanVienService.TinhLuong(new NhanVien(inputType.TinhLuong));
                    }
                    break;
                case '5':
                    {
                        errHelper.log(phanCongService.ThemNhanVienVaoDuAn(new PhanCong(inputType.ThemNhanVienVaoDuAn)));
                    }
                    break;
                case '6':
                    return;

                default:
                    break;
            }
            Console.ReadKey();
            Menu();
        }
    }
}
