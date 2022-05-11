using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muc1_10
{
    class MaTran
    {
        public int SoHang { get; set; }
        public int SoCot { get; set; }
        public int[,] MaTrix { get; set; }
        public MaTran()
        {
            SoHang = Helper.TaoSoNguyenDuong("Nhap so hang: ", "Ban can nhap so nguyen duong", 0);
            SoCot = Helper.TaoSoNguyenDuong("Nhap so cot: ", "Ban can nhap so nguyen duong", 0);
            MaTrix = new int[SoHang, SoCot];
            NhapMaTran();
        }
        public MaTran(int[,] Mat, int SoHang, int SoCot)
        {
            this.SoHang = SoHang;
            this.SoCot = SoCot;
            MaTrix = Mat;
        }
        public MaTran CongMaTran(MaTran m)
        {
            int[,] temp = null;
            if (SoHang == m.SoHang && SoCot == m.SoCot)
            {
                temp = Helper.TinhTong(MaTrix, m.MaTrix);
            }
            else
            {
                Console.WriteLine("2 ma tran khong cung kich co!");
                return null;
            }
            return new MaTran(temp, SoHang, SoCot);
        }
        public void NhapMaTran()
        {
            for (int i = 0; i < MaTrix.GetLength(0); i++)
            {
                for (int j = 0; j < MaTrix.GetLength(1); j++)
                {
                    Console.Write($"MaTrix[{i}, {j}] = ");
                    MaTrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }
        public void InMaTran()
        {
            for (int i = 0; i < SoHang; i++)
            {
                for (int j = 0; j < SoCot; j++)
                {
                    Console.Write($"{MaTrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
