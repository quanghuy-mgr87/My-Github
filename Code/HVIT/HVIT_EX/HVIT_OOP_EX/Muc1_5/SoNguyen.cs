using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muc1_5
{
    class SoNguyen
    {
        #region Private Section
        private void KiemTraChan()
        {
            LaSoChan = (GiaTri % 2 == 0 ? true : false);
        }
        private void KiemTraNguyenTo()
        {
            bool check;
            if (GiaTri == 0 || GiaTri == 1)
            {
                check = false;
            }
            else if (GiaTri == 2)
            {
                check = true;
            }
            else
            {
                check = true;
                for (int i = 2; i <= GiaTri / 2; i++)
                {
                    if (GiaTri % i == 0)
                        check = false;
                }
            }
            LaSoNguyenTo = check;
        }
        private void KiemTraDoiXung()
        {
            int dem = 0;
            List<int> lstNum = Helper.TachSo(GiaTri);
            int j = lstNum.Count - 1;
            for (int i = 0; i < lstNum.Count; i++)
            {
                if (lstNum[i] == lstNum[j])
                    dem++;
                j--;
            }
            if (dem == lstNum.Count)
                LaSoDoiXung = true;
            else
                LaSoDoiXung = false;
        }
        private void NhapSo()
        {
            GiaTri = Helper.TaoSoNguyen(res.TaoSoNguyen, res.ErrTaoSoNguyen);
        }
        private int _GiaTri;
        #endregion

        #region Public Section
        public int GiaTri
        {
            get { return _GiaTri; }
            set
            {
                _GiaTri = value;
                KiemTraChan();
                KiemTraNguyenTo();
                KiemTraDoiXung();
            }
        }
        public bool LaSoChan { get; private set; }
        public bool LaSoNguyenTo { get; private set; }
        public bool LaSoDoiXung { get; private set; }
        public SoNguyen()
        {
            NhapSo();
        }
        public SoNguyen(int GiaTri)
        {
            this.GiaTri = GiaTri;
        }
        public int Cong(int GiaTri)
        {
            return this.GiaTri + GiaTri;
        }
        public void HienThi()
        {
            Console.WriteLine($"So nguyen {GiaTri} co/khong: {LaSoChan} la so chan, co/khong: {LaSoNguyenTo} la so nguyen to.");
            Console.WriteLine($"So nguyen {GiaTri} co/khong: {LaSoDoiXung} la so doi xung.");
        }
        #endregion
    }
}
