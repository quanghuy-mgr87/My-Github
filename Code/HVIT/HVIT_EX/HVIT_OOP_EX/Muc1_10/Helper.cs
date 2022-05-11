using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muc1_10
{
    class Helper
    {
        /// <summary>
        /// Ham tao so nguyen duong
        /// </summary>
        /// <param name="msg">Thong diep truyen vao</param>
        /// <param name="err">Thong diep loi</param>
        /// <param name="min">Gia tri nho nhat</param>
        /// <returns>So nguyen duong</returns>
        public static int TaoSoNguyenDuong(string msg, string err, int min = int.MinValue)
        {
            int ret = 0;
            bool ok = false;
            do
            {
                Console.Write(msg);
                string str = Console.ReadLine();
                ok = int.TryParse(str, out ret);
                ok = ok && (ret >= min);
                if (!ok)
                {
                    Console.WriteLine(err);
                }
            } while (!ok);
            return ret;
        }

        /// <summary>
        /// Ham tinh tong 2 mang 2 chieu
        /// </summary>
        /// <param name="a">Mang 2 chieu</param>
        /// <param name="b">Mang 2 chieu</param>
        /// <returns>Mang 2 chieu la tong cua 2 mang truyen vao</returns>
        public static int[,] TinhTong(int[,] a, int[,] b)
        {
            int[,] temp = new int[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    temp[i, j] = a[i, j] + b[i, j];
                }
            }
            return temp;
        }
    }
}
