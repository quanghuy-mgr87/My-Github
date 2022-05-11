using HVIT_EF_QLHocSinh.Entities;
using HVIT_EF_QLHocSinh.Helper;
using HVIT_EF_QLHocSinh.IServices;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVIT_EF_QLHocSinh.Service
{
    class HocSinhService : IHocSinhService
    {
        private QLHocSinhDbContext dbContext { get; }
        public HocSinhService()
        {
            dbContext = new QLHocSinhDbContext();
        }
        public void CapNhatSiSo(int lopId)
        {
            var lop = dbContext.lops.Find(lopId);
            //lấy danh sách các học sinh có mã lớp giống với lopId
            lop.SiSo = dbContext.hocSinhs.Where(x => x.LopId == lopId).ToList().Count();
            dbContext.Update(lop);
            dbContext.SaveChanges();
        }
        public errType ChuyenLopChoHocSinh(HocSinh hocSinh)
        {
            if (dbContext.hocSinhs.Any(x => x.Id == hocSinh.Id))
            {
                if (dbContext.lops.Any(x => x.Id == hocSinh.LopId))
                {
                    var checkLop = dbContext.lops.Find(hocSinh.LopId);
                    if (checkLop.SiSo >= 20)
                    {
                        return errType.LopDaDay;
                    }

                    var currentHS = dbContext.hocSinhs.Find(hocSinh.Id);
                    //lấy lớp cũ
                    var oldLop = dbContext.lops.Find(currentHS.LopId);
                    //cập nhật lớp mới cho học sinh
                    currentHS.LopId = hocSinh.LopId;
                    dbContext.hocSinhs.Update(currentHS);
                    dbContext.SaveChanges();
                    //cập nhật sĩ số lớp cũ
                    CapNhatSiSo(oldLop.Id);
                    //lấy lớp mới
                    var newLop = dbContext.lops.Find(currentHS.LopId);
                    //cập nhật sĩ số lớp mới
                    CapNhatSiSo(newLop.Id);

                    return errType.ThanhCong;
                }
                else
                {
                    return errType.LopKhongTonTai;
                }
            }
            else
            {
                return errType.HocSinhKhongTonTai;
            }
        }

        public IEnumerable<HocSinh> HienThiDSHocSinh(string keyword = null)
        {
            var query = dbContext.hocSinhs.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.HoTen.Contains(keyword));
            }
            return query;
        }

        public HocSinh LayThongTinHsTheoMa(int hocSinhId)
        {
            HocSinh hocSinh = dbContext.hocSinhs.Find(hocSinhId);
            return hocSinh;
        }

        public errType SuaThongTinHocSinh(HocSinh hocSinh)
        {
            if (dbContext.hocSinhs.Any(x => x.Id == hocSinh.Id))
            {
                var currentHs = LayThongTinHsTheoMa(hocSinh.Id);
                currentHs.HoTen = hocSinh.HoTen;
                currentHs.NgaySinh = hocSinh.NgaySinh;
                currentHs.QueQuan = hocSinh.QueQuan;
                dbContext.hocSinhs.Update(currentHs);
                dbContext.SaveChanges();
                return errType.ThanhCong;
            }
            else
            {
                return errType.HocSinhKhongTonTai;
            }
        }

        public errType ThemHocSinhVaoLop(HocSinh hocSinh)
        {
            if (dbContext.lops.Any(x => x.Id == hocSinh.LopId))
            {
                if (dbContext.hocSinhs.Any(x => x.Id == hocSinh.Id))
                {
                    return errType.HocSinhDaTonTai;
                }
                else
                {
                    var checkLop = dbContext.lops.Find(hocSinh.LopId);
                    if (checkLop.SiSo >= 20)
                    {
                        return errType.LopDaDay;
                    }

                    hocSinh.Id = 0;
                    dbContext.hocSinhs.Add(hocSinh);
                    dbContext.SaveChanges();

                    var lop = dbContext.lops.Find(hocSinh.LopId);
                    CapNhatSiSo(lop.Id);

                    return errType.ThanhCong;
                }
            }
            else
            {
                return errType.LopKhongTonTai;
            }
        }

        public errType XoaHocSinh(HocSinh hocSinh)
        {
            if (dbContext.hocSinhs.Any(x => x.Id == hocSinh.Id))
            {
                var currentHS = dbContext.hocSinhs.Find(hocSinh.Id);
                var lop = dbContext.lops.Find(currentHS.LopId);

                dbContext.hocSinhs.Remove(currentHS);
                dbContext.SaveChanges();

                CapNhatSiSo(lop.Id);

                return errType.ThanhCong;
            }
            else
            {
                return errType.HocSinhKhongTonTai;
            }
        }
    }
}
