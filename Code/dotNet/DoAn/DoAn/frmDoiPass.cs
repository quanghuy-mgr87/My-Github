using DoAn.Helper;
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
    public partial class frmDoiPass : Form
    {
        private static string username = "";
        private UserServices userServices { get; }
        public frmDoiPass()
        {
            InitializeComponent();
            userServices = new UserServices();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            var user = userServices.GetUserByUsername(username);
            if (txtPassMoi == txtNhapLaiPass && InputHelper.MD5Hash(txtPassCu.Text) == user.password)
            {
                user.password = InputHelper.MD5Hash(txtPassMoi.Text);
                if (userServices.UpdateUser(user))
                {
                    MessageBox.Show("Cập nhật thành công!");
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void t_Load(object sender, EventArgs e)
        {
            username = frmDangNhap.username;
        }
    }
}
