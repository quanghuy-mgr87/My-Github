using HVIT_MVC_DonDatHang.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_MVC_DonDatHang.Model
{
    class DonDatHang
    {
        public int maDDH { get; set; }
        public string soHieuDon { get; set; }
        public DateTime ngayTao { get; set; }
        public DonDatHang()
        {
            maDDH = inputHelper.InputInt(res.inputMaDDH, res.errorMaDDH);
            soHieuDon = inputHelper.InputString(res.inputSoHieuDon, res.errorSoHieuDon);
            ngayTao = inputHelper.InputDateTime(res.inputNgayTao, res.errorNgayTao);
        }
        public void InThongTin()
        {
            Console.WriteLine($"Ma don dat hang: {maDDH}, so hieu don: {soHieuDon}, ngay tao: {ngayTao}");
        }
    }
}
