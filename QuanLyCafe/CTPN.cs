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
    public partial class CTPN : Form
    {
        public CTPN()
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
        //////////////////////////////////////////////////////////////////FUNCTION//////////////////////////////////////////////////////////////////////

        void ShowCTPN()
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            string sql = "SELECT TENSP AS N'Tên sản phẩm',DONGIA AS N'Đơn giá',CTPN.SL AS N'Số lượng',THANHTIEN AS N'Thành tiền' FROM CTPN,SANPHAM WHERE MAPN='"+ QLHeThong.CTPN_MAPN + "' AND SANPHAM.MASP = CTPN.MASP";
            DataTable dt2 = ketnoi.loadDataTable(sql);
            dgvCTPN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCTPN.DataSource = dt2;
            ketnoi.closeConn();
        }
        private void CTPN_Load(object sender, EventArgs e)
        {

            txtCTPN_MAPN.Text = QLHeThong.CTPN_MAPN;
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            String sql2 = "SELECT SUM(THANHTIEN) FROM CTPN WHERE MAPN ='" + txtCTPN_MAPN.Text + "'";
            string sql1 = "UPDATE CTPN SET THANHTIEN = SL*DONGIA WHERE MAPN = '" + txtCTPN_MAPN.Text + "'";
            string sql = "SELECT TENNV FROM NHANVIEN WHERE MANV='" + QLHeThong.MANV + "'";
            ketnoi.executeUpdate(sql1);
            DataTable dt = ketnoi.loadDataTable(sql2);
            DataTable dt1 = ketnoi.loadDataTable(sql);
            txtCTPN_TC.Text = dt.Rows[0][0].ToString();
            txtCTPN_NN.Text = dt1.Rows[0][0].ToString();
            ketnoi.closeConn();
            ShowCTPN();
        }

    }
}
