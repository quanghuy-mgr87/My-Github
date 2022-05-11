using HVIT_MVC_HinhHoc.Helper;
using HVIT_MVC_HinhHoc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVIT_MVC_HinhHoc.Controller
{
    class HinhHocController
    {
        private static List<HinhHoc> lstHinhHoc = new List<HinhHoc>();
        private static Random random = new Random();
        public static void TaoNgauNhien(int soLuong)
        {
            List<Diem> lstDiem = new List<Diem>();
            for (int i = 0; i < soLuong; i++)
            {
                Diem diem = new Diem(random.Next(1, 100), random.Next(1, 100));
                lstDiem.Add(diem);
            }
            lstHinhHoc.Add(new HinhHoc(lstDiem));
        }
        public static double TinhKhoangCachHaiDiem(Diem d1, Diem d2)
        {
            return Math.Sqrt(Math.Pow((d2.x - d1.x), 2) + Math.Pow((d2.y - d1.y), 2));
        }
        public static bool KiemTraTamGiac(double a, double b, double c)
        {
            if (a + b > c && a + c > b && b + c > a)
            {
                return true;
            }
            return false;
        }
        public static void SapXepGiamDan(List<double> lstKhoangCach)
        {
            for (int i = 0; i < lstKhoangCach.Count(); i++)
            {
                for (int j = i; j < lstKhoangCach.Count(); j++)
                {
                    if (lstKhoangCach[i] < lstKhoangCach[j])
                    {
                        double temp = lstKhoangCach[i];
                        lstKhoangCach[i] = lstKhoangCach[j];
                        lstKhoangCach[j] = temp;
                    }
                }
            }
        }
        public static LoaiHinh KiemTraHinh(List<Diem> lstDiem)
        {
            if (lstDiem.Count() == 3)
            {
                Diem d1, d2, d3;
                d1 = lstDiem[0];
                d2 = lstDiem[1];
                d3 = lstDiem[2];
                double canh1 = TinhKhoangCachHaiDiem(d1, d2);
                double canh2 = TinhKhoangCachHaiDiem(d2, d3);
                double canh3 = TinhKhoangCachHaiDiem(d1, d3);
                if (KiemTraTamGiac(canh1, canh2, canh3))
                {
                    return LoaiHinh.LaHinhTamGiac;
                }
            }
            if (lstDiem.Count() == 4)
            {
                List<double> lstKhoangCach = new List<double>();
                for (int i = 0; i < lstDiem.Count(); i++)
                {
                    for (int j = 0; j < lstDiem.Count(); j++)
                    {
                        lstKhoangCach.Add(TinhKhoangCachHaiDiem(lstDiem[i], lstDiem[j]));
                    }
                }
                SapXepGiamDan(lstKhoangCach);
                if (lstKhoangCach[0] == lstKhoangCach[1])
                {
                    int dem = 0;
                    for (int i = 2; i < lstKhoangCach.Count(); i++)
                    {
                        if (lstKhoangCach[i] == lstKhoangCach[i + 1])
                        {
                            dem++;
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (dem == 4)
                        return LoaiHinh.LaHinhVuong;
                    if (lstKhoangCach[2] == lstKhoangCach[3] && lstKhoangCach[4] == lstKhoangCach[5])
                        return LoaiHinh.LaHinhChuNhat;
                    return LoaiHinh.LaHinhThang;
                }
            }
            return LoaiHinh.ChuaXacDinh;
        }
    }
}
