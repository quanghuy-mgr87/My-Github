using HVIT_EF_NhanVien.Entities;
using HVIT_EF_NhanVien.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_NhanVien.IService
{
    interface IPhanCongService
    {
        public errType ThemNhanVienVaoDuAn(PhanCong phanCong);
    }
}
