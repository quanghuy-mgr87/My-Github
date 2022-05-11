using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muc1_7
{
    class DongHo
    {
        private bool _LaBuoiSang;
        private void NhapGio()
        {
            Gio = Helper.NhapThoiGian(res.StrNhapGio, res.ErrNhapGio, 0, 23);
        }
        private void NhapPhut()
        {
            Phut = Helper.NhapThoiGian(res.StrNhapPhut, res.ErrNhapPhutGiay, 0, 59);
        }
        private void NhapGiay()
        {
            Giay = Helper.NhapThoiGian(res.StrNhapGiay, res.ErrNhapPhutGiay, 0, 59);
        }

        public int Gio { get; set; }
        public int Phut { get; set; }
        public int Giay { get; set; }
        public bool LaBuoiSang
        {
            get
            {
                if (Gio <= 11)
                {
                    if (Phut < 60 && Giay < 60)
                        _LaBuoiSang = true;
                }
                else
                {
                    _LaBuoiSang = false;
                }
                return _LaBuoiSang;
            }
            private set { _LaBuoiSang = value; }
        }
        public DongHo()
        {
            NhapGio();
            NhapPhut();
            NhapGiay();
        }
        public DongHo(int Gio, int Phut, int Giay)
        {
            this.Gio = Gio;
            this.Phut = Phut;
            this.Giay = Giay;
        }
        public DongHo LayKhoangThoiGian(DongHo h)
        {
            return new DongHo(Math.Abs(Gio - h.Gio), Math.Abs(Phut - h.Phut), Math.Abs(Giay - h.Giay));
        }
        public void HienThiBuoiTrongNgay()
        {
            if (LaBuoiSang)
                Console.WriteLine("Bay gio la buoi sang.");
            else
                Console.WriteLine("Bay gio la buoi chieu.");
        }
        public void HienThi(int check = 0)
        {
            Console.WriteLine($"{Gio}:{Phut}:{Giay}");
            if (check == 0)
                HienThiBuoiTrongNgay();
        }
    }
}
