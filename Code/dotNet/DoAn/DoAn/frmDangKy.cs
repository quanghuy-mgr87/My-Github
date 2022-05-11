using DoAn.Entities;
using DoAn.Services;
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
    public partial class frmDangKy : Form
    {
        private UserServices userServices { get; set; }
        public frmDangKy()
        {
            InitializeComponent();
            userServices = new UserServices();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            frmDangNhap frmDangNhap = new frmDangNhap();
            frmDangNhap.Show();
            this.Hide();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.username = txtTaiKhoan.Text;
            user.password = txtMatKhau.Text;
            user.ngaySinh = dtpNgaySinh.Value;
            user.email = txtEmail.Text;
            user.soDienThoai = txtSoDienThoai.Text;

            bool check = userServices.SignUp(user);
            if (txtMatKhau.Text != txtNhapLaiMK.Text)
            {
                MessageBox.Show("Mật khẩu không trùng khớp!");
                return;
            }
            if (check)
            {
                MessageBox.Show("Đăng ký thành công!");
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại!");
            }
        }
    }
}
