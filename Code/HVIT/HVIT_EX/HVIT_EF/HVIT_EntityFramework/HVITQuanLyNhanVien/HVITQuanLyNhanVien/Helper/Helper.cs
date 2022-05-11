using System;
using System.Collections.Generic;
using System.Text;

namespace HVITQuanLyNhanVien
{
    public class Helper
    {
        public static string NhapHoTen(string msg, string err, int gioiHanKyTu = int.MaxValue)
        {
            string HoTen;
            bool ok;
            do
            {
                Console.Write(msg);
                HoTen = Console.ReadLine();
                HoTen = HoTen.Trim();
                while (HoTen.Contains("  "))
                {
                    HoTen = HoTen.Replace("  ", " ");
                }
                ok = HoTen.Length <= gioiHanKyTu && HoTen.Contains(" ");
                if (!ok)
                {
                    Console.WriteLine(err);
                }
            } while (!ok);
            return HoTen;
        }
        public static string NhapTenDuAn(string msg, string err, int gioiHanKyTu = int.MaxValue)
        {
            string tenDuAn;
            bool ok;
            do
            {
                Console.Write(msg);
                tenDuAn = Console.ReadLine();
                tenDuAn = tenDuAn.Trim();
                while (tenDuAn.Contains("  "))
                {
                    tenDuAn = tenDuAn.Replace("  ", " ");
                }
                ok = tenDuAn.Length <= gioiHanKyTu;
                if (!ok)
                {
                    Console.WriteLine(err);
                }
            } while (!ok);
            return tenDuAn;
        }
        public static string NhapEmail(string msg, string err)
        {
            string email;
            bool ok;
            do
            {
                Console.Write(msg);
                email = Console.ReadLine();
                ok = email.Contains("@");
                if (!ok)
                {
                    Console.WriteLine(err);
                }
            } while (!ok);
            return email;
        }
        public static int NhapSoGioLam(string msg, string err)
        {
            int ret;
            bool ok;
            do
            {
                Console.Write(msg);
                string str = Console.ReadLine();
                ok = int.TryParse(str, out ret) && ret >= 0;
                if (!ok)
                {
                    Console.WriteLine(err);
                }
            } while (!ok);
            return ret;
        }
    }
}
