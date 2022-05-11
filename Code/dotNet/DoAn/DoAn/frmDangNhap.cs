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
    public partial class frmDangNhap : Form
    {
        public static bool isAdmin = false;
        public static string username = "";
        private UserServices userServices { get; set; }
        public frmDangNhap()
        {
            InitializeComponent();
            userServices = new UserServices();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (userServices.SignIn(txtTaiKhoan.Text, txtPass.Text))
            {
                int roleId = int.Parse(userServices.GetUserByUsername(txtTaiKhoan.Text).roleId.ToString());
                switch (roleId)
                {
                    case 1:
                        {
                            isAdmin = true;
                            break;
                        }
                        //
                }
                MessageBox.Show("Đăng nhập thành công!");
                frmMain frmMain = new frmMain();
                username = txtTaiKhoan.Text;
                frmMain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại!");
            }
        }

        private void linkLabelDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDangKy frmDangKy = new frmDangKy();
            frmDangKy.Show();
            this.Hide();
        }
    }
}
