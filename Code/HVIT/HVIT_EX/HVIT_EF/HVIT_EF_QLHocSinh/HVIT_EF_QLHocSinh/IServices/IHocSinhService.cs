using HVIT_EF_QLHocSinh.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using HVIT_EF_QLHocSinh.Helper;

namespace HVIT_EF_QLHocSinh.IServices
{
    interface IHocSinhService
    {
        public IEnumerable<HocSinh> HienThiDSHocSinh(string keyword = null);
        public HocSinh LayThongTinHsTheoMa(int hocSinhId);
        public errType ThemHocSinhVaoLop(HocSinh hocSinh);
        public errType SuaThongTinHocSinh(HocSinh hocSinh);
        public errType XoaHocSinh(HocSinh hocSinh);
        public errType ChuyenLopChoHocSinh(HocSinh hocSinh);
    }
}
