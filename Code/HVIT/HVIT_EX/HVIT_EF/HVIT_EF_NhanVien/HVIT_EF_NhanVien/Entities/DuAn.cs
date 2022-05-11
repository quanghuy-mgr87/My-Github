using HVIT_EF_NhanVien.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_NhanVien.Entities
{
    class DuAn
    {
        public int Id { get; set; }
        public string tenDuAn { get; set; }
        public string moTa { get; set; }
        public string ghiChu { get; set; }
        public virtual IEnumerable<PhanCong> phanCongs { get; set; }
        public DuAn() { }
        public DuAn(inputType inputType)
        {
            if (inputType == inputType.SuaDuAn)
            {
                Console.WriteLine("Sua du an: ");
                Id = inputHelper.InputInt(res.inputDuAnId, res.errorDuAnId);
            }
        }
    }
}
