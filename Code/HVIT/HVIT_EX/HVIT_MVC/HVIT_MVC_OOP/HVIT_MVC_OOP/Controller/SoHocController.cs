using HVIT_MVC_OOP.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_MVC_OOP.Controller
{
    class SoHocController
    {
        List<SoHoc> lstSoHoc = new List<SoHoc> { };
        Random random = new Random();
        public void TaoNgauNhien(int soLuong)
        {
            for (int i = 0; i < soLuong; i++)
            {
                lstSoHoc.Add(new SoHoc(random.Next(1, 100)));
            }
        }
        public void HienThi(LoaiSo loaiSo)
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
                            {
                                val.InThongTin();
                            }
                        }
                    }
                    break;
                case LoaiSo.SoLe:
                    {
                        foreach (var val in lstSoHoc)
                        {
                            if (!val.laSoChan)
                            {
                                val.InThongTin();
                            }
                        }
                    }
                    break;
                case LoaiSo.SoNT:
                    {
                        foreach (var val in lstSoHoc)
                        {
                            if (val.laSoNT)
                            {
                                val.InThongTin();
                            }
                        }
                    }
                    break;
                case LoaiSo.SoDoiXung:
                    {
                        foreach (var val in lstSoHoc)
                        {
                            if (val.laSoDoiXung)
                            {
                                val.InThongTin();
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
