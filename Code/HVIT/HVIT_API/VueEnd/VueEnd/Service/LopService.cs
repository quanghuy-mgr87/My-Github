using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueEnd.Entities;
using VueEnd.IService;

namespace VueEnd.Service
{
    public class LopService : ILopService
    {
        private QLHocSinhDbContext dbContext { get; }
        public LopService()
        {
            dbContext = new QLHocSinhDbContext();
        }

        public IEnumerable<Lop> GetClassList()
        {
            var lstClass = dbContext.Lops.Include(x => x.LoaiKhoaHoc).AsQueryable();
            foreach (var val in lstClass)
            {
                if (val.SiSo == null)
                    val.SiSo = 0;
            }
            return lstClass;
        }

        public Lop GetClassById(int classId)
        {
            var currentClass = dbContext.Lops.Find(classId);
            return currentClass;
        }

        public Lop AddNewClass(Lop lop)
        {
            dbContext.Lops.Add(lop);
            dbContext.SaveChanges();
            return lop;
        }

        public Lop UpdateClass(Lop lop)
        {
            var currentClass = dbContext.Lops.Find(lop.Id);
            if (currentClass != null)
            {
                currentClass.TenLop = lop.TenLop;
                currentClass.LinkAnh = lop.LinkAnh;
                currentClass.HinhThuc = lop.HinhThuc;
                currentClass.Gia = lop.Gia;
                currentClass.SiSo = lop.SiSo;
                currentClass.HinhThuc = lop.HinhThuc;
                currentClass.KhuyenMai = lop.KhuyenMai;
                currentClass.LoaiKhoaHocId = lop.LoaiKhoaHocId;
                dbContext.Lops.Update(currentClass);
                dbContext.SaveChanges();
            }
            return currentClass;
        }

        public Lop DeleteClass(int classId)
        {
            var currentClass = dbContext.Lops.Find(classId);
            if (currentClass != null)
            {
                var lstHocSinh = dbContext.HocSinhs.Where(x => x.LopId == classId).ToList();
                lstHocSinh.ForEach(x =>
                {
                    x.LopId = null;
                    dbContext.HocSinhs.Update(x);
                    dbContext.SaveChanges();
                });
                dbContext.Lops.Remove(currentClass);
                dbContext.SaveChanges();
            }
            return currentClass;
        }

        public IEnumerable<Lop> SearchClass(string keyword)
        {
            var lstClass = dbContext.Lops.AsQueryable();
            keyword = keyword.ToLower();
            if (!string.IsNullOrEmpty(keyword))
            {
                lstClass = lstClass.Where(x => x.TenLop.ToLower().Contains(keyword));
            }
            foreach (var val in lstClass)
            {
                if (val.SiSo == null)
                    val.SiSo = 0;
            }
            return lstClass;
        }
    }
}
