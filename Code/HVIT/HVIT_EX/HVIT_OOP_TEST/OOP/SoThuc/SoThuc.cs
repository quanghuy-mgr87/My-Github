using System;
using System.Collections.Generic;
using System.Text;

namespace SoThuc
{
    class SoThuc
    {
        private double _GiaTri;
        public double GiaTri
        {
            get { return _GiaTri; }
            set
            {
                _GiaTri = value;
                KiemTraSoDuong();
            }
        }
        public bool LaSoDuong { get; set; }
        public void KiemTraSoDuong()
        {
            LaSoDuong = GiaTri > 0 ? true : false;
        }
        public SoThuc()
        {
            Console.Write("Nhap so thuc: ");
            GiaTri = double.Parse(Console.ReadLine());
        }

        public static SoThuc TimMax(SoThuc a, SoThuc b, SoThuc c)
        {
            return a.GiaTri >= b.GiaTri && a.GiaTri >= c.GiaTri ? a : b.GiaTri >= c.GiaTri && b.GiaTri >= a.GiaTri ? b : c;
        }

        public double TinhCanBacN(int n)
        {
            return Math.Pow(GiaTri, 1.0 / n);
        }
    }
}
