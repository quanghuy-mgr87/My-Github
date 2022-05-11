using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueEnd.Entities
{
    public class LoaiKhoaHoc
    {
        public int Id { get; set; }
        public string ChuDe { get; set; }
        public virtual IEnumerable<Lop> Lops { get; set; }
    }
}
