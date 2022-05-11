using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muc1_8
{
    class ThoiGian
    {
        #region Private
        private int _Nam;
        private void KiemTraNamNhuan()
        {
            LaNamNhuan = (Nam % 4 == 0 || (Nam % 100 == 0 && Nam % 400 == 0)) ? true : false;
        }
        private void NhapNgay()
        {
            switch (Thang)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    {
                        Ngay = Helper.NhapThoiGian(res.StrNhapNgay, res.ErrNhapNgay, 1, 31);
                        break;
                    }
                case 4:
                case 6:
                case 9:
                case 11:
                    {
                        Ngay = Helper.NhapThoiGian(res.StrNhapNgay, res.ErrNhapNgay, 1, 30);
                        break;
                    }
                case 2:
                    {
                        if (LaNamNhuan)
                            Ngay = Helper.NhapThoiGian(res.StrNhapNgay, res.ErrNhapNgay, 1, 29);
                        else
                            Ngay = Helper.NhapThoiGian(res.StrNhapNgay, res.ErrNhapNgay, 1, 28);
                        break;
                    }
            }
        }
        private void NhapThang()
        {
            Thang = Helper.NhapThoiGian(res.StrNhapThang, res.ErrNhapThang, 1, 12);
        }
        private void NhapNam()
        {
            Nam = Helper.NhapThoiGian(res.StrNhapNam, res.ErrNhapNam, 1000, DateTime.Now.Year);
        }
        #endregion

        #region Public
        public int Ngay { get; set; }
        public int Thang { get; set; }
        public int Nam
        {
            get { return _Nam; }
            set
            {
                _Nam = value;
                KiemTraNamNhuan();
            }
        }
        public bool LaNamNhuan { get; private set; }
        public int Thu { get; private set; }
        public void LayThu()
        {
            DateTime dt = new DateTime(Nam, Thang, Ngay);
            string day = dt.DayOfWeek.ToString();
            if (day == "Monday")
                Thu = 2;
            if (day == "Tuesday")
                Thu = 3;
            if (day == "Wednesday")
                Thu = 4;
            if (day == "Thursday")
                Thu = 5;
            if (day == "Friday")
                Thu = 6;
            if (day == "Saturday")
                Thu = 7;
            if (day == "Sunday")
                Thu = 8;
        }
        public ThoiGian()
        {
            NhapNam();
            NhapThang();
            NhapNgay();
            LayThu();
        }
        public ThoiGian(int Nam, int Thang, int Ngay, bool i = true)
        {
            this.Nam = Nam;
            this.Thang = Thang;
            this.Ngay = Ngay;
            if (i == true)
                LayThu();
        }
        public int LayKhoangThoiGian(ThoiGian t1, ThoiGian t2)
        {
            TimeSpan time = (new DateTime(t1.Nam, t1.Thang, t1.Ngay)).Subtract(new DateTime(t2.Nam, t2.Thang, t2.Ngay));
            int a = Math.Abs(int.Parse(time.ToString().Split('.').First())) * 24;
            return a;
        }
        public void HienThi()
        {
            string str = "";
            if (LaNamNhuan)
                str += "co";
            else
                str += "khong";
            Console.WriteLine($"Thoi gian hien tai la: Thu {Thu}, ngay {Ngay}, thang {Thang}, nam {Nam}. Day {str} la nam nhuan.");
        }
        public void HienThiKhoangTG()
        {
            Console.WriteLine($"Khoang thoi gian giua 2 ngay la: {Nam} nam, {Thang} thang, {Ngay} ngay");
        }
        #endregion
    }
}
