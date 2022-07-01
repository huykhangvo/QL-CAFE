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
    public partial class HoaDon : Form
    {
        public HoaDon()
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



        private void Form7_Load(object sender, EventArgs e)
        {         
            txtHD_MaHD.Text = QLBanHang.MAHD;
            Connection ketnoi = new Connection();
            ketnoi.openConn();

            //string sql = "SELECT THANHTIEN FROM CTHD WHERE MAHD='" + txtHD_MaHD.Text + "'";
            //DataTable dt = ketnoi.loadDataTable(sql);

            //float thanhtien = Convert.ToSingle(dt.Rows[0][0]);
            //float giamgia = thanhtien * (QLBanHang.GG / 100);

            string sql1 = "SELECT * FROM CTHD,HOADON,MON,NHANVIEN WHERE HOADON.MAHD='"+txtHD_MaHD.Text+"' AND MON.MAMON=CTHD.MAMON AND NHANVIEN.MANV=HOADON.MANV AND CTHD.MAHD=HOADON.MAHD";
            DataTable dt1 = ketnoi.loadDataTable(sql1);

            RPTTHD RPHoaDon = new RPTTHD();
            RPHoaDon.SetDataSource(dt1);
            crHD.ReportSource = RPHoaDon;
            ketnoi.closeConn();
        }
    }
}
