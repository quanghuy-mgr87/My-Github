using System;
using System.Collections.Generic;
using System.Text;

namespace SoPhuc
{
    class SoPhuc
    {
        public int PhanThuc { get; set; }
        public int PhanAo { get; set; }
        public SoPhuc()
        {
            Console.Write("Nhap phan thuc: ");
            PhanThuc = int.Parse(Console.ReadLine());
            Console.Write("Nhap phan ao: ");
            PhanAo = int.Parse(Console.ReadLine());
        }
        public SoPhuc(int PhanThuc, int PhanAo)
        {
            this.PhanAo = PhanAo;
            this.PhanThuc = PhanThuc;
        }
        public void HienThi()
        {
            Console.WriteLine($"{PhanThuc} + {PhanAo}i");
        }
    }
}
