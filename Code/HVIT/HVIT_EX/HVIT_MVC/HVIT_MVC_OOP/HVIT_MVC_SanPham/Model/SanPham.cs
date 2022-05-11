using HVIT_MVC_SanPham.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_MVC_SanPham.Model
{
    class SanPham
    {
        public int maSP { get; set; }
        public LoaiSanPham loaiSP { get; set; }
        public NhaCungCap nhaCC { get; set; }
        public string tenSP { get; set; }
        public SanPham()
        {
            maSP = inputHelper.InputInt(res.inputMaSP, res.errorMaSP);
            loaiSP = new LoaiSanPham();
            nhaCC = new NhaCungCap();
            tenSP = inputHelper.InputString(res.inputTenSP, res.errorTenSP);
        }
        public SanPham(LoaiSanPham loaiSanPham)
        {
            this.loaiSP = loaiSanPham;
        }
        public SanPham(NhaCungCap nhaCungCap)
        {
            this.nhaCC = nhaCC;
        }
        public SanPham(SanPham sanPham)
        {
            this.loaiSP = sanPham.loaiSP;
            this.nhaCC = sanPham.nhaCC;
            this.maSP = sanPham.maSP;
            this.tenSP = sanPham.tenSP;
        }
        public void InThongTin()
        {
            Console.WriteLine($"Ma san pham: {maSP}, ten san pham: {tenSP}, loai san pham: {loaiSP.tenLoai}, nha cung cap: {nhaCC.tenNCC}, so dien thoai: {nhaCC.soDT}");
        }
    }
}
