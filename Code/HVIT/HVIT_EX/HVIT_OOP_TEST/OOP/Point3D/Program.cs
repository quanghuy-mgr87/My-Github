using System;

namespace Point3D
{
    class Program
    {
        static void Main(string[] args)
        {
            Point3D p1 = new Point3D();
            Point3D p2 = new Point3D(5, 4, -4);
            Console.WriteLine($"Khoang cach giua 2 diem la: {Point3D.TinhKhoangCach(p1, p2)}");
            Console.ReadKey();
        }
    }
}
