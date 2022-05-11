using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn.Entities
{
    class PhongBan
    {
        public int id { get; set; }
        public string tenPhongBan { get; set; }
        public int? soNhanVien { get; set; }
        public virtual IEnumerable<NhanVien> NhanViens { get; set; }
    }
}
