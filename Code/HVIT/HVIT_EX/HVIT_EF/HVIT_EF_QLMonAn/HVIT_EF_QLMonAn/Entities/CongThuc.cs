using HVIT_EF_QLMonAn.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLMonAn.Entities
{
    class CongThuc
    {
        public int Id { get; set; }
        public int? NguyenLieuId { get; set; }
        public int? MonAnId { get; set; }
        public int? SoLuong { get; set; }
        public string DonViTinh { get; set; }
        public virtual NguyenLieu NguyenLieu { get; set; }
        public virtual MonAn MonAn { get; set; }
        public CongThuc() { }
        public CongThuc(inputType inputType)
        {
            switch (inputType)
            {
                case inputType.ThemCongThucMonAn:
                    {
                        MonAnId = inputHelper.InputInt(res.inputMonAnId, res.errorMonAnId);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
