using HVIT_EF_QLHocSinh.Entities;
using HVIT_EF_QLHocSinh.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_EF_QLHocSinh.IServices
{
    interface ILopService
    {
        public IEnumerable<Lop> HienThiDSLop(string keyword = null);
    }
}
