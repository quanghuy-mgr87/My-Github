using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace HVITQuanLyHS
{
    public class Helper
    {
        /// <summary>
        /// Hàm nhập họ tên
        /// </summary>
        /// <param name="msg">Thông điệp</param>
        /// <param name="err">Thông điệp lỗi</param>
        /// <param name="gioiHanKyTu">Số lượng kí tự tối đa</param>
        /// <returns>Họ tên</returns>
        public static string NhapHoTen(string msg, string err, int gioiHanKyTu = int.MaxValue)
        {
            string str;
            bool check;
            do
            {
                Console.Write(msg);
                str = Console.ReadLine();
                str = str.Trim();
                check = str.Length <= gioiHanKyTu && str.Contains(" ");
                if (!check)
                {
                    Console.WriteLine(err);
                }
            } while (!check);
            while (str.Contains("  "))
            {
                str = str.Replace("  ", " ");
            }
            return str;
        }

        /// <summary>
        /// Hàm nhập tên lớp
        /// </summary>
        /// <param name="msg">Thông điệp</param>
        /// <param name="err">Thông điệp lỗi</param>
        /// <param name="gioiHanKyTu">Số lượng ký tự tối đa</param>
        /// <returns>Tên lớp</returns>
        public static string NhapTenLop(string msg, string err, int gioiHanKyTu = int.MaxValue)
        {
            string str;
            bool check;
            do
            {
                Console.Write(msg);
                str = Console.ReadLine();

                check = str.Length <= gioiHanKyTu;
                if (!check)
                {
                    Console.WriteLine(err);
                }
            } while (!check);
            return str;
        }

        /// <summary>
        /// Hàm kiểm tra tính hợp lệ của ngày sinh
        /// </summary>
        /// <param name="ngaySinh">Ngày sinh của học sinh</param>
        /// <param name="msg">Thông điệp</param>
        /// <param name="err">Thông điệp lỗi</param>
        /// <param name="min">Năm nhỏ nhất</param>
        /// <param name="max">Năm lớn nhất</param>
        /// <returns></returns>
        public static DateTime NhapNgaySinh(string msg, string err, int min, int max)
        {
            DateTime ngaySinh;
            bool check;
            do
            {
                Console.Write(msg);
                ngaySinh = DateTime.Parse(Console.ReadLine());
                check = ngaySinh.Year >= min && ngaySinh.Year <= max;
                if (!check)
                {
                    Console.WriteLine(err);
                }
            } while (!check);
            return ngaySinh;
        }
    }
}
