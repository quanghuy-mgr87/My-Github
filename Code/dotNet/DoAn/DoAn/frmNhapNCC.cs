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
    public partial class frmNhapNCC : Form
    {
        private NhaCungCapServices nhaCungCapServices { get; set; }
        public frmNhapNCC()
        {
            InitializeComponent();
            nhaCungCapServices = new NhaCungCapServices();
        }
        private void HienThiDSNCC()
        {
            gridNhaCungCap.DataSource = nhaCungCapServices.GetNhaCungCapList();
        }
        private void frmNhapNCC_Load(object sender, EventArgs e)
        {
            HienThiDSNCC();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhaCungCap nhaCungCap = new NhaCungCap();
            nhaCungCap.tenNhaCungCap = txtTenNCC.Text;
            nhaCungCap.diaChi = txtDiaChi.Text;
            nhaCungCap.soDienThoai = txtSDT.Text;
            if (nhaCungCapServices.ThemNhaCungCap(nhaCungCap))
            {
                MessageBox.Show("Thêm thành công!");
                HienThiDSNCC();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int nccId = int.Parse(gridNhaCungCap.CurrentRow.Cells[0].Value.ToString());
            NhaCungCap nhaCungCap = nhaCungCapServices.GetNhaCungCapById(nccId);
            nhaCungCap.tenNhaCungCap = txtTenNCC.Text;
            nhaCungCap.diaChi = txtDiaChi.Text;
            nhaCungCap.soDienThoai = txtSDT.Text;
            if (nhaCungCapServices.SuaNhaCungCap(nhaCungCap))
            {
                MessageBox.Show("Sửa thành công!");
                HienThiDSNCC();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!");
            }
        }

        private void gridNhaCungCap_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int nccId = int.Parse(gridNhaCungCap.CurrentRow.Cells[0].Value.ToString());
            NhaCungCap nhaCungCap = nhaCungCapServices.GetNhaCungCapById(nccId);
            txtTenNCC.Text = nhaCungCap.tenNhaCungCap;
            txtDiaChi.Text = nhaCungCap.diaChi;
            txtSDT.Text = nhaCungCap.soDienThoai;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                int nccId = int.Parse(gridNhaCungCap.CurrentRow.Cells[0].Value.ToString());
                if (nhaCungCapServices.XoaNhaCungCap(nccId))
                {
                    MessageBox.Show("Xoá thành công!");
                    HienThiDSNCC();
                }
                else
                {
                    MessageBox.Show("Xoá thất bại!");
                }
            }
        }
    }
}
