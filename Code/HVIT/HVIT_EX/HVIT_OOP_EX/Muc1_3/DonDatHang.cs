using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muc1_3
{
    class DonDatHang
    {
        private double _ThanhTien;
        public int MaSoDon { get; set; }
        public DateTime NgayDat { get; set; }
        public string TenSanPham { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien
        {
            get
            {
                _ThanhTien = DonGia * SoLuong;
                return _ThanhTien;
            }
            private set
            {
                _ThanhTien = value;
            }
        }
        public string GhiChu { get; set; }

        public DonDatHang()
        {
            Console.Write("Ma so don: ");
            MaSoDon = int.Parse(Console.ReadLine());
            Console.Write("Ngay dat: ");
            NgayDat = DateTime.Parse(Console.ReadLine());
            Console.Write("Ten san pham: ");
            TenSanPham = Console.ReadLine();
            Console.Write("Don gia: ");
            DonGia = double.Parse(Console.ReadLine());
            Console.Write("So luong: ");
            SoLuong = int.Parse(Console.ReadLine());
            Console.Write("Ghi chu: ");
            GhiChu = Console.ReadLine();
        }

        public DonDatHang(int MaSoDon, DateTime NgayDat, string TenSanPham, double DonGia, int SoLuong)
        {
            this.MaSoDon = MaSoDon;
            this.NgayDat = NgayDat;
            this.TenSanPham = TenSanPham;
            this.DonGia = DonGia;
            this.SoLuong = SoLuong;
        }

        public void HienThi()
        {
            Console.WriteLine($"Don hang co ma so {MaSoDon}, dat ngay {NgayDat.ToShortDateString()}, co tong tien la {ThanhTien}.");
            Console.WriteLine($"Don gia: {DonGia}, So luong: {SoLuong}");
        }
    }
}
