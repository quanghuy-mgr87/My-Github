using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn.Entities
{
    class NhaCungCap
    {
        public int id { get; set; }
        public string tenNhaCungCap { get; set; }
        public string diaChi { get; set; }
        public string soDienThoai { get; set; }
        public virtual IEnumerable<HoaDonMua> HoaDonMuas { get; set; }
    }
}
