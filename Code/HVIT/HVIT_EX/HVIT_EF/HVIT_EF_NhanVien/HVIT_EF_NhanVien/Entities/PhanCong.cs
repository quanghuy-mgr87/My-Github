using HVIT_EF_NhanVien.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_NhanVien.Entities
{
    class PhanCong
    {
        public int Id { get; set; }
        public int? nhanVienId { get; set; }
        public int? duAnId { get; set; }
        public int? soGioLam { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual DuAn DuAn { get; set; }
        public PhanCong() { }
        public PhanCong(inputType inputType)
        {
            if (inputType == inputType.ThemNhanVienVaoDuAn)
            {
                nhanVienId = inputHelper.InputInt(res.inputNhanVienId, res.errorNhanVienId);
                duAnId = inputHelper.InputInt(res.inputDuAnId, res.errorDuAnId);
                soGioLam = inputHelper.InputInt(res.inputSoGioLam, res.errorSoGioLam, 0);
            }
        }
    }
}
