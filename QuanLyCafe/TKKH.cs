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
    public partial class TKKH : Form
    {
        public TKKH()
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
        private void button1_Click(object sender, EventArgs e)
        {
            string str = "";
            try
            {
                Connection ketnoi = new Connection();
                ketnoi.openConn();
                string sql = "SELECT MAX(ID) FROM KHACHHANG";
                DataTable dt = ketnoi.loadDataTable(sql);
                ketnoi.closeConn();
                str = "KH" + (Convert.ToInt32(dt.Rows[0][0].ToString()) + 1);
            }
            catch (Exception)
            {

                str = "KH1";
            }

            if (txtTKH.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Dữ liệu không được để trống");
            }
            else
            {
                try
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql = "INSERT INTO KHACHHANG VALUES ('" + str + "',N'" + txtTKH.Text + "','" + txtSDT.Text + "')";
                    ketnoi.executeUpdate(sql);
                    ketnoi.closeConn();
                    MessageBox.Show("Tạo tài khoản thành công");
                    txtTKH.Clear();
                    txtSDT.Clear();
                }
                catch (Exception)
                {
                    MessageBox.Show("Số điện thoại đã tồn tại");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
