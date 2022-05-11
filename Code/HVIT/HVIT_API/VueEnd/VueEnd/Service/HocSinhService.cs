using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueEnd.Entities;
using VueEnd.IService;

namespace VueEnd.Service
{
    public class HocSinhService : IHocSinhService
    {
        private QLHocSinhDbContext dbContext { get; }
        public HocSinhService()
        {
            dbContext = new QLHocSinhDbContext();
        }
        public void CapNhatSiSoChoLop(int lopId)
        {
            int number = dbContext.HocSinhs.Where(x => x.LopId == lopId).ToList().Count;
            var currentLop = dbContext.Lops.Find(lopId);
            currentLop.SiSo = number;
            dbContext.Lops.Update(currentLop);
            dbContext.SaveChanges();
        }
        public void CapNhatSiSo()
        {
            LopService LopService = new LopService();
            var lstLop = LopService.GetClassList().ToList();
            lstLop.ForEach(x =>
            {
                CapNhatSiSoChoLop(x.Id);
            });
        }
        public HocSinh AddNewStudent(HocSinh hocSinh)
        {
            dbContext.HocSinhs.Add(hocSinh);
            dbContext.SaveChanges();
            CapNhatSiSo();
            return hocSinh;
        }
        public HocSinh DeleteStudent(int hocSinhId)
        {
            var currentHocSinh = dbContext.HocSinhs.Find(hocSinhId);
            if (currentHocSinh != null)
            {
                dbContext.HocSinhs.Remove(currentHocSinh);
                dbContext.SaveChanges();
                CapNhatSiSo();
            }
            return currentHocSinh;
        }

        public IEnumerable<HocSinh> GetStudentList()
        {
            //var studentList = dbContext.HocSinhs.AsQueryable();
            var studentList = dbContext.HocSinhs.Include(x => x.Lop).AsQueryable();
            return studentList;
        }

        public HocSinh GetStudentListById(int hocSinhId)
        {
            var student = dbContext.HocSinhs.Find(hocSinhId);
            return student;
        }

        public HocSinh UpdateStudent(HocSinh hocSinh)
        {
            var currentHocSinh = dbContext.HocSinhs.Find(hocSinh.Id);
            if (currentHocSinh != null)
            {
                currentHocSinh.HoTen = hocSinh.HoTen;
                currentHocSinh.NgaySinh = hocSinh.NgaySinh;
                currentHocSinh.QueQuan = hocSinh.QueQuan;
                currentHocSinh.LopId = hocSinh.LopId;
                currentHocSinh.GioiTinh = hocSinh.GioiTinh;
                dbContext.HocSinhs.Update(currentHocSinh);
                dbContext.SaveChanges();
                CapNhatSiSo();
            }
            return currentHocSinh;
        }
    }
}
