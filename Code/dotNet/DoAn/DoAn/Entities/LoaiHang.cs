using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn.Entities
{
    class LoaiHang
    {
        public int id { get; set; }
        public string tenLoai { get; set; }
        public string moTa { get; set; }
        public virtual IEnumerable<HangHoa> HangHoas { get; set; }
    }
}
