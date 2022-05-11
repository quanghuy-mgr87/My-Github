using System;
using System.Collections.Generic;
using System.Text;

namespace HocSinhDB.Entities
{
    public class QuanLyHS
    {
        public int Id { get; set; }
        public int HocSinhId { get; set; }
        public int MonHocId { get; set; }
        public float DiemPhay { get; set; }
        public virtual IEnumerable<HocSinh> DSHocSinh { get; set; }
        public virtual IEnumerable<MonHoc> DSMonHoc { get; set; }
    }
}
