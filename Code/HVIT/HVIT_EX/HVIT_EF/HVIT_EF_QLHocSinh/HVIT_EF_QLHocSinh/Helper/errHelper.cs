using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLHocSinh.Helper
{
    enum errType
    {
        HocSinhKhongTonTai,
        HocSinhDaTonTai,
        LopKhongTonTai,
        DaTonTai,
        LopDaDay,
        ThanhCong
    }
    class errHelper
    {
        public static void log(errType errType)
        {
            switch (errType)
            {
                case errType.HocSinhKhongTonTai:
                    {
                        Console.WriteLine("Hoc sinh khong ton tai!");
                    }
                    break;
                case errType.LopKhongTonTai:
                    {
                        Console.WriteLine("Lop khong ton tai!");
                    }
                    break;
                case errType.DaTonTai:
                    {
                        Console.WriteLine("Da ton tai!");
                    }
                    break;
                case errType.ThanhCong:
                    {
                        Console.WriteLine("Thuc hien thanh cong!");
                    }
                    break;
                case errType.HocSinhDaTonTai:
                    {
                        Console.WriteLine("Hoc sinh da ton tai!");
                    }
                    break;
                case errType.LopDaDay:
                    {
                        Console.WriteLine("Lop da du hoc sinh, khong the them!");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
