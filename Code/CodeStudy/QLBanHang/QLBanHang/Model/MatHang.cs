using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Model
{
    public class MatHang
    {
        public int MaMatHang { get; set; }
        public string TenMatHang { get; set; }
        public string HangSanXuat { get; set; }
        public string DonViTinh { get; set; }
        public double DonGiaNhap { get; set; }
        public double DonGiaBan { get; set; }
        public int DonViBanId { get; set; }

        public MatHang()
        {
        }

        public MatHang(int maMatHang, string tenMatHang, string hangSanXuat, string donViTinh, double donGiaNhap, double donGiaBan, int donViBanId)
        {
            MaMatHang = maMatHang;
            TenMatHang = tenMatHang;
            HangSanXuat = hangSanXuat;
            DonViTinh = donViTinh;
            DonGiaNhap = donGiaNhap;
            DonGiaBan = donGiaBan;
            DonViBanId = donViBanId;
        }
    }
}
