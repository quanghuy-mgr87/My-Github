using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn.Entities
{
    class Kho
    {
        public int id { get; set; }
        public string tenKho { get; set; }
        public virtual IEnumerable<ChiTietKho> ChiTietKhos { get; set; }
    }
}
