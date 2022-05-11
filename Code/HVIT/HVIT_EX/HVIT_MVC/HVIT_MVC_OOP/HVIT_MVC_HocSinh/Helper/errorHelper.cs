using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_MVC_HocSinh.Helper
{
    enum errorType
    {
        HSDaTonTai,
        MHDaTonTai,
        HSChuaTonTai,
        MHChuaTonTai,
        DanhSachTrong,
        ThanhCong
    }
    class errorHelper
    {
        public static void log(errorType errorType)
        {
            switch (errorType)
            {
                case errorType.HSDaTonTai:
                    {
                        Console.WriteLine("Hoc sinh da ton tai!");
                    }
                    break;
                case errorType.MHDaTonTai:
                    {
                        Console.WriteLine("Mon hoc da ton tai!");
                    }
                    break;
                case errorType.HSChuaTonTai:
                    {
                        Console.WriteLine("Hoc sinh chua ton tai!");
                    }
                    break;
                case errorType.MHChuaTonTai:
                    {
                        Console.WriteLine("Mon hoc chua ton tai!");
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
