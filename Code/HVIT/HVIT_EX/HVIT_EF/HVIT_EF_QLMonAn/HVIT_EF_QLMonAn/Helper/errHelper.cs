using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLMonAn.Helper
{
    enum errType
    {
        LoaiMonAnKhongTonTai,
        MonAnKhongTonTai,
        NguyenLieuKhongTonTai,
        ThanhCong
    }
    class errHelper
    {
        public static void log(errType errType)
        {
            switch (errType)
            {
                case errType.LoaiMonAnKhongTonTai:
                    {
                        Console.WriteLine("Khong ton tai loai mon an!");
                    }
                    break;
                case errType.MonAnKhongTonTai:
                    {
                        Console.WriteLine("Khong ton tai mon an!");
                    }
                    break;
                case errType.NguyenLieuKhongTonTai:
                    {
                        Console.WriteLine("Nguyen lieu khong ton tai!");
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
