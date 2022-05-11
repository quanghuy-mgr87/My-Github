using QLBanHang.Helper;
using QLBanHang.Interface;
using QLBanHang.Model;
using QLBanHang.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanHang.View.DonViBanBusiness
{
    public partial class FrmCapNhatDonViBan : Form
    {
        private readonly DonViBanHangServices donViBanHangServices = new DonViBanHangServices();
        private DonViBanHang donViBanHang = null;
        public FrmCapNhatDonViBan()
        {
            InitializeComponent();
        }
        public FrmCapNhatDonViBan(DonViBanHang donViBanHang)
        {
            InitializeComponent();
            this.donViBanHang = donViBanHang;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsValidate()
        {
            errorProvider1.SetError(txtMaDonViBan, null);
            errorProvider1.SetError(txtMaSoThue, null);
            errorProvider1.SetError(txtSDT, null);
            errorProvider1.SetError(txtSTK, null);
            if (string.IsNullOrEmpty(txtMaDonViBan.Text))
            {
                errorProvider1.SetError(txtMaDonViBan, "Mã đơn vị không được trống!");
                txtMaDonViBan.Focus();
                return false;
            }
            if (!InputHelper.KiemTraSo(txtMaDonViBan.Text))
            {
                errorProvider1.SetError(txtMaDonViBan, "Mã đơn vị phải là số!");
                txtMaDonViBan.Focus();
                return false;
            }
            if (donViBanHangServices.KiemTraTonTai(int.Parse(txtMaDonViBan.Text)))
            {
                errorProvider1.SetError(txtMaDonViBan, "Mã đơn vị đã tồn tại!");
                txtMaDonViBan.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                errorProvider1.SetError(txtSDT, "Số điện thoại không được trống!");
                txtSDT.Focus();
                return false;
            }
            if (!InputHelper.KiemTraSo(txtSDT.Text))
            {
                errorProvider1.SetError(txtSDT, "Số điện thoại phải là số!");
                txtSDT.Focus();
                return false;
            }


            if (string.IsNullOrEmpty(txtSTK.Text))
            {
                errorProvider1.SetError(txtSTK, "Số tài khoản không được trống!");
                txtSTK.Focus();
                return false;
            }
            if (!InputHelper.KiemTraSo(txtSTK.Text))
            {
                errorProvider1.SetError(txtSTK, "Số tài khoản phải là số!");
                txtSTK.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMaSoThue.Text))
            {
                errorProvider1.SetError(txtMaSoThue, "Mã số thuế được trống!");
                txtMaSoThue.Focus();
                return false;
            }
            if (!InputHelper.KiemTraSo(txtMaSoThue.Text))
            {
                errorProvider1.SetError(txtMaSoThue, "Mã số thuế phải là số!");
                txtMaSoThue.Focus();
                return false;
            }
            return true;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!IsValidate())
                return;
            DonViBanHang newDonViBanHang = new DonViBanHang();
            newDonViBanHang.Id = int.Parse(txtMaDonViBan.Text);
            newDonViBanHang.TenDonVi = txtTenDonViBan.Text;
            newDonViBanHang.DiaChi = txtDiaChi.Text;
            newDonViBanHang.SoTaiKhoan = txtSTK.Text;
            newDonViBanHang.SoDienThoai = txtSDT.Text;
            newDonViBanHang.MaSoThue = txtMaSoThue.Text;
            if (donViBanHang != null)
            {
                bool isUpdate = donViBanHangServices.SuaDonViBanHang(newDonViBanHang);
                if (isUpdate)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo!");
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Thông báo!");
                }
            }
            else
            {
                bool isAdd = donViBanHangServices.ThemDonViBanHang(newDonViBanHang);
                if (isAdd)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo!");
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Thông báo!");
                }
            }
        }

        private void FrmCapNhatDonViBan_Load(object sender, EventArgs e)
        {
            if (donViBanHang != null)
            {
                txtMaDonViBan.ReadOnly = true;
                txtMaDonViBan.Text = donViBanHang.Id.ToString();
                txtTenDonViBan.Text = donViBanHang.TenDonVi;
                txtSDT.Text = donViBanHang.SoDienThoai;
                txtSTK.Text = donViBanHang.SoTaiKhoan;
                txtDiaChi.Text = donViBanHang.DiaChi;
                txtMaSoThue.Text = donViBanHang.MaSoThue;

            }
        }
    }
}
