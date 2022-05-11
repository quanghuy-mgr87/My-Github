using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVIT_OOP_EX
{
    class LopHoc
    {
        public int MaLop { get; set; }
        public string TenLop { get; set; }
        public int SiSo { get; set; }
        public string DiaChi { get; set; }
        public string GiaoVienChuNhiem { get; set; }

        public LopHoc()
        {
            NhapThongTin();
        }

        public LopHoc(int MaLop, string TenLop, int SiSo, string DiaChi, string GiaoVienChuNhiem)
        {
            this.MaLop = MaLop;
            this.SiSo = SiSo;
            this.TenLop = TenLop;
            this.DiaChi = DiaChi;
            this.GiaoVienChuNhiem = GiaoVienChuNhiem;
        }

        public void NhapThongTin()
        {
            Console.Write("Ma lop: ");
            MaLop = int.Parse(Console.ReadLine());
            Console.Write("Ten lop: ");
            TenLop = Console.ReadLine();
            Console.Write("Si so: ");
            SiSo = int.Parse(Console.ReadLine());
            Console.Write("Dia chi: ");
            DiaChi = Console.ReadLine();
            Console.Write("Giao vien chu nhiem: ");
            GiaoVienChuNhiem = Console.ReadLine();
            Console.WriteLine();
        }

        public void HienThi()
        {
            Console.WriteLine($"Lop {TenLop} co ma la {MaLop} o {DiaChi}.");
            Console.WriteLine($"Lop co {SiSo} hoc sinh va co GVCN la {GiaoVienChuNhiem}.");
        }
    }
}
