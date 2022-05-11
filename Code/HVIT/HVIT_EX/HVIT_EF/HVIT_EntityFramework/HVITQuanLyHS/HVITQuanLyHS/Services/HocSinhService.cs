using HVITQuanLyHS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVITQuanLyHS.Services
{
    class HocSinhService : IHocSinhService
    {
        private QLHSDbContext qLHSDbContext { get; }
        /// <summary>
        /// Hàm khởi tạo không tham số, khi ct chạy sẽ khởi tạo 1 đối tượng QLHSDbContext
        /// </summary>
        public HocSinhService()
        {
            qLHSDbContext = new QLHSDbContext();
        }

        public void ChuyenLopHocSinh(int hocSinhId, int idLop)
        {
            if (qLHSDbContext.HocSinh.Any(hocSinh => hocSinh.Id == hocSinhId))
            {
                if (qLHSDbContext.Lop.Any(lop => lop.Id == idLop))
                {
                    var currentHocSinh = LayHocSinhTheoMa(hocSinhId);
                    currentHocSinh.LopId = idLop;
                    qLHSDbContext.HocSinh.Update(currentHocSinh);
                    qLHSDbContext.SaveChanges();
                }
                else
                {
                    throw new Exception($"Lop {idLop} khong ton tai!");
                }
            }
            else
            {
                throw new Exception($"Hoc sinh {hocSinhId} khong ton tai!");
            }
        }

        public IEnumerable<HocSinh> LayDanhSachHS(string keyword = null, int maLop = int.MinValue)
        {
            var query = qLHSDbContext.HocSinh.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();
                query = query.Where(hocSinh => (hocSinh.HoTen.ToLower().Contains(keyword)));
            }
            if (maLop != int.MinValue)
            {
                query = query.Where(hocSinh => hocSinh.LopId == maLop);
            }
            return query;
        }

        public HocSinh LayHocSinhTheoMa(int hocSinhId)
        {
            var hocSinh = qLHSDbContext.HocSinh.Find(hocSinhId);
            return hocSinh;
        }

        public HocSinh SuaThongTinHS(int hocSinhId, HocSinh hocSinh)
        {
            if (qLHSDbContext.HocSinh.Any(hocSinh => hocSinh.Id == hocSinhId))
            {
                var currentHocSinh = LayHocSinhTheoMa(hocSinhId);
                currentHocSinh.HoTen = hocSinh.HoTen;
                currentHocSinh.NgaySinh = hocSinh.NgaySinh;
                currentHocSinh.QueQuan = hocSinh.QueQuan;
                currentHocSinh.LopId = hocSinh.LopId;
                qLHSDbContext.HocSinh.Update(currentHocSinh);
                qLHSDbContext.SaveChanges();
                return currentHocSinh;
            }
            else
            {
                throw new Exception($"Hoc sinh {hocSinhId} khong ton tai!");
            }
        }

        public HocSinh ThemHocSinh(HocSinh hocSinh)
        {
            qLHSDbContext.HocSinh.Add(hocSinh);
            qLHSDbContext.SaveChanges();
            return hocSinh;
        }

        public void XoaHocSinh(int hocSinhId)
        {
            if (qLHSDbContext.HocSinh.Any(hocSinh => hocSinh.Id == hocSinhId))
            {
                var currentHocSinh = LayHocSinhTheoMa(hocSinhId);
                qLHSDbContext.HocSinh.Remove(currentHocSinh);
                qLHSDbContext.SaveChanges();
            }
            else
            {
                throw new Exception($"Hoc sinh {hocSinhId} khong ton tai!");
            }
        }
    }
}
