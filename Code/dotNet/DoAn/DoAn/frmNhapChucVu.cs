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

namespace DoAn.IServices
{
    public partial class frmNhapChucVu : Form
    {
        private ChucVuServices chucVuServices { get; set; }
        private int chucVuId;
        public frmNhapChucVu()
        {
            InitializeComponent();
            chucVuServices = new ChucVuServices();
        }
        private void HienThiDS()
        {
            gridChucVu.DataSource = chucVuServices.GetChucVuList();
        }

        private void frmNhapChucVu_Load(object sender, EventArgs e)
        {
            HienThiDS();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ChucVu chucVu = new ChucVu();
            chucVu.tenChucVu = txtTenChucVu.Text;
            if (chucVuServices.ThemChucVu(chucVu))
            {
                MessageBox.Show("Thêm thành công!");
                HienThiDS();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
        }

        private void gridChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chucVuId = int.Parse(gridChucVu.CurrentRow.Cells[0].Value.ToString());
            txtTenChucVu.Text = chucVuServices.GetChucVuById(chucVuId).tenChucVu;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int chucVuId = int.Parse(gridChucVu.CurrentRow.Cells[0].Value.ToString());
            var chucVu = chucVuServices.GetChucVuById(chucVuId);
            chucVu.tenChucVu = txtTenChucVu.Text;
            if (chucVuServices.SuaChucVu(chucVu))
            {
                MessageBox.Show("Cập nhật thành công!");
                HienThiDS();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int chucVuId = int.Parse(gridChucVu.CurrentRow.Cells[0].Value.ToString());
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                if (chucVuServices.XoaChucVu(chucVuId))
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
    }
}
