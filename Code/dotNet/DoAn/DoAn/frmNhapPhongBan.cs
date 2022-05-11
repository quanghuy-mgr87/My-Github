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
    public partial class frmNhapPhongBan : Form
    {
        private PhongBanServices phongBanServices { get; set; }
        private int phongBanId;
        public frmNhapPhongBan()
        {
            InitializeComponent();
            phongBanServices = new PhongBanServices();
        }

        private void HienThiDS()
        {
            gridPhongBan.DataSource = phongBanServices.GetPhongBanList();
        }

        private void frmNhapPhongBan_Load(object sender, EventArgs e)
        {
            HienThiDS();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            PhongBan phongBan = new PhongBan();
            phongBan.tenPhongBan = txtTenPB.Text;
            if (phongBanServices.ThemPhongBan(phongBan))
            {
                MessageBox.Show("Thêm thành công!");
                HienThiDS();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var currentPB = phongBanServices.GetPhongBanById(phongBanId);
            currentPB.tenPhongBan = txtTenPB.Text;
            if (phongBanServices.SuaPhongBan(currentPB))
            {
                MessageBox.Show("Sửa thành công!");
                HienThiDS();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                if (phongBanServices.XoaPhongBan(phongBanId))
                {
                    MessageBox.Show("Xoá thành công!");
                    HienThiDS();
                }
                else
                {
                    MessageBox.Show("Xoá thất bại!");
                }
            }
        }

        private void gridPhongBan_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            phongBanId = int.Parse(gridPhongBan.CurrentRow.Cells[0].Value.ToString());
            txtTenPB.Text = phongBanServices.GetPhongBanById(phongBanId).tenPhongBan;
        }
    }
}
