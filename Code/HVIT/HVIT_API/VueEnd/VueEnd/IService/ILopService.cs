using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueEnd.Entities;

namespace VueEnd.IService
{
    interface ILopService
    {
        public IEnumerable<Lop> GetClassList();
        public Lop GetClassById(int classId);
        public IEnumerable<Lop> SearchClass(string keyword);
        public Lop AddNewClass(Lop lop);
        public Lop UpdateClass(Lop lop);
        public Lop DeleteClass(int classId);
    }
}
