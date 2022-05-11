using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_MVCTest.Helper
{
    enum errType
    {
        KhongTonTaiDuAn,
        KhongTonTaiNhanVien,
        DaTonTai,
        ThanhCong
    }
    class errHelper
    {
        public static void log(errType errType)
        {
            switch (errType)
            {
                case errType.KhongTonTaiDuAn:
                    {
                        Console.WriteLine("Khong ton tai du an!");
                    }
                    break;
                case errType.KhongTonTaiNhanVien:
                    {
                        Console.WriteLine("Khong ton tai nhan vien!");
                    }
                    break;
                case errType.DaTonTai:
                    {
                        Console.WriteLine("Phan cong da ton tai!");
                    }
                    break;
                case errType.ThanhCong:
                    {
                        Console.WriteLine("Thuc hien thanh cong!");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
