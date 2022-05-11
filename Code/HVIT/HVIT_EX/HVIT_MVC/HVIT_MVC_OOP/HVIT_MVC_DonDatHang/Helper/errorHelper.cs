using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_MVC_DonDatHang.Helper
{
    enum errorType
    {
        DaTonTai,
        ChuaTonTai,
        DanhSachTrong,
        ThanhCong
    }
    class errorHelper
    {
        public static void log(errorType errorType)
        {
            switch (errorType)
            {
                case errorType.DaTonTai:
                    {
                        Console.WriteLine("Da ton tai!");
                    }
                    break;
                case errorType.ChuaTonTai:
                    {
                        Console.WriteLine("Chua ton tai!");
                    }
                    break;
                case errorType.DanhSachTrong:
                    {
                        Console.WriteLine("Danh sach trong!");
                    }
                    break;
                case errorType.ThanhCong:
                    {
                        Console.WriteLine("Thanh cong!");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
