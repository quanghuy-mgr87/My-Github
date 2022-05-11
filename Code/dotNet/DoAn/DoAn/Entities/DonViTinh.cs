using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn.Entities
{
    class DonViTinh
    {
        public int id { get; set; }
        public string donViTinh { get; set; }
        public string moTa { get; set; }
        public virtual IEnumerable<HangHoa> HangHoas { get; set; }
    }
}
