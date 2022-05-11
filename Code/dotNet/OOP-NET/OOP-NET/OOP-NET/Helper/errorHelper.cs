using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_NET.Helper
{
    enum errType
    {
        MonAnDaTonTai,
        MonAnKhongTonTai,
        DanhSachRong,
        ThanhCong
    }
    class errorHelper
    {
        public static void log(errType errType)
        {
            switch (errType)
            {
                case errType.MonAnDaTonTai:
                    {
                        Console.WriteLine("Mon an da ton tai!");
                    }
                    break;
                case errType.DanhSachRong:
                    {
                        Console.WriteLine("Danh sach trong!");
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
