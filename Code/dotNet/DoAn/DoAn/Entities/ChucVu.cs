using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn.Entities
{
    class ChucVu
    {
        public int id { get; set; }
        public string tenChucVu { get; set; }
        public virtual IEnumerable<NhanVien> NhanViens { get; set; }
    }
}
