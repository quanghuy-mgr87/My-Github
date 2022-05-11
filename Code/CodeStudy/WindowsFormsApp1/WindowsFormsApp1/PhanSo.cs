using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class PhanSo
    {
        public int TuSo { get; set; }
        public int MauSo { get; set; }

        public PhanSo()
        {
        }

        public PhanSo(int tuSo, int mauSo)
        {
            TuSo = tuSo;
            MauSo = mauSo;
        }

        public double TinhPi()
        {
            return TuSo * 1.0 / MauSo;
        }

        public double TinhPiNghichDao()
        {
            return MauSo * 1.0 / TuSo;
        }
    }
}
