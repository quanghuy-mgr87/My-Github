using DoAn.IServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            frmDangNhap frmDangNhap = new frmDangNhap();
            frmDangNhap.isAdmin = false;
            frmDangNhap.Show();
            this.Hide();
        }

        private void mnuPhanQuyen_Click(object sender, EventArgs e)
        {
            frmUser frmUser = new frmUser();
            frmUser.Show();
            frmUser.MdiParent = this;
        }

        private void đóngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!frmDangNhap.isAdmin)
            {
                mnuPhanQuyen.Visible = false;
                mnuDanhMuc.Visible = false;
            }
        }

        private void mnuNhapThongTinNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void mnuNhapNCC_Click(object sender, EventArgs e)
        {
            frmNhapNCC frmNhapNCC = new frmNhapNCC();
            frmNhapNCC.Show();
            frmNhapNCC.MdiParent = this;
        }

        private void mnuNhapPhongBan_Click(object sender, EventArgs e)
        {
            frmNhapPhongBan frmNhapPhongBan = new frmNhapPhongBan();
            frmNhapPhongBan.Show();
            frmNhapPhongBan.MdiParent = this;
        }

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiPass frmDoiPass = new frmDoiPass();
            frmDoiPass.Show();
            frmDoiPass.MdiParent = this;
        }

        private void mnuNhapChucVu_Click(object sender, EventArgs e)
        {
            frmNhapChucVu frmNhapChucVu = new frmNhapChucVu();
            frmNhapChucVu.Show();
            frmNhapChucVu.MdiParent = this;
        }
    }
}
