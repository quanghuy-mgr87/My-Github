using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static List<string> VietHoaDenN(List<string> lstStr, int n)
        {
            List<string> newLst = new List<string>();
            newLst = lstStr;
            return newLst.Select(x => x.Length <= n ? x.ToUpper() : x.Substring(0, n).ToUpper() + x.Substring(n).ToLower()).ToList();
        }

        static List<String> SapXepDS(List<String> lstStr)
            => lstStr.OrderByDescending(x => x.Length).ToList();

        static void InDS(List<String> lst)
            => lst.ForEach(x => Console.WriteLine(x));

        static void Main(string[] args)
        {
            List<String> lst = new List<string> { "Do Phuong Linh", "Nguyen Ba Quang Huy", "Kim Jung Hwa", "aa", "bbb" };
            Console.WriteLine($"Viet hoa den ki tu thu {lst.Count}:");
            InDS(VietHoaDenN(lst, lst.Count()));
            Console.WriteLine("\nSap xep danh sach theo do dai chuoi giam dan:");
            InDS(SapXepDS(lst));
            Console.WriteLine("\nDanh sach ban dau:");
            InDS(lst);
        }
    }
}
