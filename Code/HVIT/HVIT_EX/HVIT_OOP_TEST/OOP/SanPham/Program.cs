using System;

namespace SanPham
{
    class Program
    {
        static void Main(string[] args)
        {
            SanPham sanPham = new SanPham(1, "may tinh ThinkPad", "Laptop", true);
            sanPham.HienThi();
            Console.ReadKey();
        }
    }
}
