using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanHang.Entities
{
    public class QuocGia
    {
        public int id { get; set; }
        public string tenQuocGia { get; set; }
        public IEnumerable<HangHoa> hangHoas { get; set; }
        public QuocGia() { }
    }
}
