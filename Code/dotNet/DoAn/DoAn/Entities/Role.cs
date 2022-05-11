using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn.Entities
{
    class Role
    {
        public int id { get; set; }
        public string quyenHan { get; set; }
        public virtual IEnumerable<User> Users { get; set; }
    }
}
