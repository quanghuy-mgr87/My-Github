using HVIT_EF_QLNgayHoc.Entities;
using HVIT_EF_QLNgayHoc.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLNgayHoc.IServices
{
    interface IHocVienService
    {
        public errType ThemHocVien(HocVien hocVien);
        public errType SuaThongTinHocVien(HocVien hocVien);
        public errType TimHocVien(HocVien hocVien);
    }
}
