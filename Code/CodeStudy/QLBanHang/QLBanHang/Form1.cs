using QLBanHang.View;
using QLBanHang.View.DonViBanBusiness;
using QLBanHang.View.HangHoaBusiness;
using QLBanHang.View.HoaDonBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanHang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void danhSáchNgườiMuaHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmQLKhachHang frmQLKhachHang = new FrmQLKhachHang();
            frmQLKhachHang.MdiParent = this;
            frmQLKhachHang.Show();
        }

        private void danhSáchĐơnVịBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmQLDonViBan frmQLDonViBan = new FrmQLDonViBan();
            frmQLDonViBan.MdiParent = this;
            frmQLDonViBan.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void nhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNhapHang frmNhapHang = new FrmNhapHang();
            frmNhapHang.ShowDialog();
        }

        private void xemDanhSáchHàngHoáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDSHangHoa frmDSHangHoa = new FrmDSHangHoa();
            frmDSHangHoa.MdiParent = this;
            frmDSHangHoa.Show();
        }

        private void nhậpHoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNhapHoaDon frmNhapHoaDon = new FrmNhapHoaDon();
            frmNhapHoaDon.ShowDialog();
        }

        private void xemDanhSáchHoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDSHoaDon frmDSHoaDon = new FrmDSHoaDon();
            frmDSHoaDon.MdiParent = this;
            frmDSHoaDon.Show();
        }
    }
}
