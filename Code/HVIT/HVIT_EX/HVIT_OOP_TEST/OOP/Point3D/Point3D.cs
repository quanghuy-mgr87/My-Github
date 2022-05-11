using System;
using System.Collections.Generic;
using System.Text;

namespace Point3D
{
    class Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Point3D()
        {
            Console.Write("Nhap x: ");
            X = int.Parse(Console.ReadLine());
            Console.Write("Nhap y: ");
            Y = int.Parse(Console.ReadLine());
            Console.Write("Nhap z: ");
            Z = int.Parse(Console.ReadLine());
        }
        public Point3D(int x, int y, int z)
            => (X, Y, Z) = (x, y, z);
        public void InThongTin()
        {
            Console.WriteLine($"({X},{Y},{Z})");
        }
        public static double TinhKhoangCach(Point3D p1, Point3D p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2) + Math.Pow(p2.Z - p1.Z, 2));
        }
    }
}
