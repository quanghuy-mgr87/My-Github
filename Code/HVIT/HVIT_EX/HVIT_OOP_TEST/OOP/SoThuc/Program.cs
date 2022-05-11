using System;

namespace SoThuc
{
    class Program
    {
        static void Main(string[] args)
        {
            SoThuc[] arrSoThuc = new SoThuc[5];
            for (int i = 0; i < arrSoThuc.Length; i++)
            {
                arrSoThuc[i] = new SoThuc();
            }

            Console.WriteLine("So lon nhat trong 3 so thuc la: ");
            Console.WriteLine(SoThuc.TimMax(arrSoThuc[0], arrSoThuc[1], arrSoThuc[2]).GiaTri);

            Console.WriteLine("Can bac 3 cua cac so thuc la: ");
            for (int i = 0; i < arrSoThuc.Length; i++)
            {
                Console.WriteLine(arrSoThuc[i].TinhCanBacN(3));
            }
        }
    }
}
