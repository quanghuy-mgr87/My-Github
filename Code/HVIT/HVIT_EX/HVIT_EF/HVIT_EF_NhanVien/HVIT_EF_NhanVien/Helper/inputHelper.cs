using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVIT_EF_NhanVien.Helper
{
    enum inputType
    {
        ThemNhanVien,
        ThemNhanVienVaoDuAn,
        SuaDuAn,
        XoaNhanVien,
        TinhLuong
    }
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
                if (!ok)
                {
                    Console.WriteLine(err);
                }
            } while (!ok);
            return ret;
        }
        public static string InputString(string msg, string err, int minLength = int.MinValue, int maxLength = int.MaxValue)
        {
            bool ok;
            string str;
            do
            {
                Console.Write(msg);
                str = Console.ReadLine();
                ok = !string.IsNullOrEmpty(str);
                ok = ok && str.Length >= minLength && str.Length <= maxLength;
                if (!ok)
                {
                    Console.WriteLine(err);
                }
            } while (!ok);
            return str;
        }

        public static string NhapSoDT(string msg, string err, int minLength = int.MinValue, int maxLength = int.MaxValue)
        {
            string str;
            int ret;
            bool ok;
            do
            {
                str = InputString(msg, err, minLength, maxLength);
                ok = int.TryParse(str, out ret);
                if (!ok)
                {
                    Console.WriteLine(err);
                }
            } while (!ok);
            return str;
        }

        public static string NhapEmail(string msg, string err)
        {
            string str;
            bool ok;
            do
            {
                str = InputString(msg, err);
                ok = str.Contains("@");
                if (!ok)
                {
                    Console.WriteLine(err);
                }
            } while (!ok);
            return str;
        }
        public static string NhapTen(string msg, string err)
        {
            string name = "";
            bool ok;
            string hoTen;
            do
            {
                hoTen = InputString(msg, err);
                hoTen = hoTen.Trim().ToLower();
                while (hoTen.Contains("  "))
                {
                    hoTen = hoTen.Replace("  ", " ");
                }
                string[] arrStr = hoTen.Split(' ');
                for (int i = 0; i < arrStr.Length; i++)
                {
                    name += arrStr[i].First().ToString().ToUpper() + arrStr[i].Substring(1) + " ";
                }
                ok = arrStr.Length >= 2 && name.Length <= 20;
                if (!ok)
                {
                    Console.WriteLine(err);
                }
            } while (!ok);
            return name.Trim();
        }
    }
}
