using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueEnd.Entities;

namespace VueEnd.IService
{
    interface IHocSinhService
    {
        IEnumerable<HocSinh> GetStudentList();
        HocSinh GetStudentListById(int hocSinhId);
        HocSinh AddNewStudent(HocSinh hocSinh);
        HocSinh UpdateStudent(HocSinh hocSinh);
        HocSinh DeleteStudent(int hocSinhId);
    }
}
