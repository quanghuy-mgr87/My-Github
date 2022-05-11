using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVIT_MVC.Helper
{
    class InputHelper
    {
        public static int InputINT(string msg, string err)
        {
            bool ok = true;
            int ret;
            do
            {
                Console.Write(msg);
                ok = int.TryParse(Console.ReadLine(), out ret);
                if (!ok)
                {
                    Console.WriteLine(err);
                }
            } while (!ok);
            return ret;
        }

        public static string InputSTR(string msg, string err, int minLength = 0, int maxLength = int.MaxValue)
        {
            bool ok = true;
            string ret;
            do
            {
                Console.Write(msg);
                ret = Console.ReadLine();
                ok = ret.Length >= minLength || ret.Length <= maxLength;
                if (!ok)
                {
                    Console.WriteLine(err);
                }
            } while (!ok);
            return ret;
        }

        public static DateTime InputDT(string msg, string err, DateTime min, DateTime max)
        {
            bool ok = true;
            DateTime ret;
            do
            {
                Console.Write(msg);
                ok = DateTime.TryParse(Console.ReadLine(), out ret);
                ok = ok && (ret >= min || ret <= max);
                if (!ok)
                {
                    Console.WriteLine(err);
                }
            } while (!ok);
            return ret;
        }
    }
}
