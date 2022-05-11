using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HVIT_MVC_OOP.Controller;

namespace HVIT_MVC_OOP.Model
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
        //private int _giaTri;
        //private bool _laSoChan;
        //private bool _laSoNT;
        //private bool _laSoDoiXung;
        //private void xacDinhThuocTinh()
        //{
        //    KiemTraSoChan();
        //    KiemTraSoDoiXung();
        //    KiemTraSoNT();
        //}

        //public int giaTri
        //{
        //    get { return _giaTri; }
        //    set
        //    {
        //        _giaTri = value;   
        //    }
        //}
        //public bool laSoChan { get { return _laSoChan; } }
        //public bool laSoNT { get { return _laSoNT; } }
        //public bool laSoDoiXung { get { return _laSoDoiXung; } }

        //private void KiemTraSoChan()
        //{
        //    _laSoChan = _giaTri % 2 == 0 ? true : false;
        //}
        //private void KiemTraSoNT()
        //{
        //    if (_giaTri == 0 || _giaTri == 1)
        //    {
        //        _laSoNT = false;
        //    }
        //    if (_giaTri == 2)
        //    {
        //        _laSoNT = true;
        //    }
        //    else
        //    {
        //        for (int i = 2; i < _giaTri; i++)
        //        {
        //            if (_giaTri % i == 0)
        //                _laSoNT = false;
        //            else
        //                _laSoNT = true;
        //        }
        //    }
        //}
        //private void KiemTraSoDoiXung()
        //{
        //    string temp = _giaTri.ToString();
        //    char[] oldArr = temp.ToCharArray();
        //    char[] newArr = temp.ToCharArray();
        //    Array.Reverse(newArr);
        //    int dem = 0;
        //    for (int i = 0; i < newArr.Length; i++)
        //    {
        //        if (oldArr[i] == newArr[i])
        //        {
        //            dem++;
        //        }
        //    }
        //    if (dem == oldArr.Length)
        //    {
        //        _laSoDoiXung = true;
        //    }
        //    else
        //    {
        //        _laSoDoiXung = false;
        //    }
        //}

        //public SoHoc() { }
        //public SoHoc(int giaTri)
        //{
        //    this.giaTri = giaTri;
        //}
        //public void InThongTin()
        //{
        //    Console.Write($"{_giaTri}  ");
        //}

        private int _giaTri;
        public int giaTri
        {
            get { return _giaTri; }
            set
            {

            }
        }
        public bool laSoChan { get; private set; }
        public bool laNT { get; private set; }
        public bool laSoDoiXung { get; private set; }
        private void xacDinhThuocTinh()
        {
            laSoChan = KiemTraSoChan();
            laSoDoiXung = KiemTraSoDoiXung();
            laNT = KiemTraSoNT();
        }
        private bool KiemTraSoChan() => (giaTri % 2 == 0);
        private bool KiemTraSoDoiXung()
        {
            string temp = _giaTri.ToString();
            char[] oldArr = temp.ToCharArray();
            char[] newArr = temp.ToCharArray();
            Array.Reverse(newArr);
            int dem = 0;
            for (int i = 0; i < newArr.Length; i++)
            {
                if (oldArr[i] == newArr[i])
                {
                    dem++;
                }
            }
            if (dem == oldArr.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool KiemTraSoNT()
        {
            //if (giaTri == 0 || giaTri == 1)
            //{
            //    return false;
            //}
            //if (giaTri == 2)
            //{
            //    return true;
            //}
            //else
            //{
            //    for (int i = 2; i < giaTri; i++)
            //    {
            //        if (giaTri % i == 0)
            //        {

            //        }
            //    }
            //}
        }
    }
}
