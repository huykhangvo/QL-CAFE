using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class QuanLi : Form
    {
        public QuanLi()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (DangNhap.Chucvu.Equals("Quản lý"))
            {
                btnHETHONG.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
          //  Environment.Exit(1);
        }

        private void btnBANHANG_Click(object sender, EventArgs e)
        {
            this.Hide();
            QLBanHang frm3 = new QLBanHang();
            frm3.ShowDialog();
        }

        private void btnHETHONG_Click(object sender, EventArgs e)
        {
            this.Hide();
            QLHeThong frm4 = new QLHeThong();
            frm4.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap frm1 = new DangNhap();
            frm1.ShowDialog();
            
            //Form2 frm2 = new Form2();
            //frm2.Close();
        }

        private void btnBANHANG_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    FormBorderStyle = FormBorderStyle.None;
            //    WindowState = FormWindowState.Maximized;
            //    TopMost = true;
            //}
        }
    }
}
