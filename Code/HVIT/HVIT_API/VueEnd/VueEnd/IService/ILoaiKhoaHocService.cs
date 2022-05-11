using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueEnd.Entities;

namespace VueEnd.IService
{
    interface ILoaiKhoaHocService
    {
        public IEnumerable<LoaiKhoaHoc> GetListTypeOfCourse(string keyword);
        public LoaiKhoaHoc GetTypeOfCourseById(int id);
        public LoaiKhoaHoc CreateTypeOfCourse(LoaiKhoaHoc loaiKhoaHoc);
        public LoaiKhoaHoc DeleteTypeOfCourse(int loaiKhoaHocId);
        public LoaiKhoaHoc UpdateTypeOfCourse(LoaiKhoaHoc loaiKhoaHoc);
    }
}
