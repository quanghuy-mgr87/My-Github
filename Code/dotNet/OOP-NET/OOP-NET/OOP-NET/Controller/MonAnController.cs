using OOP_NET.Helper;
using OOP_NET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_NET.Controller
{
    class MonAnController
    {
        private static List<MonAn> lstMonAn = new List<MonAn>();
        public static errType ThemMonAn(MonAn monAn)
        {
            if (lstMonAn.Any(x => x.tenMonAn == monAn.tenMonAn))
            {
                return errType.MonAnDaTonTai;
            }
            else
            {
                lstMonAn.Add(monAn);
                return errType.ThanhCong;
            }
        }
        public static errorHelper SuaMonAn(MonAn monAn)
        {
            if(lstMonAn.Any(x=>x.tenMonAn == monAn.tenMonAn))
            {

            }
        }
    }
}
