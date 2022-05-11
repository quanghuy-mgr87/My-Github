using HVIT_MVC_HinhHoc.Controller;
using HVIT_MVC_HinhHoc.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HVIT_MVC_HinhHoc.Model
{
    enum LoaiHinh
    {
        Vuong,
        TamGiac,
        ChuNhat,
        Thang,
        TatCa,
        BinhHanh
    }
    class HinhHoc
    {
        List<Diem> lstDiem = new List<Diem> { };
        public bool laHinhVuong { get; private set; }
        public bool laTamGiac { get; private set; }
        public bool laChuNhat { get; private set; }
        public bool laHinhThang { get; private set; }
        public bool laBinhHanh { get; set; }
        public HinhHoc(params Diem[] diem)
        {
            for (int i = 0; i < diem.Length; i++)
            {
                lstDiem.Add(diem[i]);
            }
        }
        private bool XacDinhThangHang(List<Diem> diems)
        {
            if (inputHelper.TinhKhoangCachHaiDiem(diems[0], diems[1]) == inputHelper.TinhKhoangCachHaiDiem(diems[1], diems[2]) + inputHelper.TinhKhoangCachHaiDiem(diems[2], diems[0]) &&
                inputHelper.TinhKhoangCachHaiDiem(diems[0], diems[2]) == inputHelper.TinhKhoangCachHaiDiem(diems[0], diems[1]) + inputHelper.TinhKhoangCachHaiDiem(diems[1], diems[2]) &&
                inputHelper.TinhKhoangCachHaiDiem(diems[1], diems[2]) == inputHelper.TinhKhoangCachHaiDiem(diems[1], diems[0]) + inputHelper.TinhKhoangCachHaiDiem(diems[2], diems[0])
                )
            {
                return true;
            }
            return false;
        }
        private double tinhCos(Diem d1, Diem d2, Diem d3)
        {
            return ((Math.Pow(inputHelper.TinhKhoangCachHaiDiem(d2, d1), 2) + Math.Pow(inputHelper.TinhKhoangCachHaiDiem(d2, d3), 2) - Math.Pow(inputHelper.TinhKhoangCachHaiDiem(d1, d3), 2)) /
                (inputHelper.TinhKhoangCachHaiDiem(d2, d1) * inputHelper.TinhKhoangCachHaiDiem(d2, d3) * 2));
        }
        public void XacDinhHinh()
        {
            if (lstDiem.Count() == 3)
            {
                if (!XacDinhThangHang(lstDiem))
                    laTamGiac = true;
            }
            else if (lstDiem.Count() == 4)
            {
                if (tinhCos(lstDiem[0], lstDiem[1], lstDiem[3]) == tinhCos(lstDiem[1], lstDiem[3], lstDiem[2]) ||
                    tinhCos(lstDiem[1], lstDiem[0], lstDiem[2]) == tinhCos(lstDiem[0], lstDiem[2], lstDiem[3]) ||
                    tinhCos(lstDiem[0], lstDiem[1], lstDiem[2]) == tinhCos(lstDiem[1], lstDiem[2], lstDiem[3]) ||
                    tinhCos(lstDiem[1], lstDiem[0], lstDiem[3]) == tinhCos(lstDiem[0], lstDiem[3], lstDiem[2]) ||
                    tinhCos(lstDiem[0], lstDiem[2], lstDiem[1]) == tinhCos(lstDiem[2], lstDiem[1], lstDiem[3]) ||
                    tinhCos(lstDiem[0], lstDiem[3], lstDiem[1]) == tinhCos(lstDiem[2], lstDiem[0], lstDiem[3]) ||
                    tinhCos(lstDiem[0], lstDiem[1], lstDiem[3]) == tinhCos(lstDiem[1], lstDiem[0], lstDiem[2]) ||
                    tinhCos(lstDiem[2], lstDiem[3], lstDiem[1]) == tinhCos(lstDiem[0], lstDiem[2], lstDiem[3]) ||
                    tinhCos(lstDiem[0], lstDiem[2], lstDiem[1]) == tinhCos(lstDiem[2], lstDiem[0], lstDiem[3]) ||
                    tinhCos(lstDiem[0], lstDiem[3], lstDiem[1]) == tinhCos(lstDiem[3], lstDiem[1], lstDiem[2]) ||
                    tinhCos(lstDiem[0], lstDiem[3], lstDiem[2]) == tinhCos(lstDiem[3], lstDiem[2], lstDiem[1]) ||
                    tinhCos(lstDiem[1], lstDiem[0], lstDiem[3]) == tinhCos(lstDiem[0], lstDiem[1], lstDiem[2]))
                {
                    laHinhThang = true;
                    if ((inputHelper.TinhKhoangCachHaiDiem(lstDiem[0], lstDiem[1]) == inputHelper.TinhKhoangCachHaiDiem(lstDiem[2], lstDiem[3]) &&
                        inputHelper.TinhKhoangCachHaiDiem(lstDiem[0], lstDiem[2]) == inputHelper.TinhKhoangCachHaiDiem(lstDiem[3], lstDiem[1]) ||
                        inputHelper.TinhKhoangCachHaiDiem(lstDiem[0], lstDiem[3]) == inputHelper.TinhKhoangCachHaiDiem(lstDiem[2], lstDiem[1])) ||
                        (inputHelper.TinhKhoangCachHaiDiem(lstDiem[0], lstDiem[2]) == inputHelper.TinhKhoangCachHaiDiem(lstDiem[3], lstDiem[1]) &&
                        inputHelper.TinhKhoangCachHaiDiem(lstDiem[0], lstDiem[3]) == inputHelper.TinhKhoangCachHaiDiem(lstDiem[2], lstDiem[1])))
                    {
                        laBinhHanh = true;
                        Console.WriteLine(tinhCos(lstDiem[1], lstDiem[0], lstDiem[3]));
                        Console.WriteLine(tinhCos(lstDiem[1], lstDiem[0], lstDiem[2]));
                        Console.WriteLine(tinhCos(lstDiem[2], lstDiem[0], lstDiem[3]));
                        if (tinhCos(lstDiem[1], lstDiem[0], lstDiem[3]) == tinhCos(lstDiem[0], lstDiem[3], lstDiem[2]) &&
                            tinhCos(lstDiem[0], lstDiem[3], lstDiem[2]) == tinhCos(lstDiem[3], lstDiem[2], lstDiem[1]) ||
                            tinhCos(lstDiem[1], lstDiem[0], lstDiem[2]) == tinhCos(lstDiem[0], lstDiem[2], lstDiem[3]) &&
                            tinhCos(lstDiem[0], lstDiem[2], lstDiem[3]) == tinhCos(lstDiem[2], lstDiem[3], lstDiem[1]) ||
                            tinhCos(lstDiem[2], lstDiem[0], lstDiem[3]) == tinhCos(lstDiem[0], lstDiem[3], lstDiem[1]) &&
                            tinhCos(lstDiem[0], lstDiem[3], lstDiem[1]) == tinhCos(lstDiem[3], lstDiem[1], lstDiem[2]))
                        {
                            laChuNhat = true;
                            if (inputHelper.TinhKhoangCachHaiDiem(lstDiem[0], lstDiem[1]) == inputHelper.TinhKhoangCachHaiDiem(lstDiem[0], lstDiem[2]) ||
                                inputHelper.TinhKhoangCachHaiDiem(lstDiem[0], lstDiem[1]) == inputHelper.TinhKhoangCachHaiDiem(lstDiem[0], lstDiem[3]) ||
                                inputHelper.TinhKhoangCachHaiDiem(lstDiem[0], lstDiem[2]) == inputHelper.TinhKhoangCachHaiDiem(lstDiem[0], lstDiem[3]))
                            {
                                laHinhVuong = true;
                            }
                        }
                    }
                }

            }
        }
        public void InThongTin()
        {
            Console.WriteLine();
            if (lstDiem.Count() == 3 && XacDinhThangHang(lstDiem))
            {
                Console.WriteLine("3 diem thang hang!");
            }
            else if (laHinhVuong)
            {
                Console.WriteLine("Hinh vuong");
            }
            else if (laChuNhat)
            {
                Console.WriteLine("Hinh chu nhat");
            }
            else if (laBinhHanh)
            {
                Console.WriteLine("Hinh binh hanh");
            }
            else if (laHinhThang)
            {
                Console.WriteLine("Hinh thang");
            }
            else if (laTamGiac)
            {
                Console.WriteLine("Tam giac");
            }
            else
            {
                Console.WriteLine("Tu giac");
            }
            lstDiem.ForEach(x => x.InThongTin());
        }
    }
}
