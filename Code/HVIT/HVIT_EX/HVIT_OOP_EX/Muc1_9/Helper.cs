using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muc1_9
{
    class Helper
    {
        public static int NhapThoiGian(string msg, string err = "", int min = int.MinValue, int max = int.MaxValue)
        {
            int ret = 0;
            bool ok = false;
            do
            {
                Console.Write(msg);
                string str = Console.ReadLine();
                ok = int.TryParse(str, out ret);
                bool ok2 = (ret >= min && ret <= max);
                ok = ok && ok2;
                if (!ok)
                {
                    Console.WriteLine($"Ban can nhap so nguyen nam trong khoang {min} - {max}!");
                }
            } while (!ok);
            return ret;
        }
    }
}
