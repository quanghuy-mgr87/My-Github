using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muc1_2
{
    class Nguoi
    {
        #region Private
        private string _HoTen;
        private void TaoDuLieuHoTen()
        {
            Console.Write("Ho ten: ");
            HoTen = Console.ReadLine();
        }
        #endregion

        #region Public
        public int MaSo { get; set; }
        public string HoTen
        {
            get { return _HoTen; }
            set
            {
                _HoTen = value;
                string[] temp = Helper.CatChuoi(_HoTen);

                Ho = temp[0];
                Ten = temp[temp.Length - 1];

                for (int i = 1; i < temp.Length - 1; i++)
                {
                    if (i == temp.Length - 2)
                    {
                        Dem += temp[i].ToString();
                    }
                    else
                    {
                        Dem += temp[i].ToString();
                        Dem += " ";
                    }
                }
            }
        }
        public DateTime NgaySinh { get; set; }
        public string Ho { private get; set; }
        public string Dem { private get; set; }
        public string Ten { private get; set; }
        public Nguoi()
        {
            Console.Write("Ma so: ");
            MaSo = int.Parse(Console.ReadLine());
            TaoDuLieuHoTen();
            Console.Write("Ngay sinh: ");
            NgaySinh = DateTime.Parse(Console.ReadLine());
        }
        public Nguoi(int MaSo, string HoTen, DateTime NgaySinh)
        {
            this.MaSo = MaSo;
            this.HoTen = HoTen;
            this.NgaySinh = NgaySinh;
        }
        public void HienThi()
        {
            Console.WriteLine($"{MaSo} co ten la {HoTen} sinh ngay {NgaySinh.ToShortDateString()}.");
            Console.WriteLine($"- Ho: {Ho}\n- Dem: {Dem}\n- Ten: {Ten}.");
        }
        #endregion
    }
}
