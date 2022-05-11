using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVIT_MVC_HocSinh.Helper
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
                if (!ok)
                {
                    Console.WriteLine(err);
                }
            } while (!ok);
            return ret;
        }
        public static double InputDouble(string msg, string err, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            double ret;
            bool ok;
            do
            {
                Console.Write(msg);
                string str = Console.ReadLine();
                ok = double.TryParse(str, out ret);
                ok = ok && (ret >= minValue && ret <= maxValue);
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
        public static string NhapTen(string msg, string err)
        {
            string name = InputString(msg, err);
            name = name.ToLower();
            while (name.Contains("  "))
            {
                name = name.Replace("  ", " ");
            }
            string[] arrStr = name.Split(' ');
            name = "";
            for (int i = 0; i < arrStr.Length; i++)
            {
                name += arrStr[i].Substring(0, 1).ToUpper() + arrStr[i].Substring(1) + " ";
            }
            return name.Trim();
        }
        public static double NhapDiem(string msg, string err)
        {
            bool ok;
            double diem;
            do
            {
                diem = InputDouble(msg, err, 0, 10);
                ok = diem % 0.25 == 0;
                if (!ok)
                {
                    Console.WriteLine(err);
                }
            } while (!ok);
            return diem;
        }
    }
}
