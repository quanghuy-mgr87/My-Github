using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLNguyenLieu.Helper
{
    enum errType
    {
        LoaiNguyenLieuKhongTonTai,
        NguyenLieuDaTonTai,
        PhieuThuKhongTonTai,
        PhieuThuDaTonTai,
        NguyenLieuTrongKhoDaHet,
        ThanhCong
    }
    class errHelper
    {
        public static void log(errType errType)
        {
            switch (errType)
            {
                case errType.NguyenLieuTrongKhoDaHet:
                    {
                        Console.WriteLine("Nguyen lieu da het!");
                    }
                    break;
                case errType.LoaiNguyenLieuKhongTonTai:
                    {
                        Console.WriteLine("Loai nguyen lieu khong ton tai!");
                    }
                    break;
                case errType.NguyenLieuDaTonTai:
                    {
                        Console.WriteLine("Nguyen lieu da ton tai!");
                    }
                    break;
                case errType.PhieuThuKhongTonTai:
                    {
                        Console.WriteLine("Phieu thu khong ton tai!");
                    }
                    break;
                case errType.PhieuThuDaTonTai:
                    {
                        Console.WriteLine("Phieu thu da ton tai!");
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
