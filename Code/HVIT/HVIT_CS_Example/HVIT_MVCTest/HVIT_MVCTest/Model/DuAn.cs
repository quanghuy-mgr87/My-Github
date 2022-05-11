using HVIT_MVCTest.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HVIT_MVCTest.Model
{
    [Table("DuAn")]
    class DuAn
    {
        private inputType suaDuAn;

        [Key]
        public int DuanId { get; set; }
        [StringLength(10)]  //giới hạn ký tự cho TenDuAn
        public string Tenduan { get; set; }
        [StringLength(10)]
        public string Mota { get; set; }
        [StringLength(10)]
        public string Ghichu { get; set; }
        [InverseProperty("DuAn")]
        List<PhanCong> phanCongs { get; set; }
        public DuAn()
        {

        }
        public DuAn(inputType inputType)
        {
            if (inputType == inputType.SuaDuAn)
            {
                Console.WriteLine("Sua du an: ");
                DuanId = inputHelper.InputInt("Ma du an: ", "Loi!");
                Tenduan = inputHelper.InputString("Ten du an: ", "Loi!", 0, 10);
                Mota = inputHelper.InputString("Mo ta: ", "Loi!", 0, 10);
                Ghichu = inputHelper.InputString("Ghi chu: ", "Loi!", 0, 10);
            }
        }
    }
}
