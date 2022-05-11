using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_HVIT_CS
{
    class NhapLieu
    {
        /// <summary>
        /// Thực hiện tạo số nguyên
        /// </summary>
        /// <param name="msg">Thông điệp tạo số</param>
        /// <param name="err">Thông điệp lỗi</param>
        /// <returns>Số tạo được</returns>
        public static int TaoSoInt(string msg, string err, int min = int.MinValue, int max = int.MaxValue)
        {
            int ret = 0;
            bool ok = false;
            do
            {
                Console.Write(msg);
                string str = Console.ReadLine();
                ok = int.TryParse(str, out ret);
                if (!ok)
                {
                    Console.WriteLine(err);
                }
                else
                {
                    if (ret < min || ret > max)
                    {
                        Console.WriteLine(err);
                        ok = false;
                    }
                }
            } while (!ok);
            return ret;
        }
    }
}
