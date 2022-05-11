using HVIT_EF_QLNgayHoc.Entities;
using HVIT_EF_QLNgayHoc.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLNgayHoc.IServices
{
    interface IKhoaHocService
    {
        public errType XoaKhoaHoc(KhoaHoc khoaHoc);
        public errType TinhDoanhThu();
        public errType TinhDoanhThuTheoNam();
        public errType ThemNgayChoKhoaHoc(KhoaHoc khoaHoc);
    }
}
