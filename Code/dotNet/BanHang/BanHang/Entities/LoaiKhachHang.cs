using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanHang.Entities
{
    public class LoaiKhachHang
    {
        public int id { get; set; }
        public string tenLoai { get; set; }
        public IEnumerable<KhachHang> khachHangs { get; set; }
        LoaiKhachHang() { }
    }
}
