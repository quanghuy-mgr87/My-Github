using HVIT_EF_QLMonAn.Entities;
using HVIT_EF_QLMonAn.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLMonAn.IServices
{
    interface ILoaiMonService
    {
        public errType XoaLoaiMon(LoaiMonAn loaiMonAn);
    }
}
