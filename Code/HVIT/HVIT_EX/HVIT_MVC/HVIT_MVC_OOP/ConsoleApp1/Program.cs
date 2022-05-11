using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace HVIT_CS
{
    class Program
    {
        static string XoaKhoangTrong(string str)
        {
            str = str.Trim();
            while (str.Contains("  "))
                str = str.Replace("  ", " ");
            return str;
        }

        static string VietHoaChuCaiDau(string str)
        {
            str = str.ToLower();
            string temp = str.First().ToString();
            str = str.Replace(temp, temp.ToUpper());
            return str;
        }

        static string ChuanHoaChuoi(string str)
        {
            str = XoaKhoangTrong(str);
            string[] arrStr = str.Split(" ");
            string temp = "";
            int size = arrStr.Length;
            arrStr[size - 1] = VietHoaChuCaiDau(arrStr[size - 1]);
            temp += arrStr[size - 1];
            for (int i = 0; i < size - 1; i++)
            {
                temp += arrStr[i].First().ToString().ToUpper();
            }
            return temp;
        }

        static int DemSoLanXuatHien(List<string> lst, string str)
        {
            int dem = 0;
            foreach (string val in lst)
            {
                if (String.Compare(str, val) == 0)
                {
                    dem++;
                }
            }
            return dem;
        }
        /// <summary>
        /// Chuẩn hóa các chuỗi trong danh sách
        /// Tạo 1 danh sách tạm để lưu các chuỗi vừa duyệt, mỗi lần duyệt chuỗi sẽ đếm số lần xuất hiện 
        /// của chuỗi đó trong danh sách tạm (nếu có sẽ gán đuôi là số lần xuất hiện của chuỗi đó)
        /// </summary>
        /// <param name="lst">Danh sach chuoi truyen vao</param>
        /// <returns></returns>
        static List<string> ChuanHoaDSChuoi(List<string> lst)
        {
            int dem = 0;
            string duoi = "@hvitclan.vn";
            List<string> temp = new List<string>();
            for (int i = 0; i < lst.Count; i++)
            {
                lst[i] = ChuanHoaChuoi(lst[i]);
                dem = DemSoLanXuatHien(temp, lst[i]);
                temp.Add(lst[i]);
                if (dem != 0)
                {
                    lst[i] += dem.ToString();
                }
                lst[i] += duoi;
            }
            return lst;
        }

        static void NhapDanhSach(List<string> a)
        {
            Console.Write("Nhap so luong chuoi: ");
            int soLuong = int.Parse(Console.ReadLine());
            for (int i = 0; i < soLuong; i++)
            {
                string str = Console.ReadLine();
                a.Add(str);
            }
        }

        static void InDanhSach(List<string> a)
        {
            a.ForEach(x => Console.WriteLine($"\"{x}\""));
        }

        static void Main(string[] args)
        {
            //List<string> lstName = new List<string> { "Nguyen Van An", "Tran Van Ban", "Tran Van Ban", "Tran Van Ban" };
            List<string> lstName = new List<string>();
            NhapDanhSach(lstName);
            Console.WriteLine("Cac phan tu trong mang:");
            InDanhSach(lstName);

            lstName = ChuanHoaDSChuoi(lstName);
            Console.WriteLine("\nDanh sach sau khi chuan hoa:");
            InDanhSach(lstName);
            Console.ReadKey();
        }
    }
}
