using HVIT_MVC_DonDatHang.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_MVC_DonDatHang.Model
{
    class ChiTietDonDatHang
    {
        public int id { get; set; }
        public int maDDH { get; set; }
        public int maSP { get; set; }
        public int soLuong { get; set; }
        public ChiTietDonDatHang()
        {
            id = inputHelper.InputInt(res.inputId, res.errorId);
            maDDH = inputHelper.InputInt(res.inputMaDDH, res.errorMaDDH);
            maSP = inputHelper.InputInt(res.inputMaSP, res.errorMaSP);
            soLuong = inputHelper.InputInt(res.inputSoLuong, res.errorSoLuong);
        }
        public void InThongTin()
        {
            Console.WriteLine($"ID: {id}, ma don dat hang: {maDDH}, ma san pham: {maSP}, so luong: {soLuong}");
        }
    }
}
