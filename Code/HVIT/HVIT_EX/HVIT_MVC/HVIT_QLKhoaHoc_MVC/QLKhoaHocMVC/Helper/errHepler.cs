using System;
using System.Collections.Generic;
using System.Text;

namespace QLKhoaHocMVC.Helper
{
    enum errType
    {
        ThanhCong,
        KhoaHocKhongTonTai,
        NgayHocDaTonTai,
        HocVienKhongTonTai,
        HocVienDaTonTai,
        SoNgayToiDa
    }
    class errHelper
    {
        public static void log(errType errType)
        {
            switch (errType)
            {
                case errType.ThanhCong:
                    {
                        Console.WriteLine("Thuc hien thanh cong!");
                    }
                    break;
                case errType.KhoaHocKhongTonTai:
                    {
                        Console.WriteLine("Khoa hoc khong ton tai!");
                    }
                    break;
                case errType.NgayHocDaTonTai:
                    {
                        Console.WriteLine("Ngay hoc da ton tai!");
                    }
                    break;
                case errType.HocVienKhongTonTai:
                    {
                        Console.WriteLine("Hoc vien khong ton tai!");
                    }
                    break;
                case errType.HocVienDaTonTai:
                    {
                        Console.WriteLine("Hoc vien da ton tai!");
                    }
                    break;
                case errType.SoNgayToiDa:
                    {
                        Console.WriteLine("So ngay toi da");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
