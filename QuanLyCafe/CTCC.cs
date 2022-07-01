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
    public partial class CTCC : Form
    {
        public CTCC()
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
        public static string NCC;
        private void CTCC_Load(object sender, EventArgs e)
        {
            txtCTCC_MaCC.Text = QLHeThong.MACC;
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            string sql = "SELECT TENNV FROM NHANVIEN WHERE MANV='"+QLHeThong.MAQL+"'";
            DataTable dt = ketnoi.loadDataTable(sql);
            txtCTCC_NCC.Text = dt.Rows[0][0].ToString();
            NCC = txtCTCC_NCC.Text;
            string sql1 = "SELECT CTCC.MANV+' - '+TENNV AS N'Nhân viên',LUONGTHEONGAY AS N'Lương theo ngày',SONGAYLAM AS N'Số ngày làm', SONGAYNGHI AS N'Số ngày nghỉ', TAMUNG AS N'Tạm ứng',THUONG AS N'Thưởng',PHAT AS N'Phạt',GHICHU AS N'Ghi chú',THUCLANH AS N'Thực lãnh' FROM CTCC, NHANVIEN WHERE CTCC.MANV = NHANVIEN.MANV AND MACC = '" + txtCTCC_MaCC.Text + "'";
            DataTable dt1 = ketnoi.loadDataTable(sql1);
            dgvCTCC.DataSource = dt1;
            dgvCTCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ketnoi.closeConn();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            BaoCaoChamCong BCChamCong = new BaoCaoChamCong();
            BCChamCong.ShowDialog();
        }
    }
}
