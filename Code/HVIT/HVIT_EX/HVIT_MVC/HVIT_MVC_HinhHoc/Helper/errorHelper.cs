using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_MVC_HinhHoc.Helper
{
    enum LoaiHinh
    {
        LaHinhVuong,
        LaHinhTamGiac,
        LaHinhChuNhat,
        LaHinhThang,
        ChuaXacDinh
    }
    class errorHelper
    {
        public static void log(LoaiHinh loaiHinh)
        {
            switch (loaiHinh)
            {
                case LoaiHinh.LaHinhVuong:
                    {
                        Console.WriteLine("La hinh vuong.");
                    }
                    break;
                case LoaiHinh.LaHinhTamGiac:
                    {
                        Console.WriteLine("La hinh tam giac.");
                    }
                    break;
                case LoaiHinh.LaHinhChuNhat:
                    {
                        Console.WriteLine("La hinh chu nhat.");
                    }
                    break;
                case LoaiHinh.LaHinhThang:
                    {
                        Console.WriteLine("La hinh thang.");
                    }
                    break;
                case LoaiHinh.ChuaXacDinh:
                    {
                        Console.WriteLine("Chua xac dinh.");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
