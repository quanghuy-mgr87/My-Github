using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueEnd.Entities
{
    public class Lop
    {
        public int Id { get; set; }
        public string TenLop { get; set; }
        public string LinkAnh { get; set; }
        public string HinhThuc { get; set; }
        public int? Gia { get; set; }
        public int? KhuyenMai { get; set; }
        public int? SiSo { get; set; }
        public int? LoaiKhoaHocId { get; set; }
        public virtual IEnumerable<HocSinh> HocSinhs { get; set; }
        public virtual LoaiKhoaHoc LoaiKhoaHoc { get; set; }
        public Lop() { }
    }
}
