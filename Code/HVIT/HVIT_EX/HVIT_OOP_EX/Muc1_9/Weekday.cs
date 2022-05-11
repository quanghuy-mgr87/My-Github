using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muc1_9
{
    class Weekday
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
            Nam = Helper.NhapThoiGian(res.StrNhapNam, res.ErrNhapNam, 1900, 9999);
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
            //string day = dt.DayOfWeek.ToString();

            DayOfWeek day2 = dt.DayOfWeek;
            //Console.WriteLine($"...   {day2}  ");
            if (day2 == DayOfWeek.Monday)
            {
                Thu = 2;
            }
            if (day2 == DayOfWeek.Tuesday)
            {
                Thu = 3;
            }
            if (day2 == DayOfWeek.Wednesday)
            {
                Thu = 4;
            }
            if (day2 == DayOfWeek.Thursday)
            {
                Thu = 5;
            }
            if (day2 == DayOfWeek.Friday)
            {
                Thu = 6;
            }
            if (day2 == DayOfWeek.Saturday)
            {
                Thu = 7;
            }
            if (day2 == DayOfWeek.Sunday)
            {
                Thu = 8;
            }

            //if (day == "Monday")
            //    Thu = 2;
            //if (day == "Tuesday")
            //    Thu = 3;
            //if (day == "Wednesday")
            //    Thu = 4;
            //if (day == "Thursday")
            //    Thu = 5;
            //if (day == "Friday")
            //    Thu = 6;
            //if (day == "Saturday")
            //    Thu = 7;
            //if (day == "Sunday")
            //    Thu = 8;
        }
        public Weekday()
        {
            NhapNam();
            NhapThang();
            NhapNgay();
            LayThu();
        }
        public Weekday(int Nam, int Thang, int Ngay, bool i = true)
        {
            this.Nam = Nam;
            this.Thang = Thang;
            this.Ngay = Ngay;
            if (i == true)
                LayThu();
        }
        public int LayKhoangThoiGian(Weekday w)
        {
            TimeSpan time = new DateTime(Nam, Thang, Ngay).Subtract(new DateTime(w.Nam, w.Thang, w.Ngay));
            int n = Math.Abs(int.Parse(time.ToString().Split('.').First()));
            return n;
        }
        public void HienThi()
        {
            string str = "";
            if (LaNamNhuan)
                str += "co";
            else
                str += "khong";
            if (Thu == 8)
                Console.WriteLine($"Chu Nhat, Ngay {Ngay}, thang {Thang}, nam {Nam} va {str} la nam nhuan.");
            else
                Console.WriteLine($"Thu {Thu}, Ngay {Ngay}, thang {Thang}, nam {Nam} va {str} la nam nhuan.");
        }
        #endregion
    }
}
