using HVIT_MVC_SoHoc.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_MVC_SoHoc.Controller
{
    class SoHocController
    {
        private static List<SoHoc> lstSoHoc = new List<SoHoc> { };
        private static Random random = new Random();
        public static void TaoNgauNhien(int soLuong)
        {
            for (int i = 0; i < soLuong; i++)
            {
                int num = random.Next(1, 1000);
                lstSoHoc.Add(new SoHoc(num));
            }
        }
        public static void HienThi(LoaiSo loaiSo)
        {
            switch (loaiSo)
            {
                case LoaiSo.BatKy:
                    {
                        lstSoHoc.ForEach(x => x.InThongTin());
                        Console.WriteLine();
                    }
                    break;
                case LoaiSo.SoChan:
                    {
                        foreach (var val in lstSoHoc)
                        {
                            if (val.laSoChan)
                                val.InThongTin();
                        }
                        Console.WriteLine();
                    }
                    break;
                case LoaiSo.SoLe:
                    {
                        foreach (var val in lstSoHoc)
                        {
                            if (!val.laSoChan)
                                val.InThongTin();
                        }
                        Console.WriteLine();
                    }
                    break;
                case LoaiSo.SoNT:
                    {
                        foreach (var val in lstSoHoc)
                        {
                            if (val.laSoNT)
                                val.InThongTin();
                        }
                        Console.WriteLine();
                    }
                    break;
                case LoaiSo.SoDoiXung:
                    {
                        foreach (var val in lstSoHoc)
                        {
                            if (val.laSoDoiXung)
                                val.InThongTin();
                        }
                        Console.WriteLine();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
