using HVIT_MVC_SanPham.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_MVC_SanPham.Model
{
    class LoaiSanPham
    {
        public int loaiSP { get; set; }
        public string tenLoai { get; set; }
        public LoaiSanPham()
        {
            loaiSP = inputHelper.InputInt(res.inputLoaiSP, res.errorLoaiSP);
            tenLoai = inputHelper.InputString(res.inputTenLoai, res.errorTenLoai);
        }
        public void InThongTin()
        {
            Console.WriteLine($"Loai san pham: {loaiSP}, ten loai: {tenLoai}");
        }
    }
}
