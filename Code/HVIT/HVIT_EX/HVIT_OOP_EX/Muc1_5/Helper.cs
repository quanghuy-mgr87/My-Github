using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muc1_5
{
    class Helper
    {
        /// <summary>
        /// Hàm tách các chữ số của 1 số truyền vào
        /// </summary>
        /// <param name="num">Số cần tách</param>
        /// <returns>Danh sách các số sau khi tách</returns>
        public static List<int> TachSo(int num)
        {
            List<int> lst = new List<int>();
            int n = num;
            while (n >= 10)
            {
                lst.Add(n % 10);
                n /= 10;
            }
            lst.Add(n);
            return lst;
        }

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
    }
}
