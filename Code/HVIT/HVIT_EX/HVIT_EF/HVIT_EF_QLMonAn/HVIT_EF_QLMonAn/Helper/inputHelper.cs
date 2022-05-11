using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLMonAn.Helper
{
    enum inputType
    {
        ThemMonAn,
        ThemCongThucMonAn,
        XoaLoaiMon,
        TimMonAnTheoTenVaNguyenLieu
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
        public static string NhapTenMon(string msg, string err)
        {
            string str;
            bool ok;
            do
            {
                str = InputString(msg, err, 0, 20);
                ok = !string.IsNullOrEmpty(str);
                if (!ok)
                {
                    Console.WriteLine(err);
                }
            } while (!ok);
            return str;
        }
        public static string NhapTenNguyenLieu(string msg, string err)
        {
            string str;
            bool ok;
            do
            {
                str = InputString(msg, err, 0, 20);
                ok = !string.IsNullOrEmpty(str);
                if (!ok)
                {
                    Console.WriteLine(err);
                }
            } while (!ok);
            return str;
        }
        public static string NhapDonVi(string msg, string err)
        {
            string str = InputString(msg, err, 0, 10);
            return str;
        }

    }
}
