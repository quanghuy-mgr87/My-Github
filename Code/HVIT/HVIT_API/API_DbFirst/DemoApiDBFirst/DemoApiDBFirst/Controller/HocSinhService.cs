using DemoApiDBFirst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApiDBFirst.Controller
{
    public class HocSinhService
    {
        //hỗ trợ thực hiện truy vấn dữ liệu
        private QLHocSinhDBFirstContext dbContext = new QLHocSinhDBFirstContext();

        public List<HocSinh> LayDSHocSinh()
        {
            return dbContext.HocSinhs.ToList();
        }

        public bool ThemHocSinh(HocSinh newHocSinh)
        {
            Lop currentLop = dbContext.Lops.SingleOrDefault(x => x.LopId == newHocSinh.LopId);
            if(currentLop == null)
            {
                return false;
            }
            else
            {
                dbContext.HocSinhs.Add(newHocSinh);
                dbContext.SaveChanges();
                return true;
            }
        }

        public bool SuaHocSinh(HocSinh hocSinh)
        {
            HocSinh currentHocSinh = dbContext.HocSinhs.SingleOrDefault(x => x.HocSinhId == hocSinh.HocSinhId);
            Lop currentLop = dbContext.Lops.SingleOrDefault(x => x.LopId == hocSinh.LopId);
            if (currentHocSinh == null || currentLop == null)
                return false;
            else
            {
                currentHocSinh.HoTen = hocSinh.HoTen;
                currentHocSinh.NgaySinh = hocSinh.NgaySinh;
                currentHocSinh.GioiTinh = hocSinh.GioiTinh;
                dbContext.HocSinhs.Update(currentHocSinh);
                dbContext.SaveChanges();
                return true;
            }
        }

        public bool XoaHocSinh(int hocSinhId)
        {
            HocSinh currentHocSinh = dbContext.HocSinhs.SingleOrDefault(x => x.HocSinhId == hocSinhId);
            if (currentHocSinh == null)
                return false;
            else
            {
                dbContext.HocSinhs.Remove(currentHocSinh);
                dbContext.SaveChanges();
                return true;
            }
        }
    }
}
