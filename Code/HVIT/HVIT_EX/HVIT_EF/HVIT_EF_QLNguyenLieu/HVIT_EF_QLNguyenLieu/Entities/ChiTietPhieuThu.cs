using HVIT_EF_QLNguyenLieu.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLNguyenLieu.Entities
{
    class ChiTietPhieuThu
    {
        public int Id { get; set; }
        public int? NguyenLieuId { get; set; }
        public int? PhieuThuId { get; set; }
        public int? SoLuongBan { get; set; }
        public virtual PhieuThu PhieuThu { get; set; }
        public virtual NguyenLieu NguyenLieu { get; set; }
        public ChiTietPhieuThu() { }
        public ChiTietPhieuThu(inputType inputType)
        {
            switch (inputType)
            {
                case inputType.ThemChiTietPhieuThu:
                    {
                        PhieuThuId = inputHelper.InputInt(res.inputMaPhieuThu, res.errorMaPhieuThu);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
