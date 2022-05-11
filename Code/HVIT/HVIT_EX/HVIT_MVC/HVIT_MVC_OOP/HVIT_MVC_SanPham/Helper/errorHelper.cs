using HVIT_MVC_SanPham.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_MVC_SanPham.Helper
{
    class errorHelper
    {
        public static void log(errorType errorType)
        {
            switch (errorType)
            {
                case errorType.DaTonTai:
                    {
                        Console.WriteLine("San pham da ton tai!");
                    }
                    break;
                case errorType.ChuaTonTai:
                    {
                        Console.WriteLine("San pham chua ton tai!");
                    }
                    break;
                case errorType.DanhSachTrong:
                    {
                        Console.WriteLine("Danh sach trong!");
                    }
                    break;
                case errorType.ThanhCong:
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
