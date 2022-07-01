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
    public partial class QLBanHang : Form
    {
        public QLBanHang()
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

        /// <summary>
        /// ///////////////////////////////////////////////////// function
        /// </summary> 
        void ShowResult(Panel pnl, Label lb)
        {
            RadioButton rdb = null;

            
            if(rdb != null)
            {
                pnl.Text = rdb.Text;
                lb.Text = pnl.Text;
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (check == 1)
            {
                MessageBox.Show("Bạn chưa hoàn thành hóa đơn");
            }
            else
            {
                Application.Exit();
            }
            
        }
        private void show_dgv()
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            string lsp = cbbLoainuoc.Text;
            string sql = "SELECT TENMON AS N'Tên món',TENLOAI AS N'Tên loại',DONGIA AS N'Đơn giá' FROM MON,LOAIMON WHERE LOAIMON.TENLOAI=N'" + lsp + "' and MON.MALOAI = LOAIMON.MALOAI";
            DataTable dt2 = ketnoi.loadDataTable(sql);
            dgv_menu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_menu.DataSource = dt2;
            ketnoi.closeConn();
        }

        void ShowCB_Loainuoc()
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            String sql = "SELECT TENLOAI FROM LOAIMON";
            DataTable dt2 = ketnoi.loadDataTable(sql);
            cbbLoainuoc.DataSource = dt2;
            cbbLoainuoc.DisplayMember = "TENLOAI";
            ketnoi.closeConn();
        }

        void showLB_Tenban(Label lb, Panel pnl)
        {
            RadioButton rdo = null;
            foreach(RadioButton item in pnl.Controls)
            {
                if(item != null)
                    if (item.Checked)
                    {
                        rdo = item;
                        break;
                    }
            }
            if (rdo != null)
                lb.Text = rdo.Text;
        }

        private void Show_HD()
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();              
            string sql = "SELECT TENMON AS N'Tên món',SL AS N'Số lượng',MON.DONGIA AS N'Đơn giá', THANHTIEN AS N'Thành tiền' FROM CTHD,MON WHERE MON.MAMON = CTHD.MAMON AND MAHD='" + txt_Mahoadon.Text + "'";
            DataTable dt2 = ketnoi.loadDataTable(sql);
            dgvHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHD.DataSource = dt2;
            ketnoi.closeConn();
        }

        void ShowQL_Mon()
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            string sql = "SELECT TENMON AS N'Tên món',TENLOAI AS N'Tên loại',DONGIA AS N'Đơn giá' FROM MON,LOAIMON WHERE MON.MALOAI = LOAIMON.MALOAI";
            DataTable dt = ketnoi.loadDataTable(sql);
            dgv_menu.DataSource = dt;
            dgv_menu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ketnoi.closeConn();
        }









        private void Form3_Load(object sender, EventArgs e)
        {
            txt_TenNV.Text = DangNhap.Tennhanvien;
            
            ShowCB_Loainuoc();
            show_dgv();
            ShowQL_Mon();


        }


        private void timer1_Tick(object sender, EventArgs e)
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ShowResult(pnl_Soban, lbSoban);

            
        }
        public static string MAHD;
        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            if (txt_ThanhTien.Text == "")
            {
                MessageBox.Show("Vui lòng chọn món");
            }
            else
            {
                button7.Enabled = false;
                check = 0;
                float giamgia;
                Connection ketnoi = new Connection();
                ketnoi.openConn();
                string sql = "SELECT SUM(THANHTIEN) FROM CTHD WHERE MAHD='" + txt_Mahoadon.Text + "'";
                DataTable dt = ketnoi.loadDataTable(sql);

                if (txtQL_HOTENKH.Text == "")
                {
                    giamgia = 0;
                }
                else
                {
                    giamgia = Convert.ToSingle(dt.Rows[0][0]) * 0.1f;
                }

                string sql1 = "UPDATE HOADON SET GIAMGIA='" + giamgia + "',TONGTIEN='" + (Convert.ToInt32(dt.Rows[0][0].ToString()) - giamgia) + "' WHERE MAHD='" + txt_Mahoadon.Text + "'";
                ketnoi.executeUpdate(sql1);
                ketnoi.closeConn();
                button5.Enabled = false;
                button6.Enabled = false;
                btn_KtraTTKH.Enabled = false;
                MAHD = txt_Mahoadon.Text;

                HoaDon frm7 = new HoaDon();
                frm7.ShowDialog();
            }
        }

        private void lbSoban_Click(object sender, EventArgs e)
        { 
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            lbSoban.Text = radioButton3.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            lbSoban.Text = radioButton2.Text;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           lbSoban.Text = radioButton1.Text;
        }
        private void lbDanhmuc_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (check == 1)
            {
                MessageBox.Show("Bạn chưa hoàn thành hóa đơn");
            }
            else
            if (DangNhap.Chucvu.Equals("Nhân viên"))
            {
                this.Hide();
                DangNhap frm1 = new DangNhap();
                frm1.ShowDialog();
            }
            else
            {
                this.Hide();
                QuanLi ql = new QuanLi();
                ql.ShowDialog();
            }
        }

        private void listviewDmsp_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMahoadon_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
      
        }

        private void cbbLoainuoc_SelectedIndexChanged(object sender, EventArgs e)
        {


            try
            {
                Connection ketnoi = new Connection();
                ketnoi.openConn();
                string lsp = cbbLoainuoc.Text;
                string sql = "SELECT TENMON AS N'Tên món',TENLOAI AS N'Tên loại',DONGIA AS N'Đơn giá' FROM MON,LOAIMON WHERE LOAIMON.TENLOAI=N'" + lsp + "' and MON.MALOAI = LOAIMON.MALOAI";
                DataTable dt2 = ketnoi.loadDataTable(sql);
                dgv_menu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_menu.DataSource = dt2;
                ketnoi.closeConn();
            }
            catch (Exception)
            {

                MessageBox.Show("Error!");
            }

           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void radioButton28_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton28_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio.Checked)
                lbSoban.Text = radio.Text;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btn_KtraTTKH_Click(object sender, EventArgs e)
        {
            if (txtQL_SDTKH.Text == "")
            {
                MessageBox.Show("Chưa nhập SDT khách hàng!");
            }
            else
            {
                try
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql = "SELECT * FROM KHACHHANG WHERE SDT ='" + txtQL_SDTKH.Text + "'";
                    DataTable dt = ketnoi.loadDataTable(sql);
                    ketnoi.closeConn();
                    if (txtQL_SDTKH.Text.Equals(dt.Rows[0][3].ToString()))
                    {
                        txtQL_HOTENKH.Text = dt.Rows[0][2].ToString();
                    }              
                }
                catch (Exception)
                {

                    MessageBox.Show("Khách hàng không tồn tại!");
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void dgv_menu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string MAMON, TENMON;
            int i;
            i = dgv_menu.CurrentRow.Index;
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            try
            {
                string sql = "SELECT MAMON FROM MON WHERE TENMON =N'" + dgv_menu.Rows[i].Cells[0].Value.ToString() + "'";
                DataTable dt = ketnoi.loadDataTable(sql);
                MAMON = dt.Rows[0][0].ToString();
                TENMON = dgv_menu.Rows[i].Cells[0].Value.ToString();
                numericUpDown1.Value = 1;
            }
            catch (Exception)
            {

                MAMON = "";
                TENMON = "";
            }
            txtQL_MAMON.Text = MAMON;
            txtQL_TENMON.Text = TENMON;
            numericUpDown1.Value = 1;
            ketnoi.closeConn();
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            if (check == 1)
            {
                MessageBox.Show("Chưa hoàn thành hóa đơn");
            }
            else
            {
                button7.Enabled = true;
                txtQL_SDTKH.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                btn_KtraTTKH.Enabled = true;
                txt_Mahoadon.Clear();
                txtQL_TENMON.Clear();
                txtQL_MAMON.Clear();
                txtQL_HOTENKH.Clear();
                txtQL_SDTKH.Clear();
                txtQL_Search.Clear();
                txt_ThanhTien.Clear();
                numericUpDown1.Value = 1;
                lbSoban.Text = "0";
                ShowCB_Loainuoc();
                show_dgv();
                ShowQL_Mon();
                Show_HD();
                btnQLBH_LHD.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (check != 1)
            {
                MessageBox.Show("Chưa lập hóa đơn");
            }
            else
            if (txtQL_MAMON.Text == "")
            {
                MessageBox.Show("Chưa chọn món");
            }
            else
            {
                btn_KtraTTKH.Enabled = false;
                btnQLBH_LHD.Enabled = false;
                Connection ketnoi = new Connection();
                ketnoi.openConn();

                string sql = "SELECT COUNT(*) FROM CTHD,MON WHERE MON.MAMON=CTHD.MAMON AND TENMON=N'"+txtQL_TENMON.Text+"' AND MAHD='"+txt_Mahoadon.Text+"'";
                DataTable dt1 = ketnoi.loadDataTable(sql);
                if (dt1.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("Món đã tồn tại");
                    ketnoi.closeConn();
                }
                else
                {
                    string sql5 = "INSERT INTO CTHD(MAHD,MAMON,SL) VALUES ('" + txt_Mahoadon.Text + "','" + txtQL_MAMON.Text + "'," + numericUpDown1.Value + ")";
                    ketnoi.executeUpdate(sql5);

                    string sql3 = "UPDATE CTHD SET DONGIA= MON.DONGIA FROM CTHD,MON WHERE CTHD.MAMON = MON.MAMON AND MAHD ='" + txt_Mahoadon.Text + "'";
                    ketnoi.executeUpdate(sql3);

                    string sql4 = "UPDATE CTHD SET THANHTIEN = SL*DONGIA WHERE MAHD='" + txt_Mahoadon.Text + "'";
                    ketnoi.executeUpdate(sql4);

                    string sql1 = "SELECT SUM(THANHTIEN) FROM CTHD WHERE MAHD='" + txt_Mahoadon.Text + "'";
                    DataTable dt = ketnoi.loadDataTable(sql1);
                    txt_ThanhTien.Text = dt.Rows[0][0].ToString();
                    ketnoi.closeConn();
                    numericUpDown1.Value = 1;
                    Show_HD();
                }        
            }
        }
        int check = 0;
        private void button7_Click(object sender, EventArgs e)
        {
            if (lbSoban.Text == "0")
            {
                MessageBox.Show("Chưa chọn bàn");
            }
            else
            {
                string str = "";
                try
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql = "SELECT MAX(ID) FROM HOADON";
                    DataTable dt = ketnoi.loadDataTable(sql);
                    ketnoi.closeConn();
                    str = "HD" + (Convert.ToInt32(dt.Rows[0][0].ToString()) + 1);
                }
                catch (Exception)
                {

                    str = "HD1";
                }
                txt_Mahoadon.Text = str;

                try
                {
                    string MAKH;
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();

                    string sql = "SELECT MANV FROM NHANVIEN WHERE TENNV = N'" + txt_TenNV.Text + "'";
                    DataTable dt = ketnoi.loadDataTable(sql);

                    try
                    {
                        string sql1 = "SELECT MAKH FROM KHACHHANG WHERE SDT = '" + txtQL_SDTKH.Text + "'";
                        DataTable dt1 = ketnoi.loadDataTable(sql1);
                        MAKH = dt1.Rows[0][0].ToString();
                    }
                    catch (Exception)
                    {
                        MAKH = "";
                    }

                    string sql2 = "INSERT INTO HOADON(MAHD,MANV,MAKH,SOBAN,NGAYBAN) VALUES ('" + txt_Mahoadon.Text + "','" + dt.Rows[0][0].ToString() + "','" + MAKH + "'," + lbSoban.Text + ",'" + dateTimePicker1.Text + "')";
                    ketnoi.executeUpdate(sql2);
                    ketnoi.closeConn();
                    MessageBox.Show("Lập hóa đơn thành công");
                    txtQL_SDTKH.Enabled = false;
                    check = 1;
                    btnQLBH_LHD.Enabled = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Mã hóa đơn đã tồn tại");
                }
            }

        }

        private void dgvHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string MAMON, TENMON;
            int i;
            i = dgvHD.CurrentRow.Index;
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            try
            {
                string sql = "SELECT MAMON FROM MON WHERE TENMON =N'" + dgvHD.Rows[i].Cells[0].Value.ToString() + "'";
                DataTable dt = ketnoi.loadDataTable(sql);
                MAMON = dt.Rows[0][0].ToString();
                TENMON = dgvHD.Rows[i].Cells[0].Value.ToString();
            }
            catch (Exception)
            {

                MAMON = "";
                TENMON = "";
            }
            txtQL_MAMON.Text = MAMON;
            txtQL_TENMON.Text = TENMON;
            ketnoi.closeConn();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Connection ketnoi = new Connection();
                ketnoi.openConn();
                string sql = "DELETE FROM CTHD WHERE MAMON='" + txtQL_MAMON.Text + "'";
                ketnoi.executeUpdate(sql);
                string sql1 = "SELECT SUM(THANHTIEN) FROM CTHD WHERE MAHD='" + txt_Mahoadon.Text + "'";
                DataTable dt = ketnoi.loadDataTable(sql1);
                txt_ThanhTien.Text = dt.Rows[0][0].ToString();
                ketnoi.closeConn();
                Show_HD();
            }
            catch (Exception)
            {

                MessageBox.Show("Không thể xóa");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowQL_Mon();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            
            string sql = "SELECT TENMON AS N'Tên món',TENLOAI AS N'Tên loại',DONGIA AS N'Đơn giá' FROM MON,LOAIMON WHERE TENMON like N'%"+txtQL_Search.Text+"%' and MON.MALOAI = LOAIMON.MALOAI";
            DataTable dt = ketnoi.loadDataTable(sql);
            dgv_menu.DataSource = dt;
            dgv_menu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ketnoi.closeConn();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LSGiaodich lsgd = new LSGiaodich();
            lsgd.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtQL_MAMON_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtQL_TENMON_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtQL_Search_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtQL_SDTKH_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQL_HOTENKH_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_ThanhTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if (txt_Mahoadon.Text == "")
            {
                MessageBox.Show("Không có hóa đơn");
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn hóa đơn?", "Hủy hóa đơn ", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql = "DELETE CTHD WHERE MAHD='"+txt_Mahoadon.Text+"'";
                    string sql1 = "DELETE HOADON WHERE MAHD='" + txt_Mahoadon.Text + "'";

                    ketnoi.executeUpdate(sql);
                    ketnoi.executeUpdate(sql1);
                    ketnoi.closeConn();

                    txtQL_SDTKH.Enabled = true;
                    button5.Enabled = true;
                    button6.Enabled = true;
                    btn_KtraTTKH.Enabled = true;
                    txt_Mahoadon.Clear();
                    txtQL_TENMON.Clear();
                    txtQL_MAMON.Clear();
                    txtQL_HOTENKH.Clear();
                    txtQL_SDTKH.Clear();
                    txtQL_Search.Clear();
                    txt_ThanhTien.Clear();
                    numericUpDown1.Value = 1;
                    lbSoban.Text = "0";
                    ShowCB_Loainuoc();
                    show_dgv();
                    ShowQL_Mon();
                    Show_HD();
                    check = 0;
                    btnQLBH_LHD.Enabled = true;
                }    
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            TKKH kh = new TKKH();
            kh.ShowDialog();
        }
    }
}
