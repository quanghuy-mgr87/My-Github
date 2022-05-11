using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueEnd.Entities
{
    public class HocSinh
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public int? LopId { get; set; }
        public string QueQuan { get; set; }
        public string GioiTinh { get; set; }
        public virtual Lop Lop { get; set; }
        public HocSinh() { }
    }
}
