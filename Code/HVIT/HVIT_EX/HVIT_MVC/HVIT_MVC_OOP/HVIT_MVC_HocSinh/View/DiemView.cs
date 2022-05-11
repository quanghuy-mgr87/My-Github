using HVIT_MVC_HocSinh.Controller;
using HVIT_MVC_HocSinh.Helper;
using HVIT_MVC_HocSinh.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_MVC_HocSinh.View
{
    class DiemView
    {
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("" +
                "1. Them 1 hoc sinh\n" +
                "2. Them mon hoc\n" +
                "3. Cham diem\n" +
                "4. Xem bang diem hoc sinh\n" +
                "5. Xem tong ket diem hoc sinh theo mon\n" +
                "6. Xem danh sach hoc sinh");
            Console.Write("Chon chuc nang: ");
            char c = Console.ReadKey().KeyChar;
            Console.WriteLine();
            ThucThi(c);
        }
        public static void ThucThi(char c)
        {
            switch (c)
            {
                case '1':
                    {
                        errorHelper.log(DiemController.ThemHocSinh(new HocSinh()));
                    }
                    break;
                case '2':
                    {
                        errorHelper.log(DiemController.ThemMonHoc(new MonHoc()));
                    }
                    break;
                case '3':
                    {
                        int maHS = inputHelper.InputInt(res.inputMaHS, res.errorMaHS);
                        int maMH = inputHelper.InputInt(res.inputMaMH, res.errorMaMH);
                        errorHelper.log(DiemController.ChamDiem(maHS, maMH));
                    }
                    break;
                case '4':
                    {
                        int maHS = inputHelper.InputInt(res.inputMaHS, res.errorMaHS);
                        errorHelper.log(DiemController.BangDiem(maHS));
                    }
                    break;
                case '5':
                    {
                        int maMH = inputHelper.InputInt(res.inputMaMH, res.errorMaMH);
                        errorHelper.log(DiemController.TongKetMon(maMH));
                    }
                    break;
                case '6':
                    {
                        DiemController.HienThiDSHocSinh();
                    }
                    break;
                default:
                    break;
            }
            Console.ReadKey();
            Menu();
        }
    }
}
