﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLKhoaHocMVC.Helper
{
    enum inputType
    {
        ThemNgayHocVaoKhoaHoc,
        SuaThongTinHocVien,
        XoaKhoaHoc,
        TimHocVienTheoHoTenVaKhoaHoc,
        TinhDoanhThu,
        ThemHocVien
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
                ok = int.TryParse(str, out ret) && (ret >= minValue && ret <= maxValue);
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
        public static string NhapTen(string msg, string err)
        {
            string str;
            string name = "";
            bool ok;
            do
            {
                Console.Write(msg);
                str = Console.ReadLine().Trim().ToLower();
                while (str.Contains("  "))
                {
                    str = str.Replace("  ", " ");
                }
                string[] arrStr = str.Split(' ');
                for (int i = 0; i < arrStr.Length; i++)
                {
                    name += arrStr[i].First().ToString().ToUpper() + arrStr[i].Substring(1) + " ";
                }
                ok = name.Length <= 20 && name.Split(' ').Length >= 2;
                if (!ok)
                {
                    Console.WriteLine(err);
                }
            } while (!ok);
            return name.Trim();
        }
        public static DateTime NhapNgay(string msg, string err)
        {
            bool ok;
            DateTime date;
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
