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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.Text.Length == 0 || txtTaiKhoan.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tài khoản hoặc mật khẩu");
            }
            else
            {
                //MessageBox.Show("Đăng nhập thành công");
                Form2 frm2 = new Form2();
                frm2.Show();
            }
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            string txt = txtMatKhau.Text;
            txtMatKhau.PasswordChar = '*';
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                MessageBox.Show("The Caps Lock key is ON.");
            }
        }

        private void cbHienthiMK_CheckedChanged(object sender, EventArgs e)
        {
            string msg = txtMatKhau.Text;

            if (cbHienthiMK.Checked == true)
            {
                txtMatKhau.PasswordChar = (char)0;
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = (MessageBox.Show("Bạn có muốn thoát?", "Note", MessageBoxButtons.YesNo, MessageBoxIcon.Warning));
            if (thongbao == DialogResult.Yes)
                Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
