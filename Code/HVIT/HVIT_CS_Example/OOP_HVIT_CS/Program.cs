using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata;

namespace OOP_HVIT_CS
{
    class Program
    {
        class Nguoi
        {
            public string ten { get; set; }
            public int tuoi { get; set; }
            public void HienThi()
            {
                Console.WriteLine($"{ten} co tuoi la {tuoi}");
            }
        }
        static void Main(string[] args)
        {
            List<Nguoi> lst = new List<Nguoi>()
            {
                new Nguoi() { ten = "Quang Huy", tuoi = 23 },
                new Nguoi() { ten = "Nguyen B", tuoi = 24 },
                new Nguoi() { ten = "Quang B", tuoi = 25 },
                new Nguoi() { ten = "Nguyen D", tuoi = 26 },
                new Nguoi() { ten = "B Nguyen", tuoi = 26 }
            };

            /////////////////////////////////
            // tìm từ trên xuống dưới, nếu có phần tử phù hợp sẽ dừng lại ngay
            Nguoi n1 = lst.Find(x => x.ten.EndsWith("B"));
            if (n1 != null)
            {
                n1.HienThi();
            }

            // tìm từ dưới lên trên, nếu có phần tử phù hợp sẽ dừng lại.
            Nguoi n2 = lst.FindLast(x => x.ten.Contains("B"));
            if (n2 != null)
            {
                n2.HienThi();
            }
            Console.ReadKey();
        }
    }
}
