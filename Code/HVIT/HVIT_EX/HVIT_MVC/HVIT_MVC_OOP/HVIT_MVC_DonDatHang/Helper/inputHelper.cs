using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_MVC_DonDatHang.Helper
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
        public static float InputFloat(string msg, string err, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            float ret;
            bool ok;
            do
            {
                Console.Write(msg);
                string str = Console.ReadLine();
                ok = float.TryParse(str, out ret);
                ok = ok && ret >= minValue && ret <= maxValue;
                if (!ok)
                {
                    Console.WriteLine(err);
                }
            } while (!ok);
            return ret;
        }
        public static string InputString(string msg, string err, int minLength = int.MinValue, int maxLength = int.MaxValue)
        {
            string str;
            bool ok;
            do
            {
                Console.Write(msg);
                str = Console.ReadLine();
                ok = str.Length >= minLength && str.Length <= maxLength;
                if (!ok)
                {
                    Console.WriteLine(err);
                }
            } while (!ok);
            return str;
        }
        public static DateTime InputDateTime(string msg, string err)
        {
            DateTime date;
            bool ok;
            do
            {
                Console.Write(msg);
                string str = Console.ReadLine();
                ok = DateTime.TryParse(str, out date);
                if (!ok)
                {
                    Console.WriteLine(err);
                }
            } while (!ok);
            return date;
        }
    }
}
