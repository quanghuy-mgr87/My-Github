using HVIT_EF_QLHocSinh.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLHocSinh.Entities
{
    class HocSinh
    {
        public int Id { get; set; }
        public int LopId { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string QueQuan { get; set; }
        public virtual Lop Lop { get; set; }
        public HocSinh() { }
        public HocSinh(inputType inputType)
        {
            switch (inputType)
            {
                case inputType.ThemHocSinhVaoLop:
                    {
                        LopId = inputHelper.InputInt(res.inputLopId, res.errorLopId);
                        HoTen = inputHelper.NhapTen(res.inputHoTen, res.errorHoTen);
                        NgaySinh = inputHelper.NhapNgaySinh(res.inputNgaySinh, res.errorNgaySinh);
                        QueQuan = inputHelper.InputString(res.inputQueQuan, res.errorQueQuan);
                    }
                    break;
                case inputType.SuaThongTinHocSinh:
                    {
                        Id = inputHelper.InputInt(res.inputHocSinhId, res.errorHocSinhId);
                        HoTen = inputHelper.NhapTen(res.inputHoTen, res.errorHoTen);
                        NgaySinh = inputHelper.NhapNgaySinh(res.inputNgaySinh, res.errorNgaySinh);
                        QueQuan = inputHelper.InputString(res.inputQueQuan, res.errorQueQuan);
                    }
                    break;
                case inputType.XoaHocSinh:
                    {
                        Id = inputHelper.InputInt(res.inputHocSinhId, res.errorHocSinhId);
                    }
                    break;
                case inputType.ChuyenLopHocSinh:
                    {
                        Id = inputHelper.InputInt(res.inputHocSinhId, res.errorHocSinhId);
                        LopId = inputHelper.InputInt(res.inputLopId, res.errorLopId);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
