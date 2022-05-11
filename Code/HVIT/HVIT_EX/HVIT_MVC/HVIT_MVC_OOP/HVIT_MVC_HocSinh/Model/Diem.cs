using HVIT_MVC_HocSinh.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_MVC_HocSinh.Model
{
    class Diem
    {
        public int maHS { get; set; }
        public int maMH { get; set; }
        public double diem { get; set; }
        public Diem()
        {
            maHS = inputHelper.InputInt(res.inputMaHS, res.errorMaHS);
            maMH = inputHelper.InputInt(res.inputMaMH, res.errorMaMH);
            diem = inputHelper.NhapDiem(res.inputDiem, res.errorDiem);
        }
        public Diem(int maHS, int maMH, double diem)
        {
            this.maHS = maHS;
            this.maMH = maMH;
            this.diem = diem;
        }
    }
}
