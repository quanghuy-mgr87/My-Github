using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muc1_4
{
    class HocVien
    {
        private string _HoTen;
        private double _HocPhi;
        public int MaHocVien { get; set; }
        public string HoTen
        {
            get { return _HoTen; }
            set
            {
                _HoTen = value;
                _HoTen = _HoTen.Trim();
                while (_HoTen.Contains("  "))
                {
                    _HoTen = _HoTen.Replace("  ", " ");
                }
                string[] temp = _HoTen.Split(' ');
                Ho = temp[0];
                Email += temp[temp.Length - 1];
                Email += "@edusolution.com";
            }
        }
        public DateTime NgaySinh { get; set; }
        public string Ho { private get; set; }
        public double HocPhi
        {
            get
            {
                if (_HocPhi > 3000000)
                {
                    _HocPhi -= _HocPhi * 0.05;
                }
                return _HocPhi;
            }
            set { _HocPhi = value; }
        }
        public string Email { get; private set; }
        public double DiemThi { get; set; }

        public HocVien()
        {
            Console.Write("Ma hoc vien: ");
            MaHocVien = int.Parse(Console.ReadLine());
            Console.Write("Ho ten: ");
            HoTen = Console.ReadLine();
            Console.Write("Ngay sinh: ");
            NgaySinh = DateTime.Parse(Console.ReadLine());
            Console.Write("Diem thi: ");
            DiemThi = double.Parse(Console.ReadLine());
            Console.Write("Hoc phi: ");
            HocPhi = double.Parse(Console.ReadLine());
        }

        public HocVien(int MaHocVien, string HoTen, DateTime NgaySinh, double DiemThi, double HocPhi)
        {
            this.MaHocVien = MaHocVien;
            this.HoTen = HoTen;
            this.NgaySinh = NgaySinh;
            this.DiemThi = DiemThi;
            this.HocPhi = HocPhi;
        }

        public bool KiemTraTen(string str)
        {
            string temp = HoTen.ToLower();
            if (temp.Contains(str.ToLower()))
            {
                return true;
            }
            return false;
        }

        public void HienThi()
        {
            Console.WriteLine($"{MaHocVien} co ten {HoTen} co email {Email}, hoc phi {HocPhi}");
        }
    }
}
