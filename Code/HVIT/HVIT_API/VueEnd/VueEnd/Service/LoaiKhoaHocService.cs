using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueEnd.Entities;
using VueEnd.IService;

namespace VueEnd.Service
{
    public class LoaiKhoaHocService : ILoaiKhoaHocService
    {
        private QLHocSinhDbContext dbContext { get; }
        public LoaiKhoaHocService()
        {
            dbContext = new QLHocSinhDbContext();
        }
        public LoaiKhoaHoc CreateTypeOfCourse(LoaiKhoaHoc loaiKhoaHoc)
        {
            var currentCourse = dbContext.LoaiKhoaHocs.SingleOrDefault(x => x.Id == loaiKhoaHoc.Id);
            if (currentCourse != null)
            {
                currentCourse = null;
            }
            else
            {
                dbContext.LoaiKhoaHocs.Add(loaiKhoaHoc);
                currentCourse = loaiKhoaHoc;
                dbContext.SaveChanges();
            }
            return currentCourse;
        }

        public LoaiKhoaHoc DeleteTypeOfCourse(int loaiKhoaHocId)
        {
            var currentCourse = dbContext.LoaiKhoaHocs.SingleOrDefault(x => x.Id == loaiKhoaHocId);
            if (currentCourse != null)
            {
                var lstLop = dbContext.Lops.Where(x => x.LoaiKhoaHocId == loaiKhoaHocId).ToList();
                lstLop.ForEach(x =>
                {
                    x.LoaiKhoaHocId = null;
                    dbContext.Lops.Update(x);
                    dbContext.SaveChanges();
                });
                dbContext.LoaiKhoaHocs.Remove(currentCourse);
                dbContext.SaveChanges();
            }
            return currentCourse;
        }

        public IEnumerable<LoaiKhoaHoc> GetListTypeOfCourse(string keyword)
        {
            var lstKhoaHoc = dbContext.LoaiKhoaHocs.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();
                lstKhoaHoc = lstKhoaHoc.Where(x => x.ChuDe.ToLower() == keyword);
            }
            return lstKhoaHoc;
        }

        public LoaiKhoaHoc UpdateTypeOfCourse(LoaiKhoaHoc loaiKhoaHoc)
        {
            var currentCourse = dbContext.LoaiKhoaHocs.SingleOrDefault(x => x.Id == loaiKhoaHoc.Id);
            if (currentCourse != null)
            {
                currentCourse.ChuDe = loaiKhoaHoc.ChuDe;
                dbContext.LoaiKhoaHocs.Update(currentCourse);
                dbContext.SaveChanges();
            }
            return currentCourse;
        }

        public LoaiKhoaHoc GetTypeOfCourseById(int id)
        {
            var currentCourse = dbContext.LoaiKhoaHocs.Find(id);
            return currentCourse;
        }
    }
}
