using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyPhongBan.Entities
{
    public class PhongBan
    {
        public int Id { get; set; }
        public string TenPhongBan { get; set; }
        public virtual IEnumerable<NhanVien> nhanViens { get; set; }
    }
}
