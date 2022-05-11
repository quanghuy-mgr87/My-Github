using HVIT_EF_QLMonAn.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLMonAn.Entities
{
    class LoaiMonAn
    {
        public int Id { get; set; }
        public string TenLoai { get; set; }
        public string MoTa { get; set; }
        public virtual IEnumerable<MonAn> MonAns { get; set; }
        public LoaiMonAn() { }
        public LoaiMonAn(inputType inputType)
        {
            switch (inputType)
            {
                case inputType.XoaLoaiMon:
                    {
                        Id = inputHelper.InputInt(res.inputTenLoai, res.errorTenLoai);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
