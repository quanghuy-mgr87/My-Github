using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn.Entities
{
    class TinhTrangHang
    {
        public int id { get; set; }
        public string tenTinhTrang { get; set; }
        public virtual IEnumerable<ChiTietKho> ChiTietKhos { get; set; }
    }
}
