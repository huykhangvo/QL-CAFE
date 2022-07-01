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
    public partial class DoiMK : Form
    {
        public DoiMK()
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

        private void btnDMK_DMK_Click(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            string sql = "SELECT COUNT(*) FROM NHANVIEN WHERE TAIKHOAN='"+textDMK_TK.Text+"' AND MATKHAU='"+textDMK_MK.Text+"'";
            DataTable dt = ketnoi.loadDataTable(sql);
            
            if (textDMK_TK.Text =="" || textDMK_MK.Text =="" || textDMK_MKM.Text=="" || textDMK_NLMK.Text =="")
            {
                MessageBox.Show("Dữ liệu không được để trống");
            }
            else
            {
                try
                {
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        if (textDMK_MKM.Text.Equals(textDMK_NLMK.Text))
                        {
                            try
                            {
                                string dmk = "UPDATE NHANVIEN SET MATKHAU='" + textDMK_MKM.Text + "' WHERE TAIKHOAN='" + textDMK_TK.Text + "'";
                                ketnoi.executeUpdate(dmk);
                                MessageBox.Show("Đổi mật khẩu thành công");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Erro!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu mới không khớp");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác");
                }
            }
            ketnoi.closeConn();
        }

        private void btnDMK_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textDMK_MK_TextChanged(object sender, EventArgs e)
        {
            string txt = textDMK_MK.Text;
            textDMK_MK.PasswordChar = '*';
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                MessageBox.Show("The Caps Lock key is ON.");
            }
        }

        private void textDMK_MKM_TextChanged(object sender, EventArgs e)
        {
            string txt = textDMK_MKM.Text;
            textDMK_MKM.PasswordChar = '*';
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                MessageBox.Show("The Caps Lock key is ON.");
            }
        }

        private void textDMK_NLMK_TextChanged(object sender, EventArgs e)
        {
            string txt = textDMK_NLMK.Text;
            textDMK_NLMK.PasswordChar = '*';
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                MessageBox.Show("The Caps Lock key is ON.");
            }
        }
    }
}
