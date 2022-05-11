using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace HVIT_CS
{
    class Program
    {
        /// <summary>
        /// Hàm tính trung bình cộng các số trong danh sách
        /// </summary>
        /// <param name="lst">Danh sách truyền vào</param>
        /// <returns></returns>
        static double TinhTBC(List<int> lst)
        {
            double tong = 0;
            foreach (int val in lst)
            {
                tong += val;
            }
            int dem = lst.Count;
            return (double)tong / dem;
        }

        /// <summary>
        /// Hàm kiểm tra số nhập vào có phải số nguyên hay không
        /// </summary>
        /// <param name="str">Số truyền vào</param>
        /// <returns></returns>
        static bool KiemTraSoNguyen(string str)
        {
            int n;
            if (!int.TryParse(str, out n))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Hàm nhập danh sách
        /// </summary>
        /// <param name="lst">Danh sách</param>
        /// <param name="n">Số phần tử của danh sách</param>
        /// <returns></returns>
        static List<int> NhapDS(List<int> lst, int n)
        {
            lst = new List<int>();
            for (int i = 0; i < n; i++)
            {
                string str;
                do
                {
                    Console.Write($"Phan tu thu {i}: ");
                    str = Console.ReadLine();
                    if (!KiemTraSoNguyen(str))
                    {
                        Console.WriteLine("Phan tu vua nhap khong la so nguyen. Moi nhap lai!");
                    }
                } while (!KiemTraSoNguyen(str));
                int temp = int.Parse(str);
                lst.Add(temp);
            }
            return lst;
        }

        /// <summary>
        /// Hàm in các phần tử của danh sách
        /// </summary>
        /// <param name="lst">Danh sách truyền vào</param>
        static void InDS(List<int> lst)
        {
            lst.ForEach(x => Console.Write($"{x} "));
        }

        /// <summary>
        /// Hàm nhập mảng các danh sách
        /// </summary>
        /// <param name="a">Mảng truyền vào</param>
        static void NhapMang(List<int>[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                int n;
                Console.Write("\n- Nhap so luong phan tu trong List: ");
                n = int.Parse(Console.ReadLine());
                Console.WriteLine($"Nhap danh sach thu {i}:");
                a[i] = NhapDS(a[i], n);
            }
        }

        /// <summary>
        /// Hàm in mảng các danh sách
        /// </summary>
        /// <param name="a">Mảng truyền vào</param>
        static void InMang(List<int>[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                InDS(a[i]);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Sắp xếp mảng
        /// </summary>
        /// <param name="a">Mảng truyền vào</param>
        static void SapXepMang(List<int>[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (TinhTBC(a[i]) < TinhTBC(a[j]))
                    {
                        List<int> temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int n;
            Console.Write("Nhap so luong danh sach:");
            n = int.Parse(Console.ReadLine());
            List<int>[] arr = new List<int>[n];
            Console.WriteLine("Nhap mang:");
            NhapMang(arr);
            Console.WriteLine("\nMang cac danh sach vua nhap:");
            InMang(arr);
            Console.WriteLine("\nMang sau khi sap xep:");
            SapXepMang(arr);
            InMang(arr);
            Console.ReadKey();
        }
    }
}
