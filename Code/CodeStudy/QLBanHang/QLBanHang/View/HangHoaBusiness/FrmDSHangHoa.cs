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

namespace QLBanHang.View.HangHoaBusiness
{
    public partial class FrmDSHangHoa : Form
    {
        private readonly IMatHangServices matHangServices = new MatHangServices();
        private readonly IDonViBanHangServices donViBanHangServices = new DonViBanHangServices();
        public FrmDSHangHoa()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maHangHoa = int.Parse(gridMatHang.CurrentRow.Cells["MaMatHang"].Value.ToString());
            DialogResult ret = MessageBox.Show($"Bạn có chắc chắn muốn xoá mặt hàng {maHangHoa} không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
            {
                bool isDelete = matHangServices.XoaMatHang(maHangHoa);
                if (isDelete)
                {
                    MessageBox.Show($"Đã xoá mặt hàng {maHangHoa}!", "Thông báo!");
                    HienThiDS();
                }
                else
                {
                    MessageBox.Show($"Xoá mặt hàng {maHangHoa} thất bại!", "Thông báo!");
                }
            }
        }

        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {
            int maMatHang = int.Parse(gridMatHang.CurrentRow.Cells["MaMatHang"].Value.ToString());
            int maDonViBan = int.Parse(gridMatHang.CurrentRow.Cells["DonViBanId"].Value.ToString());
            MatHang matHangHienTai = matHangServices.LayThongTinMatHangTheoMa(maMatHang);
            DonViBanHang donViBanHienTai = donViBanHangServices.TimDonViTheoMa(maDonViBan);
            FrmNhapHang frmNhapHang = new FrmNhapHang(donViBanHienTai, matHangHienTai);
            frmNhapHang.ShowDialog();
            HienThiDS();
        }

        private void HienThiDS()
        {
            gridMatHang.DataSource = matHangServices.LayDSMatHang();
        }

        private void TaoBang()
        {
            gridMatHang.Columns.Add("MaMatHang", "Mã mặt hàng");
            gridMatHang.Columns["MaMatHang"].DataPropertyName = "MaMatHang";
            gridMatHang.Columns.Add("TenMatHang", "Tên mặt hàng");
            gridMatHang.Columns["TenMatHang"].DataPropertyName = "TenMatHang";
            gridMatHang.Columns.Add("HangSanXuat", "Hãng sản xuất");
            gridMatHang.Columns["HangSanXuat"].DataPropertyName = "HangSanXuat";
            gridMatHang.Columns.Add("DonViTinh", "Đơn vị tính");
            gridMatHang.Columns["DonViTinh"].DataPropertyName = "DonViTinh";
            gridMatHang.Columns.Add("DonGiaNhap", "Đơn giá nhập");
            gridMatHang.Columns["DonGiaNhap"].DataPropertyName = "DonGiaNhap";
            gridMatHang.Columns.Add("DonGiaBan", "Đơn giá bán");
            gridMatHang.Columns["DonGiaBan"].DataPropertyName = "DonGiaBan";
            gridMatHang.Columns.Add("DonViBanId", "Mã đơn vị bán");
            gridMatHang.Columns["DonViBanId"].DataPropertyName = "DonViBanId";
            gridMatHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void FrmDSHangHoa_Load(object sender, EventArgs e)
        {
            TaoBang();
            HienThiDS();
        }
    }
}
