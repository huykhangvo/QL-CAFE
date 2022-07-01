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
    public partial class LSGiaodich : Form
    {
        public LSGiaodich()
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
        void ShowLSGD()
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            string sql = "SELECT TENNV AS N'Tên nhân viên',HOADON.MANV AS N'Mã số nhân viên',MAHD AS N'Mã hóa đơn',SOBAN AS N'Số bàn' FROM HOADON,NHANVIEN WHERE NHANVIEN.MANV=HOADON.MANV ORDER BY HOADON.NGAYBAN DESC";
            DataTable dt = ketnoi.loadDataTable(sql);
            ketnoi.closeConn();
            dgvLSGD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLSGD.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_Mahoadon.Text == "")
            {
                MessageBox.Show("Chwa chọn hóa đơn");
            }
            else
            {
                QLBanHang.MAHD = txt_Mahoadon.Text;
                HoaDon frm7 = new HoaDon();
                frm7.ShowDialog();
            }
            
        }

        private void dgvLSGD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvLSGD.CurrentRow.Index;
            txt_Mahoadon.Text = dgvLSGD.Rows[i].Cells[2].Value.ToString();
        }

        private void LSGiaodich_Load(object sender, EventArgs e)
        {
            ShowLSGD();
        }
    }
}
