using HVIT_MVCTest.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HVIT_MVCTest.Model
{
    [Table("PhanCong")]
    class PhanCong
    {
        [Key]
        public int PhancongId { get; set; }
        public int NhanvienId { get; set; }
        public int DuanId { get; set; }
        public int Sogiolam { get; set; }
        [ForeignKey("NhanvienId")]
        NhanVien nhanVien { get; set; }
        [ForeignKey("DuanId")]
        DuAn duAn { get; set; }
        public PhanCong()
        {

        }
        public PhanCong(inputType inputType)
        {
            if (inputType == inputType.ThemNhanVienVaoDuAn)
            {
                NhanvienId = inputHelper.InputInt("Ma nhan vien: ", "Loi!");
                DuanId = inputHelper.InputInt("Ma du an: ", "Loi!");
                Sogiolam = inputHelper.InputInt("So gio lam: ", "Loi!");
            }
        }
    }
}
