using System;
using System.Collections.Generic;
using System.Text;

namespace TroChoiXucXac
{
    class XucXac
    {
        public int GiaTri1 { get; set; }
        public int GiaTri2 { get; set; }
        public bool Thang { get; set; }
        public bool Thua { get; set; }
        public bool Hoa { get; set; }
        public XucXac() { }
        public void BatDau()
        {

            do
            {
                Console.Clear();
                int r1, r2, r3;
                NhapGiaTri();
                if (GiaTri1 < 3 || GiaTri1 > 18)
                {
                    Console.WriteLine("End.");
                    break;
                }
                Random random = new Random();
                r1 = random.Next(1, 7);
                r2 = random.Next(1, 7);
                r3 = random.Next(1, 7);
                GiaTri2 = r1 + r2 + r3;
                Thang = GiaTri1 > GiaTri2;
                Thua = GiaTri1 < GiaTri2;
                Hoa = GiaTri1 == GiaTri2;
                InThongTin(r1, r2, r3);
            } while (GiaTri1 >= 3 && GiaTri1 <= 18);
        }
        private void NhapGiaTri()
        {
            Console.Write("Your point: ");
            GiaTri1 = int.Parse(Console.ReadLine());
        }
        private void InThongTin(int r1, int r2, int r3)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine($"XucXac's turn: {r1}, {r2}, {r3}\n" +
                $"XucXac's point: {GiaTri2}");
            Console.WriteLine("--------------------");
            string result = "";
            Console.WriteLine(result = Thang ? "You win!!!!" : Thua ? "You lose" : "Draw");
            Console.ReadKey();
        }
    }
}
