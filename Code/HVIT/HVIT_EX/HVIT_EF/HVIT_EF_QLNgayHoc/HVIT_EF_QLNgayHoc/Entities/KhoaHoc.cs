using HVIT_EF_QLNgayHoc.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLNgayHoc.Entities
{
    class KhoaHoc
    {
        public int Id { get; set; }
        public string tenKhoaHoc { get; set; }
        public string moTa { get; set; }
        public int? hocPhi { get; set; }
        public DateTime ngayBatDau { get; set; }
        public DateTime ngayKetThuc { get; set; }
        public virtual IEnumerable<HocVien> HocViens { get; set; }
        public KhoaHoc() { }
        public KhoaHoc(inputType inputType)
        {
            switch (inputType)
            {
                case inputType.XoaKhoaHoc:
                    {
                        Id = inputHelper.InputInt(res.inputMaKhoaHoc, res.errorMaKhoaHoc);
                    }
                    break;
                case inputType.TinhDoanhThu:
                    {

                    }
                    break;
                case inputType.ThemNgayHocVaoKhoaHoc:
                    {
                        Id = inputHelper.InputInt(res.inputMaKhoaHoc, res.errorMaKhoaHoc);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
