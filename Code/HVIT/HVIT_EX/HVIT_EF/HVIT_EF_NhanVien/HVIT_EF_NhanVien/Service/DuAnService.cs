using HVIT_EF_NhanVien.Entities;
using HVIT_EF_NhanVien.Helper;
using HVIT_EF_NhanVien.IService;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HVIT_EF_NhanVien.Service
{
    class DuAnService : IDuAnService
    {
        private DuAnDbContext dbContext { get; }
        public DuAnService()
        {
            dbContext = new DuAnDbContext();
        }
        public errType SuaDuAn(DuAn duAn)
        {
            DuAn duAn1 = dbContext.duAns.SingleOrDefault(x => x.Id == duAn.Id);
            if (duAn1 == null)
            {
                return errType.KhongTonTaiDuAn;
            }
            else
            {
                duAn1.tenDuAn = inputHelper.InputString("Ten du an: ", "Ten du an khong duoc qua 10 ky tu!", 0, 10);
                duAn1.moTa = inputHelper.InputString("Mo ta: ", "Mo ta khong hop le!");
                duAn1.ghiChu = inputHelper.InputString("Ghi chu: ", "Ghi chu khong hop le!");
                dbContext.duAns.Update(duAn1);
                dbContext.SaveChanges();
                return errType.ThanhCong;
            }
        }
    }
}
