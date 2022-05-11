using OOP_NET.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_NET.Model
{
    class MonAn
    {
        public string tenMonAn { get; set; }
        public int giaBan { get; set; }
        public string gioiThieu { get; set; }
        public string nguyenLieuChinh { get; set; }
        public MonAn()
        {
            tenMonAn = inputHelper.InputString(res.inputTenMonAn, res.errorTenMonAn);
            giaBan = inputHelper.InputInt(res.inputGiaBan, res.errorGiaBan);
            gioiThieu = inputHelper.InputString(res.inputGioiThieu, res.errorGioiThieu);
            nguyenLieuChinh = inputHelper.InputString(res.inputNguyenLieuChinh, res.errorNguyenLieuChinh);
        }
        public void InThongTin()
        {
            Console.WriteLine($"Ten mon an: {tenMonAn}, gia ban: {giaBan}, gioi thieu: {gioiThieu}, nguyen lieu chinh: {nguyenLieuChinh}");
        }
    }
}
