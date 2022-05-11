using System;
using System.Collections.Generic;
using System.Text;

namespace HVIT_MVC_HinhHoc.Model
{
    class Diem
    {
        public int x { get; set; }
        public int y { get; set; }
        public Diem() { }
        public Diem(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void InThongTin()
        {
            Console.Write($"[{x},{y}]  ");
        }
    }
}
