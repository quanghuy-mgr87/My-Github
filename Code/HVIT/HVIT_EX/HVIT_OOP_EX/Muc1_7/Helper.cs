using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muc1_7
{
    class Helper
    {
        public static int NhapThoiGian(string msg, string err, int min = int.MinValue, int max = int.MaxValue)
        {
            int ret = 0;
            bool ok = false;
            do
            {
                Console.Write(msg);
                string str = Console.ReadLine();
                ok = int.TryParse(str, out ret);
                ok = ok && (ret >= min && ret <= max);
                if (!ok)
                {
                    Console.WriteLine(err);
                }
            } while (!ok);
            return ret;
        }
    }
}
