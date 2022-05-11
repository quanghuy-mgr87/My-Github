using System;
using System.Collections.Generic;
using System.Linq;

namespace Bai2
{
    class Program
    {
        static List<int> AddList()
        {
            Console.Write("Nhap so luong phan tu danh sach: ");
            int n = int.Parse(Console.ReadLine());
            List<int> lst = new List<int>();
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Phan tu thu {i}: ");
                lst.Add(int.Parse(Console.ReadLine()));
            }
            return lst;
        }

        static void ShowList(List<int> lst)
            => lst.ForEach(x => Console.Write(x + " "));

        static void AddArr(List<int>[] arr, int num)
        {
            for (int i = 0; i < num; i++)
            {
                arr[i] = AddList();
            }
        }

        static void ShowArr(List<int>[] arr)
        {
            foreach (var val in arr)
            {
                ShowList(val);
                Console.WriteLine();
            }
        }

        static List<int>[] SortArrayByAverage(List<int>[] arr)
            => arr.OrderByDescending(x => x.Average()).ToArray();

        static void Main(string[] args)
        {
            List<int>[] arrInt;
            int num;
            Console.Write("Nhap so luong phan tu mang: ");
            num = int.Parse(Console.ReadLine());
            arrInt = new List<int>[num];
            AddArr(arrInt, num);
            Console.WriteLine("Mang ban dau: ");
            ShowArr(arrInt);
            Console.WriteLine("\nMang sau khi sap xep:");
            arrInt = SortArrayByAverage(arrInt);
            ShowArr(arrInt);
        }
    }
}
