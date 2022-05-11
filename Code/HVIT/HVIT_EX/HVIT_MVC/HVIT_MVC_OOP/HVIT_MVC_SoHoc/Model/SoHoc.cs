using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_MVC_SoHoc.Model
{
    enum LoaiSo
    {
        BatKy,
        SoChan,
        SoLe,
        SoNT,
        SoDoiXung
    }
    class SoHoc
    {
        #region Private
        private int _giaTri;
        private bool KiemTraSoChan() => (giaTri % 2 == 0);
        private bool KiemTraSoNT()
        {
            if (giaTri == 0 || giaTri == 1)
            {
                return false;
            }
            if (giaTri == 2)
            {
                return true;
            }
            else
            {
                for (int i = 2; i < _giaTri; i++)
                {
                    if (giaTri % i == 0)
                        return false;
                }
                return true;
            }
        }
        private bool KiemTraSoDoiXung()
        {
            string str = giaTri.ToString();
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            str = "";
            for (int i = 0; i < arr.Length; i++)
            {
                str += arr[i];
            }
            int temp = int.Parse(str);
            if (temp == giaTri)
                return true;
            return false;
        }
        private void XacDinhThuocTinh()
        {
            laSoChan = KiemTraSoChan();
            laSoNT = KiemTraSoNT();
            laSoDoiXung = KiemTraSoDoiXung();
        }
        #endregion

        #region Public
        public int giaTri
        {
            get { return _giaTri; }
            set
            {
                _giaTri = value;
                XacDinhThuocTinh();
            }
        }
        public bool laSoChan { get; private set; }
        public bool laSoNT { get; private set; }
        public bool laSoDoiXung { get; private set; }
        public SoHoc() { }
        public SoHoc(int giaTri)
        {
            this.giaTri = giaTri;
        }
        public void InThongTin()
        {
            Console.Write($"{_giaTri} ");
        }
        #endregion
    }
}
