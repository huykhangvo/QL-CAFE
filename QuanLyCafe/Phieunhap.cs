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
    public partial class Phieunhap : Form
    {
        public Phieunhap()
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
        ///////////////////////////////////////////////////////////////FUNCTION///////////////////////////////////////////////////
        void ShowCB_PN()
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            string sql = "SELECT MASP,TENSP FROM SANPHAM";
            DataTable dt2 = ketnoi.loadDataTable(sql);
            cbLPN_SP.DataSource = dt2;
            cbLPN_SP.ValueMember = "MASP";
            cbLPN_SP.DisplayMember = "TENSP";
            ketnoi.closeConn();
        }

        void ShowPN(string MAPN)
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            string sql = "SELECT TENSP AS N'Tên sản phẩm',DONGIA AS N'Đơn giá',CTPN.SL AS N'Số lượng',THANHTIEN AS N'Thành tiền' FROM CTPN,SANPHAM WHERE MAPN='"+MAPN+"' AND SANPHAM.MASP = CTPN.MASP";
            DataTable dt2 = ketnoi.loadDataTable(sql);
            dgvLPN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLPN.DataSource = dt2;
            ketnoi.closeConn();
        }

















        private void Phieunhap_Load(object sender, EventArgs e)
        {
            txtLPN_MPN.Text = QLHeThong.MAPN;
            ShowCB_PN();
        }

        private void cbLPN_SP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connection ketnoi = new Connection();
                ketnoi.openConn();
                string sql = "SELECT MASP FROM SANPHAM WHERE TENSP = N'" + cbLPN_SP.Text + "'";
                DataTable dt2 = ketnoi.loadDataTable(sql);
                txtLPN_LSP.Text = dt2.Rows[0][0].ToString();
                ketnoi.closeConn();
            }
            catch (Exception)
            {
            }
        }

        private void dgvLPN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void btnLPN_Them_Click(object sender, EventArgs e)
        {
            if (txtLPN_DG.Text == "" || nudSL.Text == "")
            {
                MessageBox.Show("Dữ liệu không được để trống");
            }
            else
            {
                try
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();

                    string sql3 = "SELECT COUNT(*) FROM CTPN,SANPHAM WHERE SANPHAM.MASP=CTPN.MASP AND TENSP=N'"+cbLPN_SP.Text+"' AND MAPN='"+txtLPN_MPN.Text+"'";
                    DataTable dt1 = ketnoi.loadDataTable(sql3);
                    if (dt1.Rows[0][0].ToString() == "1")
                    {
                        MessageBox.Show("Sản phẩm đã tồn tại");
                        ketnoi.closeConn();
                    }
                    else
                    {
                        string sql = "INSERT INTO CTPN(MAPN,MASP,SL,DONGIA) VALUES('" + txtLPN_MPN.Text + "','" + txtLPN_LSP.Text + "'," + nudSL.Text + "," + txtLPN_DG.Text + ")";
                        string sql1 = "UPDATE CTPN SET THANHTIEN = SL*DONGIA WHERE MAPN = '" + txtLPN_MPN.Text + "'";
                        String sql2 = "SELECT SUM(THANHTIEN) FROM CTPN WHERE MAPN ='" + txtLPN_MPN.Text + "'";
                        ketnoi.executeUpdate(sql);
                        ketnoi.executeUpdate(sql1);
                        DataTable dt = ketnoi.loadDataTable(sql2);
                        txtPN_TC.Text = dt.Rows[0][0].ToString();
                        nudSL.Value = 1;
                        txtLPN_DG.Text = "";
                        ShowPN(txtLPN_MPN.Text);
                        ketnoi.closeConn();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể thêm");
                }
            }
        }

        private void btnLPN_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLPN_DG.Text == "")
                {
                    MessageBox.Show("Không thể xóa");
                }
                else
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql = "DELETE FROM CTPN WHERE MASP ='" + txtLPN_LSP.Text + "'";
                    ketnoi.executeUpdate(sql);
                    ShowPN(txtLPN_MPN.Text);
                    string sql2 = "SELECT SUM(THANHTIEN) FROM CTPN WHERE MAPN ='" + txtLPN_MPN.Text + "'";
                    DataTable dt = ketnoi.loadDataTable(sql2);
                    txtPN_TC.Text = dt.Rows[0][0].ToString();
                    ShowPN(txtLPN_MPN.Text);
                    ketnoi.closeConn();
                    nudSL.Value = 1;
                    txtLPN_DG.Text = "";
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
            DialogResult result = MessageBox.Show("Bạn có chắc muốn hủy phiếu nhập?", "Hủy phiếu nhập ", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql = "DELETE FROM PHIEUNHAP WHERE MAPN ='" + txtLPN_MPN.Text + "'";
                    string sql1 = "DELETE FROM CTPN WHERE MAPN ='" + txtLPN_MPN.Text + "'";
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
            MessageBox.Show("Lập phiếu thành công");
            this.Close();
        }

        private void dgvLPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i;
                i = dgvLPN.CurrentRow.Index;
                cbLPN_SP.Text = dgvLPN.Rows[i].Cells[0].Value.ToString();
                Connection ketnoi = new Connection();
                ketnoi.openConn();
                string sql = "SELECT MASP FROM SANPHAM WHERE TENSP='" + cbLPN_SP.Text + "'";
                DataTable dt = ketnoi.loadDataTable(sql);
                ketnoi.closeConn();
                txtLPN_LSP.Text = dt.Rows[0][0].ToString();
                nudSL.Value = Convert.ToInt32(dgvLPN.Rows[i].Cells[2].Value.ToString());
                txtLPN_DG.Text = dgvLPN.Rows[i].Cells[1].Value.ToString();
            }
            catch (Exception)
            {
                txtPN_TC.Text = "";
                txtLPN_LSP.Text = "";
                txtLPN_DG.Text = "";
            }
        }
    }
}
