using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyCafe
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        class Connection
        {
            private string strConn = @"Data Source=TAIPHACUA\SQLEXPRESS;Initial Catalog=QUANLYCAFE;Integrated Security=True";
            public SqlConnection conn { get; set; }
            public SqlCommand cmd { get; set; }
            public SqlDataReader drd { get; set; }
            public SqlDataAdapter da { get; set; }
            //constructor
            public Connection()
            {
                conn = new SqlConnection(strConn);
                cmd = null;
                drd = null;
                da = null;
            }
            public bool openConn()
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            //Đóng kết nối đến nguồn dữ liệu
            public bool closeConn()
            {
                try
                {
                    conn.Close();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            ////Mô hình kết nối////
            //Đổ dữ liệu từ CSDL -> DataReader -> Client đọc
            public SqlDataReader executeSQL(string sql)
            {
                cmd = new SqlCommand(sql, conn);
                drd = cmd.ExecuteReader();
                return drd;
            }
            //Cập nhật dữ liệu theo mô hình kết nối
            public int executeUpdate(string sql)
            {
                cmd = new SqlCommand(sql, conn);
                return cmd.ExecuteNonQuery();
            }
            ////Mô hình ngắt kết nối/////
            //Đổ dữ liệu từ CSDL -> DataAdapter -> DataTable
            //(DataSet-Client)
            public DataTable loadDataTable(string sql)
            {
                cmd = new SqlCommand(sql, conn);
                da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            //Cập nhật dữ liệu từ DataTable vào CSDL qua DataAdapter
            //(tương đồng bảng)
            public void UpdateTable(DataTable dt)
            {
                SqlCommandBuilder scb = new SqlCommandBuilder(da);
                da.Update(dt);
            }
        }
        public static string Taikhoan,Chucvu,Tennhanvien;
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.Text.Length == 0 || txtTaiKhoan.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tài khoản hoặc mật khẩu");
            }
            else
            {
                Connection ketnoi = new Connection();
                ketnoi.openConn();
                string sql = "SELECT COUNT(*) FROM NHANVIEN WHERE TAIKHOAN='" + txtTaiKhoan.Text + "' AND MATKHAU='" + txtMatKhau.Text + "'";
                DataTable dt = ketnoi.loadDataTable(sql);
                ketnoi.closeConn();
                if (dt.Rows[0][0].ToString() == "1")
                {
                    Taikhoan = txtTaiKhoan.Text;
                    QuanLi QL = new QuanLi();
                    ketnoi.openConn();
                    string sql1 = "SELECT CHUCVU FROM NHANVIEN WHERE TAIKHOAN='" + txtTaiKhoan.Text + "' AND MATKHAU='" + txtMatKhau.Text + "'";
                    DataTable dt1 = ketnoi.loadDataTable(sql1);
                    ketnoi.closeConn();
                    if (dt1.Rows[0][0].ToString().Equals("Quản lý"))
                    {
                        Chucvu = "Quản lý";
                        this.Hide();
                        QL.Show();
                    }
                    else
                    {
                        Chucvu = "Nhân viên";
                        this.Hide();
                        QLBanHang qLBanHang = new QLBanHang();
                        qLBanHang.Show();
                    }
                    ketnoi.openConn();
                    string sql2 = "SELECT TENNV FROM NHANVIEN WHERE TAIKHOAN='" + txtTaiKhoan.Text + "' AND MATKHAU='" + txtMatKhau.Text + "'";
                    DataTable dt2 = ketnoi.loadDataTable(sql2);
                    ketnoi.closeConn();
                    Tennhanvien = dt2.Rows[0][0].ToString();
                    

                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác");
                }
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

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMK dmk = new DoiMK();
            dmk.ShowDialog();
        }

        private void txtTaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {  
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void DangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void txtTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
