using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void HienThiDanhSach(List<int> lst)
        {
            lst.ForEach(x => Console.Write(x + " "));
        }
        static List<int> LayDanhSachChan(List<int> lst)
        {
            List<int> lstChan = new List<int>();
            foreach (var val in lst)
            {
                if (val % 2 == 0)
                    lstChan.Add(val);
            }
            return lstChan;
        }
        static List<int> LayDanhSachLe(List<int> lst)
        {
            List<int> lstLe = new List<int>();
            foreach (var val in lst)
            {
                if (val % 2 != 0)
                    lstLe.Add(val);
            }
            return lstLe;
        }
        static List<int> SapXepTang(List<int> lst)
        {
            int[] arr = lst.ToArray();
            Array.Sort(arr);
            lst = arr.ToList();
            return lst;
        }
        static List<int> SapXepGiam(List<int> lst)
        {
            int[] arr = lst.ToArray();
            Array.Sort(arr);
            Array.Reverse(arr);
            lst = arr.ToList();
            return lst;
        }
        static List<int> DanhSachChanTangLeGiam(List<int> lstChan, List<int> lstLe)
        {
            lstChan = SapXepTang(lstChan);
            lstLe = SapXepGiam(lstLe);
            List<int> lst = new List<int>();
            lstChan.ForEach(x => lst.Add(x));
            lstLe.ForEach(x => lst.Add(x));
            return lst;
        }
        static void Main(string[] args)
        {
            List<int> lst = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("Danh sach ban dau:");
            HienThiDanhSach(lst);

            List<int> lstChan = LayDanhSachChan(lst);
            Console.WriteLine("\nDanh sach chan:");
            HienThiDanhSach(lstChan);
            List<int> lstLe = LayDanhSachLe(lst);
            Console.WriteLine("\nDanh sach le:");
            HienThiDanhSach(lstLe);

            lst = DanhSachChanTangLeGiam(lstChan, lstLe);
            Console.WriteLine("\nDanh sach chan tang le giam:");
            HienThiDanhSach(lst);
            Console.ReadKey();
        }
    }
}
