using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muc1_6
{
    class PhanSo
    {
        private void ToiGian()
        {
            int num1 = TuSo, num2 = MauSo;
            TuSo /= Helper.TimUocChungLonNhat(num1, num2);
            MauSo /= Helper.TimUocChungLonNhat(num1, num2);
        }
        public int TuSo { get; set; }
        public int MauSo { get; set; }
        public PhanSo()
        {
            TuSo = Helper.TaoSoNguyen("Nhap tu so: ", "Ban phai nhap so nguyen!");
            MauSo = Helper.TaoSoNguyen("Nhap mau so: ", "Ban phai nhap so nguyen!");
        }
        public PhanSo(int TuSo, int MauSo)
        {
            this.TuSo = TuSo;
            this.MauSo = MauSo;
        }
        public PhanSo Cong(PhanSo p)
        {
            return new PhanSo(TuSo * p.MauSo + MauSo * p.TuSo, MauSo * p.MauSo);
        }
        public PhanSo Tru(PhanSo p)
        {
            return new PhanSo(TuSo * p.MauSo - MauSo * p.TuSo, MauSo * p.MauSo);
        }
        public void HienThi()
        {
            ToiGian();
            Console.WriteLine($"Phan so la: {TuSo}/{MauSo}.");
        }
    }
}
