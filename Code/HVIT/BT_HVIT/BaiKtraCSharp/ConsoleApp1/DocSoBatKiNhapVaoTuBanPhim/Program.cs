using System;
using System.Collections.Generic;

namespace DocSoBatKiNhapVaoTuBanPhim
{
    class Program
    {
        static int DemSoLuongSo(int n)
        {
            return n.ToString().Length;
        }
        static void Main(string[] args)
        {
            int num;
            Console.WriteLine("Nhap so: ");
            num = int.Parse(Console.ReadLine());

        }
    }
}
