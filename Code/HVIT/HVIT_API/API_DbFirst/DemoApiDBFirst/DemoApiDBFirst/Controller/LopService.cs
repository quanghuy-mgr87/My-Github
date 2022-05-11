using DemoApiDBFirst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApiDBFirst.Controller
{
    public class LopService
    {
        //hỗ trợ thực hiện truy vấn dữ liệu
        private QLHocSinhDBFirstContext dbContext = new QLHocSinhDBFirstContext();
        public List<Lop> LayDSLop()
        {
            //truy vấn và trả về toàn bộ dữ liệu trong bảng Lop
            return dbContext.Lops.ToList();
        }

        public bool ThemLop(Lop newLop)
        {
            Lop lop = dbContext.Lops.SingleOrDefault(x => x.TenLop.ToLower() == newLop.TenLop.ToLower());
            if (lop != null)
            {
                return false;
            }
            else
            {
                dbContext.Lops.Add(newLop); //thực hiện insert dữ liệu
                dbContext.SaveChanges();    //lưu dữ liệu vào database
                return true;
            }
        }

        public bool SuaLop(Lop lop)
        {
            //lấy lớp cần sửa từ DB lên
            Lop currentLop = dbContext.Lops.SingleOrDefault(x => x.LopId == lop.LopId);
            if (currentLop == null)
            {
                return false;
            }
            else
            {
                //cập nhật thông tin mới cho currentLop vừa tìm được
                currentLop.TenLop = lop.TenLop;
                currentLop.SiSo = lop.SiSo;
                //cập nhật dữ liệu vào lại cho DB
                dbContext.Lops.Update(currentLop);
                dbContext.SaveChanges();
                return true;
            }
        }

        public bool XoaLop(int lopId)
        {
            Lop currentLop = dbContext.Lops.SingleOrDefault(x => x.LopId == lopId);
            HocSinh hocSinh = dbContext.HocSinhs.SingleOrDefault(x => x.LopId == lopId);
            if (currentLop == null)
            {
                return false;
            }
            else if (hocSinh != null)
            {
                //Lấy danh sách học sinh lên
                List<HocSinh> lstHocSinh = dbContext.HocSinhs.ToList();

                //Duyệt trong danh sách học sinh, nếu có học sinh nào có mã lớp giống như mã lớp định xoá thì xoá học sinh đó đi
                for (int i = 0; i < lstHocSinh.Count; i++)
                {
                    if (lstHocSinh[i].LopId == lopId)
                    {
                        dbContext.HocSinhs.Remove(lstHocSinh[i]);
                        dbContext.SaveChanges();
                    }
                }
            }

            //Xoá dữ liệu
            dbContext.Lops.Remove(currentLop);
            dbContext.SaveChanges();
            return true;
        }
    }
}
