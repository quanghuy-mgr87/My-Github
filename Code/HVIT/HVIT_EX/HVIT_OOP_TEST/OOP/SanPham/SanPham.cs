using System;
using System.Collections.Generic;
using System.Text;

namespace SanPham
{
    class SanPham
    {
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string LoaiSanPham { get; set; }
        public bool LaSanPhamMoi { get; set; }
        public SanPham(int ma, string ten, string loaiSanPham, bool laSPMoi)
            => (MaSanPham, TenSanPham, LoaiSanPham, LaSanPhamMoi) = (ma, ten, loaiSanPham, laSPMoi);
        public void HienThi()
            => Console.WriteLine($"{MaSanPham} san pham {TenSanPham} thuoc loai {LoaiSanPham} {LaSanPhamMoi} la san pham moi");
    }
}
