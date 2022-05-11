using HVIT_EF_NhanVien.Entities;
using HVIT_EF_NhanVien.Helper;
using HVIT_EF_NhanVien.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVIT_EF_NhanVien.Service
{
    class PhanCongService : IPhanCongService
    {
        private DuAnDbContext dbContext { get; }
        public PhanCongService()
        {
            dbContext = new DuAnDbContext();
        }
        public errType ThemNhanVienVaoDuAn(PhanCong phanCong)
        {
            PhanCong phanCong1 = dbContext.phanCongs.SingleOrDefault(x => x.Id == phanCong.Id);
            NhanVien nhanVien = dbContext.nhanViens.SingleOrDefault(x => x.Id == phanCong.nhanVienId);
            DuAn duAn = dbContext.duAns.SingleOrDefault(x => x.Id == phanCong.duAnId);
            if (nhanVien == null)
            {
                return errType.KhongTonTaiNhanVien;
            }
            if (duAn == null)
            {
                return errType.KhongTonTaiDuAn;
            }
            if (phanCong1 != null)
            {
                return errType.DaTonTai;
            }
            else
            {
                phanCong.Id = 0;
                dbContext.phanCongs.Add(phanCong);
                dbContext.SaveChanges();
                return errType.ThanhCong;
            }
        }
    }
}
