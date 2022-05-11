using HVIT_EF_QLHocSinh.Helper;
using HVIT_EF_QLHocSinh.Service;
using HVIT_EF_QLHocSinh.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLHocSinh.View
{
    class QLHocSinhView
    {
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("" +
                "--------- QL Hoc Sinh ---------\n" +
                "1. Them 1 hoc sinh vao lop da ton tai\n" +
                "2. Sua thong tin hoc sinh\n" +
                "3. Xoa hoc sinh\n" +
                "4. Chuyen lop cho hoc sinh\n" +
                "5. Xem danh sach hoc sinh\n" +
                "6. Xem danh sach lop\n" +
                "7. Thoat.");
            Console.Write("Chon nhiem vu: ");
            char c = Console.ReadKey().KeyChar;
            Console.WriteLine();
            DoAction(c);
        }
        private void DoAction(char c)
        {
            HocSinhService hocSinhService = new HocSinhService();
            LopService lopService = new LopService();
            switch (c)
            {
                case '1':
                    {
                        errHelper.log(hocSinhService.ThemHocSinhVaoLop(new HocSinh(inputType.ThemHocSinhVaoLop)));
                    }
                    break;
                case '2':
                    {
                        errHelper.log(hocSinhService.SuaThongTinHocSinh(new HocSinh(inputType.SuaThongTinHocSinh)));
                    }
                    break;
                case '3':
                    {
                        errHelper.log(hocSinhService.XoaHocSinh(new HocSinh(inputType.XoaHocSinh)));
                    }
                    break;
                case '4':
                    {
                        errHelper.log(hocSinhService.ChuyenLopChoHocSinh(new HocSinh(inputType.ChuyenLopHocSinh)));
                    }
                    break;
                case '5':
                    {
                        Console.Write("Nhap ten hoc sinh: ");
                        string keyword = Console.ReadLine();
                        var DSHS = hocSinhService.HienThiDSHocSinh(keyword);
                        foreach (var val in DSHS)
                        {
                            Console.WriteLine($"Ma hs: {val.Id}, ma lop: {val.LopId}, ho ten: {val.HoTen}, ngay sinh: {val.NgaySinh.ToShortDateString()}, que quan: {val.QueQuan}");
                        }
                    }
                    break;
                case '6':
                    {
                        var DSLop = lopService.HienThiDSLop();
                        foreach (var val in DSLop)
                        {
                            Console.WriteLine($"Ma lop: {val.Id}, ten lop: {val.TenLop}, si so: {val.SiSo}");
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
