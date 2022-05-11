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

namespace QLBanHang.View.KhachHangBusiness
{
    public partial class FrmCapNhatThongTin : Form
    {
        private readonly NguoiMuaHangServices nguoiMuaHangServices = new NguoiMuaHangServices();
        private NguoiMuaHang nguoiMuaHang = null;
        public FrmCapNhatThongTin()
        {
            InitializeComponent();
        }

        private bool IsValidate()
        {
            errSTK.SetError(txtSTK, null);
            errMaSoThue.SetError(txtMaSoThue, null);
            errMaKH.SetError(txtMaKH, null);
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                errMaKH.SetError(txtMaKH, "Mã khách không được trống!");
                txtMaKH.Focus();
                return false;
            }
            if (!InputHelper.KiemTraSo(txtMaKH.Text))
            {
                errMaKH.SetError(txtMaKH, "Mã khách hàng phải là số!");
                txtMaKH.Focus();
                return false;
            }
            if (nguoiMuaHangServices.KiemTraTonTaiNguoiMuaHang(int.Parse(txtMaKH.Text)))
            {
                errMaKH.SetError(txtMaKH, "Mã khách hàng đã tồn tại!");
                txtMaKH.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMaSoThue.Text))
            {
                errMaSoThue.SetError(txtMaSoThue, "Mã số thuế không được trống!");
                txtMaSoThue.Focus();
                return false;
            }
            if (!InputHelper.KiemTraSo(txtMaSoThue.Text))
            {
                errMaSoThue.SetError(txtMaSoThue, "Mã số thuế phải là số!");
                txtMaSoThue.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSTK.Text))
            {
                errSTK.SetError(txtSTK, "Số tài khoản không được trống!");
                txtSTK.Focus();
                return false;
            }
            if (!InputHelper.KiemTraSo(txtSTK.Text))
            {
                errSTK.SetError(txtSTK, "Số tài khoản phải là số!");
                txtSTK.Focus();
                return false;
            }
            return true;
        }

        public FrmCapNhatThongTin(NguoiMuaHang nguoiMuaHang)
        {
            InitializeComponent();
            this.nguoiMuaHang = nguoiMuaHang;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCapNhatThongTin_Load(object sender, EventArgs e)
        {
            if (nguoiMuaHang != null)
            {
                txtMaKH.ReadOnly = true;
                txtMaKH.Text = nguoiMuaHang.Id.ToString();
                txtHoTen.Text = nguoiMuaHang.HoTen;
                txtDiaChi.Text = nguoiMuaHang.DiaChi;
                txtMaSoThue.Text = nguoiMuaHang.MaSoThue;
                txtSTK.Text = nguoiMuaHang.SoTaiKhoan;
                txtTenDonVi.Text = nguoiMuaHang.TenDonVi;
                cboHinhThucThanhToan.SelectedItem = nguoiMuaHang.HinhThucThanhToan;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!IsValidate())
                return;
            NguoiMuaHang newNguoiMuaHang = new NguoiMuaHang();
            newNguoiMuaHang.Id = int.Parse(txtMaKH.Text);
            newNguoiMuaHang.HoTen = txtHoTen.Text;
            newNguoiMuaHang.DiaChi = txtDiaChi.Text;
            newNguoiMuaHang.MaSoThue = txtMaSoThue.Text;
            newNguoiMuaHang.SoTaiKhoan = txtSTK.Text;
            newNguoiMuaHang.TenDonVi = txtTenDonVi.Text;
            newNguoiMuaHang.HinhThucThanhToan = cboHinhThucThanhToan.Text;
            if (nguoiMuaHang != null)
            {
                bool isUpdate = nguoiMuaHangServices.SuaThongTinNguoiMuaHang(newNguoiMuaHang);
                if (isUpdate)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Thông báo");
                }
            }
            else
            {
                bool isAdd = nguoiMuaHangServices.ThemNguoiMuaHang(newNguoiMuaHang);
                if (isAdd)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Thông báo");
                }
            }
        }
    }
}
