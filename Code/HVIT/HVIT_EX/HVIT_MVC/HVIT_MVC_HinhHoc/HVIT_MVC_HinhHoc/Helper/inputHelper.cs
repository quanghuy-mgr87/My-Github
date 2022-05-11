using HVIT_MVC_HinhHoc.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_MVC_HinhHoc.Helper
{
    class inputHelper
    {
        public static int InputInt(string msg, string err, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            int ret;
            bool ok;
            do
            {
                Console.Write(msg);
                string str = Console.ReadLine();
                ok = int.TryParse(str, out ret);
                ok = ok && ret >= minValue && ret <= maxValue;
                if (!ok)
                {
                    Console.WriteLine(err);
                }
            } while (!ok);
            return ret;
        }
        public static double TinhKhoangCachHaiDiem(Diem d1, Diem d2)
        {
            return Math.Sqrt(Math.Pow((d2.x - d1.x), 2) + Math.Pow((d2.y - d1.y), 2));
        }
    }
}
