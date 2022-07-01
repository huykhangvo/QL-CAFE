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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            LoadListViewkho();
        }
        void LoadListViewkho()
        {
            listView2.View = View.Details;
            listView2.GridLines = true;
            listView2.FullRowSelect = true;

            //Thêm tiêu đề cho cột

            listView2.Columns.Add("Mã sản phẩm", 100);
            listView2.Columns.Add("Tên sản phẩm", 70);
            listView2.Columns.Add("Mã nhà sản xuất", 70);
            listView2.Columns.Add("Đơn vị tính", 70);
            listView2.Columns.Add("Số lượng", 70);
            listView2.Columns.Add("Giá", 70);
            


        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form6 frm6 = new Form6();
            frm6.Show();
        }

 

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

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




        ////////////////////////////////////////////////////////////FUNCTION/////////////////////////////////////////////////////////
        void ShowNV()
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            String sql = "SELECT * FROM NHANVIEN";
            DataTable dt2 = ketnoi.loadDataTable(sql);
            dgv_NV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_NV.DataSource = dt2;
            ketnoi.closeConn();
        }

        void ShowSP()
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            String sql = "SELECT * FROM MON";
            DataTable dt2 = ketnoi.loadDataTable(sql);
            dgvSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSP.DataSource = dt2;
            ketnoi.closeConn();
        }

        void ShowCB_SP()
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            String sql = "SELECT MALOAI,TENLOAI FROM LOAIMON";
            DataTable dt2 = ketnoi.loadDataTable(sql);
            cbSP_LSP.DataSource = dt2;
            cbSP_LSP.ValueMember = "MALOAI";
            cbSP_LSP.DisplayMember = "MALOAI";
            ketnoi.closeConn();
        }

        void ShowCB_LTLSP()
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            String sql = "SELECT MALOAI,TENLOAI FROM LOAIMON";
            DataTable dt2 = ketnoi.loadDataTable(sql);
            cbSP_LTLSP.DataSource = dt2;
            cbSP_LTLSP.ValueMember = "MALOAI";
            cbSP_LTLSP.DisplayMember = "TENLOAI";
            ketnoi.closeConn();
        }
















        private void Form4_Load(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            ShowNV();
            ketnoi.closeConn();
            ShowCB_SP();
            ShowSP();
            ShowCB_LTLSP();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textNV_MANV.Text == "" || textNV_HT.Text == "" || textNV_SDT.Text == "" || textNV_TK.Text == "" || textNV_DC.Text == "")
                {
                    MessageBox.Show("Dữ liệu không được bỏ trống!");
                }
                else
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string manv = textNV_MANV.Text;
                    string ht = textNV_HT.Text;
                    string gt = cbNV_GT.Text;
                    string ns = dtpNV_NS.Text;
                    string sdt = textNV_SDT.Text;
                    string tk = textNV_TK.Text;
                    string cv = cbNV_CV.Text;
                    string dc = textNV_DC.Text;
                    string sql = "INSERT INTO NHANVIEN(MANV,TENNV,GIOITINH,NGAYSINH,SDT,TAIKHOAN,CHUCVU,DIACHI) VALUES('" + manv + "',N'" + ht + "',N'" + gt + "','" + ns + "','" + sdt + "','" + tk + "',N'" + cv + "',N'" + dc + "')";
                    ketnoi.executeUpdate(sql);
                    ShowNV();
                    ketnoi.closeConn();
                    MessageBox.Show("Thêm thành công");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể thêm");
            } 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Connection ketnoi = new Connection();
                ketnoi.openConn();
                string sql = "DELETE FROM NHANVIEN WHERE MANV='" + textNV_MANV.Text + "'";
                ketnoi.executeUpdate(sql);
                ShowNV();
                ketnoi.closeConn();
                MessageBox.Show("Xóa thành công");
            }
            catch (Exception)
            {

                MessageBox.Show("Không thể xóa");
            }
        }

        private void dgv_NV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textNV_MANV.ReadOnly = true;
            int i;
            i = dgv_NV.CurrentRow.Index;
            textNV_MANV.Text = dgv_NV.Rows[i].Cells[0].Value.ToString();
            textNV_HT.Text = dgv_NV.Rows[i].Cells[1].Value.ToString();
            cbNV_GT.Text = dgv_NV.Rows[i].Cells[2].Value.ToString();
            dtpNV_NS.Text = dgv_NV.Rows[i].Cells[3].Value.ToString();
            textNV_SDT.Text = dgv_NV.Rows[i].Cells[4].Value.ToString();
            textNV_TK.Text = dgv_NV.Rows[i].Cells[5].Value.ToString();
            cbNV_CV.Text = dgv_NV.Rows[i].Cells[7].Value.ToString();
            textNV_DC.Text = dgv_NV.Rows[i].Cells[8].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textNV_MANV.Clear();
            textNV_HT.Clear();
            textNV_SDT.Clear();
            textNV_TK.Clear();
            textNV_DC.Clear();
            ShowNV();
            textNV_MANV.ReadOnly = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Connection ketnoi = new Connection();
                ketnoi.openConn();
                string sql = "UPDATE NHANVIEN SET TENNV=N'" + textNV_HT.Text + "', GIOITINH=N'"+cbNV_GT.Text+"', NGAYSINH='"+dtpNV_NS.Text+"', SDT='"+textNV_SDT.Text+"', TAIKHOAN='"+textNV_TK.Text+"', CHUCVU=N'"+cbNV_CV.Text+"', DIACHI=N'"+textNV_DC.Text+"' WHERE MANV='"+textNV_MANV.Text+"'";
                ketnoi.executeUpdate(sql);
                ShowNV();
                ketnoi.closeConn();
            }
            catch (Exception)
            {

                MessageBox.Show("Erro!");
            }
        }

        private void cbSP_LTLSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*try
            {
                Connection ketnoi = new Connection();
                ketnoi.openConn();
                string lsp = cbSP_LTLSP.Text;
                string sql = "SELECT MAMON,TENMON,MON.MALOAI,DONGIA FROM MON,LOAIMON WHERE LOAIMON.TENLOAI='" + lsp + "' and MON.MALOAI = LOAIMON.MALOAI";
                DataTable dt2 = ketnoi.loadDataTable(sql);
                dgvSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvSP.DataSource = dt2;
                ketnoi.closeConn();
            }
            catch (Exception)
            {

                MessageBox.Show("Erro!");
            }*/
        }

        private void cbSP_LTLSP_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSP_TM_Click(object sender, EventArgs e)
        {
            try
            {
                if (textSP_MASP.Text == "" || textSP_TSP.Text == "" || textSP_DG.Text == "")
                {
                    MessageBox.Show("Dữ liệu không được bỏ trống!");
                }
                else
                {              
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql = "INSERT INTO MON VALUES ('"+textSP_MASP.Text+"',N'"+textSP_TSP.Text+"','"+cbSP_LSP.Text+"',"+ textSP_DG.Text + ")";
                    ketnoi.executeUpdate(sql);
                    ShowSP();
                    ketnoi.closeConn();
                    MessageBox.Show("Thêm thành công");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể thêm");
            }
        }

        private void cbSP_LSP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSP_CS_Click(object sender, EventArgs e)
        {
            /*try
            {*/
                Connection ketnoi = new Connection();
                ketnoi.openConn();
                string sql = "UPDATE MON SET TENMON=N'"+textSP_TSP.Text+"',MALOAI='"+cbSP_LSP.Text+"',DONGIA="+textSP_DG.Text+" WHERE MAMON='"+textSP_MASP.Text+"'";
                ketnoi.executeUpdate(sql);
                ShowSP();
                ketnoi.closeConn();/*
            }
            catch (Exception)
            {

                MessageBox.Show("Erro!");
            }*/
        }

        private void dgvSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textSP_MASP.ReadOnly = true;
            int i;
            i = dgvSP.CurrentRow.Index;
            textSP_MASP.Text = dgvSP.Rows[i].Cells[0].Value.ToString();
            textSP_TSP.Text = dgvSP.Rows[i].Cells[1].Value.ToString();
            cbSP_LSP.Text = dgvSP.Rows[i].Cells[2].Value.ToString();
            textSP_DG.Text = dgvSP.Rows[i].Cells[3].Value.ToString();
        }

        private void btnSP_XSP_Click(object sender, EventArgs e)
        {
            try
            {
                Connection ketnoi = new Connection();
                ketnoi.openConn();
                string sql = "DELETE FROM MON WHERE MAMON='" + textSP_MASP.Text + "'";
                ketnoi.executeUpdate(sql);
                ShowSP();
                ketnoi.closeConn();
                MessageBox.Show("Xóa thành công");
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể xóa");
            }
        }

        private void btnSP_LM_Click(object sender, EventArgs e)
        {
            textSP_MASP.Clear();
            textSP_TSP.Clear();
            textSP_DG.Clear();
            textSP_MASP.ReadOnly = false;
        }
    }
}
