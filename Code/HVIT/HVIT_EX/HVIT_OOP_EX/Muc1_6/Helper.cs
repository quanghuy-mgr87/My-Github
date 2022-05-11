using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muc1_6
{
    class Helper
    {
        /// <summary>
        /// Hàm tạo số nguyên
        /// </summary>
        /// <param name="msg">Thông điệp tạo số</param>
        /// <param name="err">Thông điệp lỗi</param>
        /// <returns>Số tạo được</returns>
        public static int TaoSoNguyen(string msg, string err)
        {
            int ret = 0;
            bool ok;
            do
            {
                Console.Write(msg);
                string str = Console.ReadLine();
                ok = int.TryParse(str, out ret);
                if (!ok)
                {
                    Console.WriteLine(err);
                }
            } while (!ok);
            return ret;
        }
        /// <summary>
        /// Hàm tìm ước chung lớn nhất
        /// </summary>
        /// <param name="a">Số thứ nhất</param>
        /// <param name="b">Số thứ hai</param>
        /// <returns>Ước chung lớn nhất của 2 số</returns>
        public static int TimUocChungLonNhat(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                    a -= b;
                if (a < b)
                    b -= a;
            }
            return a;
        }
    }
}
