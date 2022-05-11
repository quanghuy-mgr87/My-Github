using DoAn.Entities;
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
    public partial class frmUser : Form
    {
        private UserServices userServices { get; }
        public frmUser()
        {
            InitializeComponent();
            userServices = new UserServices();
        }
        void GetUserList()
        {
            var lstUser = userServices.GetUserList().ToList();
            gridUserList.DataSource = lstUser;
        }
        private void frmUser_Load(object sender, EventArgs e)
        {
            GetUserList();
        }

        private void btnDatQTV_Click(object sender, EventArgs e)
        {
            int userId = int.Parse(gridUserList.CurrentRow.Cells[0].Value.ToString());
            User user = userServices.GetUserById(userId);
            user.roleId = 1;
            if (userServices.UpdateUser(user))
            {
                MessageBox.Show("Cập nhật thành công!");
                GetUserList();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void btnXoaQTV_Click(object sender, EventArgs e)
        {
            int userId = int.Parse(gridUserList.CurrentRow.Cells[0].Value.ToString());
            User user = userServices.GetUserById(userId);
            user.roleId = 2;
            if (userServices.UpdateUser(user))
            {
                MessageBox.Show("Cập nhật thành công!");
                GetUserList();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            int userId = int.Parse(gridUserList.CurrentRow.Cells[0].Value.ToString());
            User user = userServices.GetUserById(userId);
            user.password = InputHelper.MD5Hash("1");
            if (userServices.UpdateUser(user))
            {
                MessageBox.Show("Cập nhật thành công!");
                GetUserList();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            int userId = int.Parse(gridUserList.CurrentRow.Cells[0].Value.ToString());
            if (userServices.DeleteUser(userId))
            {
                MessageBox.Show("Cập nhật thành công!");
                GetUserList();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }
    }
}
