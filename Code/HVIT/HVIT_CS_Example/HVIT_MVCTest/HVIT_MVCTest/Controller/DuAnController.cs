using HVIT_MVCTest.Helper;
using HVIT_MVCTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVIT_MVCTest.Controller
{
    class DuAnController
    {
        public static errType SuaDuAn(DuAn duAn)
        {
            using (var db = new BusinessContext())
            {
                DuAn duAn1 = db.duAns.SingleOrDefault(x => x.DuanId == duAn.DuanId);
                if (duAn1 == null)
                {
                    return errType.KhongTonTaiDuAn;
                }
                else
                {
                    duAn1.Tenduan = duAn.Tenduan;
                    duAn1.Mota = duAn.Mota;
                    duAn1.Ghichu = duAn.Ghichu;
                    db.SaveChanges();
                    return errType.ThanhCong;
                }
            }
        }
    }
}
