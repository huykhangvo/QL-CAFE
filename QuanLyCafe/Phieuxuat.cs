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
    public partial class Phieuxuat : Form
    {
        public Phieuxuat()
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
        ///////////////////////////////////////////////////////////////FUNCTION/////////////////////////////////////////////////////////////
        void ShowCB_PX()
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            String sql = "SELECT MASP,TENSP FROM SANPHAM";
            DataTable dt2 = ketnoi.loadDataTable(sql);
            cbLPX_SP.DataSource = dt2;
            cbLPX_SP.ValueMember = "MASP";
            cbLPX_SP.DisplayMember = "TENSP";
            ketnoi.closeConn();
        }

        void ShowPX(string MAPN)
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            String sql = "SELECT TENSP AS N'Tên sản phẩm',CTPX.SL FROM SANPHAM,CTPX WHERE SANPHAM.MASP=CTPX.MASP AND MAPX='"+MAPN+"'";
            DataTable dt2 = ketnoi.loadDataTable(sql);
            dgvLPX.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLPX.DataSource = dt2;
            ketnoi.closeConn();
        }









        private void Phieuxuat_Load(object sender, EventArgs e)
        {
            txtLPX_MPX.Text = QLHeThong.MAPX;
            ShowCB_PX();
        }









        private void dgvLPN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void cbLPX_SP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connection ketnoi = new Connection();
                ketnoi.openConn();
                string sql = "SELECT MASP FROM SANPHAM WHERE TENSP = N'" + cbLPX_SP.Text + "'";
                DataTable dt2 = ketnoi.loadDataTable(sql);
                txtLPX_LSP.Text = dt2.Rows[0][0].ToString();
                ketnoi.closeConn();
            }
            catch (Exception)
            {
            }
        }

        private void btnLPX_Them_Click(object sender, EventArgs e)
        {
            if (txtLPX_SL.Text == "")
            {
                MessageBox.Show("Dữ liệu không được để trống");
            }
            else
            {
                try
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql3 = "SELECT COUNT(*) FROM CTPX,SANPHAM WHERE SANPHAM.MASP=CTPX.MASP AND TENSP=N'" + cbLPX_SP.Text + "' AND MAPX='" + txtLPX_MPX.Text + "'";
                    DataTable dt1 = ketnoi.loadDataTable(sql3);
                    if (dt1.Rows[0][0].ToString() == "1")
                    {
                        MessageBox.Show("Sản phẩm đã tồn tại");
                        ketnoi.closeConn();
                    }
                    else
                    {
                        string sql = "INSERT INTO CTPX VALUES('" + txtLPX_MPX.Text + "','" + txtLPX_LSP.Text + "'," + txtLPX_SL.Text + ")";
                        ketnoi.executeUpdate(sql);
                        ShowPX(txtLPX_MPX.Text);
                        ketnoi.closeConn();
                    }    
                }
                catch (Exception)
                {
                    MessageBox.Show("Số hàng trong kho không đủ");
                }
            }
        }

        private void btnLPX_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLPX_SL.Text == "")
                {
                    MessageBox.Show("Không thể xóa");
                }
                else
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql = "DELETE FROM CTPX WHERE MASP ='" + txtLPX_LSP.Text + "'";
                    ketnoi.executeUpdate(sql);
                    ShowPX(txtLPX_MPX.Text);
                    ketnoi.closeConn();
                    MessageBox.Show("Xóa thành công");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể xóa");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn hủy phiếu xuất?", "Hủy phiếu xuất ", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql = "DELETE FROM PHIEUXUAT WHERE MAPX ='" + txtLPX_MPX.Text + "'";
                    string sql1 = "DELETE FROM CTPX WHERE MAPX ='" + txtLPX_MPX.Text + "'";
                    ketnoi.executeUpdate(sql1);
                    ketnoi.executeUpdate(sql);
                    this.Close();
                    ketnoi.closeConn();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể xóa");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLPX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i;
                i = dgvLPX.CurrentRow.Index;
                Connection ketnoi = new Connection();
                ketnoi.openConn();
                string sql = "SELECT MASP FROM SANPHAM WHERE TENSP='" + dgvLPX.Rows[i].Cells[0].Value.ToString() + "'";
                DataTable dt = ketnoi.loadDataTable(sql);
                ketnoi.closeConn();
                cbLPX_SP.Text = dgvLPX.Rows[i].Cells[0].Value.ToString();
                txtLPX_LSP.Text = dt.Rows[0][0].ToString();
                txtLPX_SL.Text = dgvLPX.Rows[i].Cells[1].Value.ToString();
            }
            catch (Exception)
            {
                txtLPX_LSP.Text = "";
                txtLPX_SL.Text = "";
                cbLPX_SP.Text = "";
            }
        }
    }
}
