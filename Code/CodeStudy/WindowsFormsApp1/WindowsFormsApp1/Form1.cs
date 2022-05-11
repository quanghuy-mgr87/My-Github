using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private PhanSo TaoPhanSoTuChuoi(String str)
        {
            String[] strArr = str.Split(new char[] { '/' });
            return new PhanSo(int.Parse(strArr[0]), int.Parse(strArr[1]));
        }

        public double TinhLogarit(double coSo, double number)
        {
            return Math.Log(number, coSo);
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            int TongSoPT = int.Parse(txtTongSoPT.Text);
            int TongSoLanXH = int.Parse(txtTongSoLanXH.Text);
            int Tong = int.Parse(txtTong.Text);

            List<PhanSo> phanSos = new List<PhanSo>();
            String[] phanSosString = txtListPi.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;
            foreach (var item in phanSosString)
            {
                PhanSo phanSo = TaoPhanSoTuChuoi(item);
                sum += phanSo.TinhPi() * TinhLogarit(2, phanSo.TinhPiNghichDao());
            }

            //Ket Qua:
            txtSoBitTB.Text = (Tong * 1.0 / TongSoLanXH).ToString();
            txtSoBitThongThuong.Text = TinhLogarit(2, TongSoPT).ToString();
            txtEstropy.Text = sum.ToString();
            txtHieuSuat.Text = (double.Parse(txtEstropy.Text) / double.Parse(txtSoBitTB.Text)).ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Test", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
        }
    }
}
