using System;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        /// Để ra được comment này thì ấn 3 dấu "/" /// ở ngay trên tên hàm là tự ra
        /// <summary>
        /// Hàm nhập danh sách
        /// </summary>
        /// <returns>Danh sách sau khi nhập</returns>
        static List<int> NhapDS()
        {
            List<int> lst = new List<int>();
            Console.Write("Nhap so luong phan tu trong ds: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.Write($"lst[{i}]: ");
                lst.Add(int.Parse(Console.ReadLine()));
            }
            return lst;
        }
        /// <summary>
        /// Hàm in danh sách
        /// </summary>
        /// param là tham số truyền vào
        /// <param name="lst">List cần in</param>
        static void InDS(List<int> lst)
        {
            lst.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
        }
        /// <summary>
        /// Nhập mảng
        /// </summary>
        /// <param name="arr">Mảng cần nhập</param>
        static void NhapMang(List<int>[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Nhap arr[{i}]:");
                arr[i] = NhapDS();
            }
        }
        /// <summary>
        /// In mảng
        /// </summary>
        /// <param name="arr">Mảng cần in</param>
        static void InMang(List<int>[] arr)
        {
            foreach (var item in arr)
            {
                InDS(item);
            }
        }
        /// <summary>
        /// Tính trung bình cộng
        /// </summary>
        /// <param name="lst">List cần tính TBC</param>
        /// <returns>Giá trị trung bình cộng</returns>
        static double TinhTBC(List<int> lst)
        {
            double dem = 0, tong = 0;
            lst.ForEach(x =>
            {
                dem++;
                tong += x;
            });
            return tong * 1.0 / dem;
        }
        /// <summary>
        /// Sắp xếp mảng
        /// </summary>
        /// <param name="arr">Mảng cần sắp xếp</param>
        static void SapXepMang(List<int>[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if(TinhTBC(arr[i]) < TinhTBC(arr[j]))
                    {
                        List<int> temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int n = 3;
            List<int>[] arr = new List<int>[n];
            NhapMang(arr);
            InMang(arr);
            SapXepMang(arr);
            InMang(arr);
            Console.ReadKey();
        }
    }
}
