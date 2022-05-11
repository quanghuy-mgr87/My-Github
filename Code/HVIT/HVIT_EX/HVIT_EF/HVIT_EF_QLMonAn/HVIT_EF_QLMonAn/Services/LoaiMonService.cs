using HVIT_EF_QLMonAn.Entities;
using HVIT_EF_QLMonAn.Helper;
using HVIT_EF_QLMonAn.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVIT_EF_QLMonAn.Services
{
    class LoaiMonService : ILoaiMonService
    {
        private AppDbContext dbContext { get; }
        public LoaiMonService()
        {
            dbContext = new AppDbContext();
        }
        public void AddMonAnRecycle(MonAn monAn)
        {
            if (monAn != null)
            {
                var temp = new MonAnRecycle();
                temp.Id = 0;
                temp.LoaiMonAnId = monAn.LoaiMonAnId;
                temp.TenMon = monAn.TenMon;
                temp.GiaBan = monAn.GiaBan;
                temp.GioiThieu = monAn.GioiThieu;
                temp.CachLam = monAn.CachLam;
                dbContext.monAnRecycles.Add(temp);
                dbContext.SaveChanges();
                dbContext.monAns.Remove(monAn);
                dbContext.SaveChanges();
            }
        }

        public void AddCongThucRecycle(List<CongThuc> lstCongThuc)
        {
            if (lstCongThuc.Count() != 0)
            {
                foreach(var val in lstCongThuc)
                {
                    var temp = new CongThucRecycle();
                    temp.Id = 0;
                    temp.NguyenLieuId = val.NguyenLieuId;
                    temp.MonAnId = val.MonAnId;
                    temp.SoLuong = val.SoLuong;
                    temp.DonViTinh = val.DonViTinh;
                    dbContext.congThucRecycles.Add(temp);
                    dbContext.SaveChanges();
                    dbContext.congThucs.Remove(val);
                    dbContext.SaveChanges();
                }
            }
        }
        public errType XoaLoaiMon(LoaiMonAn loaiMonAn)
        {
            if (dbContext.loaiMonAns.Any(x => x.Id == loaiMonAn.Id))
            {
                var monAn = dbContext.monAns.SingleOrDefault(x => x.LoaiMonAnId == loaiMonAn.Id);
                List<CongThuc> lstCongThuc = dbContext.congThucs.Where(x => x.MonAnId == monAn.Id).ToList();

                AddCongThucRecycle(lstCongThuc);
                AddMonAnRecycle(monAn);

                var loaiMonAn1 = dbContext.loaiMonAns.Find(loaiMonAn.Id);
                dbContext.loaiMonAns.Remove(loaiMonAn1);
                dbContext.SaveChanges();
                return errType.ThanhCong;
            }
            else
            {
                return errType.LoaiMonAnKhongTonTai;
            }
        }
    }
}
