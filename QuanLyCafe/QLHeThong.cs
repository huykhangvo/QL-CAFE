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
    public partial class QLHeThong : Form
    {
        public QLHeThong()
        {
            InitializeComponent();
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
            String sql = "SELECT MANV AS N'Mã nhân viên',TENNV AS N'Họ tên', GIOITINH AS N'Giới tính', NGAYSINH AS N'Ngày sinh', SDT AS 'SĐT',TAIKHOAN AS N'Tài khoản', CHUCVU AS N'Chức vụ', DIACHI AS N'Địa chỉ' FROM NHANVIEN";
            DataTable dt2 = ketnoi.loadDataTable(sql);
            dgv_NV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_NV.DataSource = dt2;
            ketnoi.closeConn();
        }

        void ShowSP()
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            String sql = "SELECT TENMON AS N'Tên món',TENLOAI AS N'Tên Loại',DONGIA AS N'Đơn giá' FROM LOAIMON,MON WHERE MON.MALOAI = LOAIMON.MALOAI";
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
            cbSP_LSP.DisplayMember = "TENLOAI";
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

        void ShowLSP()
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            String sql = "SELECT MALOAI AS N'Mã loại', TENLOAI AS N'Tên loại' FROM LOAIMON";
            DataTable dt2 = ketnoi.loadDataTable(sql);
            dgvLSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLSP.DataSource = dt2;
            ketnoi.closeConn();
        }

        void ShowKH()
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            String sql = "SELECT MAKH AS 'Mã khách hàng', TENKH AS N'Tên khách hàng', SDT AS N'SĐT' FROM KHACHHANG";
            DataTable dt2 = ketnoi.loadDataTable(sql);
            dgvKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKH.DataSource = dt2;
            ketnoi.closeConn();
        }

        void ShowKho()
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            String sql = "SELECT TENSP AS N'Tên sản phẩm', DVT AS N'Đơn vị tính', SL AS N'Số lượng' FROM SANPHAM";
            DataTable dt2 = ketnoi.loadDataTable(sql);
            dgvKHO.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKHO.DataSource = dt2;
            ketnoi.closeConn();
        }

        void ShowPN()
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            String sql = "SELECT MAPN AS N'Mã phiếu nhập',PHIEUNHAP.MANV AS N'Mã nhân viên',TENNV AS N'Tên nhân viên',NGAYNHAP AS N'Ngày nhập' FROM PHIEUNHAP,NHANVIEN WHERE PHIEUNHAP.MANV = NHANVIEN.MANV";
            DataTable dt2 = ketnoi.loadDataTable(sql);
            dgvPN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPN.DataSource = dt2;
            ketnoi.closeConn();
        }

        void ShowCB_MANV()
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            String sql = "SELECT MANV FROM NHANVIEN";
            DataTable dt2 = ketnoi.loadDataTable(sql);
            cbPN_MNV.DataSource = dt2;
            cbPN_MNV.ValueMember = "MANV";
            ketnoi.closeConn();
        }

        void ShowPX()
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            String sql = "SELECT MAPX AS N'Mã phiếu xuất',PHIEUXUAT.MANV AS N'Mã nhân viên',TENNV AS N'Tên nhân viên',NGAYXUAT AS N'Ngày nhập' FROM PHIEUXUAT,NHANVIEN WHERE PHIEUXUAT.MANV = NHANVIEN.MANV";
            DataTable dt2 = ketnoi.loadDataTable(sql);
            dgvPX.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPX.DataSource = dt2;
            ketnoi.closeConn();
        }

        void ShowCB_MANV_PX()
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            String sql = "SELECT MANV FROM NHANVIEN";
            DataTable dt2 = ketnoi.loadDataTable(sql);
            cbPX_MANV.DataSource = dt2;
            cbPX_MANV.ValueMember = "MANV";
            ketnoi.closeConn();
        }

        void Show_dgvBC()
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            string sql = "SELECT CTHD.MAHD AS N'Mã hóa đơn', SUM(TONGTIEN) AS N'Doanh thu bán', NGAYBAN AS N'Ngày bán', TENNV AS N'Nhân viên lập phiếu' FROM CTHD,NHANVIEN,HOADON WHERE HOADON.MANV = NHANVIEN.MANV AND HOADON.MAHD = CTHD.MAHD AND NGAYBAN BETWEEN '"+dtpStart.Text+"' AND '"+dtpEnd.Text+"' GROUP BY CTHD.MAHD , NGAYBAN ,HOADON.MANV, NHANVIEN.TENNV";
            DataTable dt = ketnoi.loadDataTable(sql);
            dgv_bctk.DataSource = dt;
            dgv_bctk.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ketnoi.closeConn();
        }

        void ShowCB_MANV_CC()
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            String sql = "SELECT MANV FROM NHANVIEN WHERE CHUCVU=N'Quản lý'";
            DataTable dt2 = ketnoi.loadDataTable(sql);
            cbCC_MANV.DataSource = dt2;
            cbCC_MANV.ValueMember = "MANV";
            ketnoi.closeConn();
        }

        void ShowCC()
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            String sql = "SELECT MACC AS N'Mã chấm công',CHAMCONG.MANV AS N'Mã nhân viên',TENNV AS N'Tên nhân viên',NGAYCC AS N'Ngày chấm công' FROM CHAMCONG,NHANVIEN WHERE CHAMCONG.MANV = NHANVIEN.MANV";
            DataTable dt2 = ketnoi.loadDataTable(sql);
            dgvCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCC.DataSource = dt2;
            ketnoi.closeConn();
        }



















        private void Form4_Load(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            ShowNV();
            ketnoi.closeConn();
            ShowCB_SP();
            ShowCB_LTLSP();
            ShowSP();          
            ShowLSP();
            ShowKH();
            ShowKho();
            ShowPN();
            ShowPX();
            ShowCB_MANV();
            ShowCB_MANV_PX();
            Show_dgvBC();
            ShowCB_MANV_CC();
            ShowCC();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string str = "";
            try
            {
                Connection ketnoi = new Connection();
                ketnoi.openConn();
                string sql = "SELECT MAX(ID) FROM NHANVIEN";
                DataTable dt = ketnoi.loadDataTable(sql);
                ketnoi.closeConn();
                str = "NV" + (Convert.ToInt32(dt.Rows[0][0].ToString()) + 1);
            }
            catch (Exception)
            {

                str = "NV1";
            }
            textNV_MANV.Text = str;
            if (textNV_MANV.Text == "" || textNV_HT.Text == "" || textNV_SDT.Text == "" || textNV_TK.Text == "" || textNV_DC.Text == "")
            {
                MessageBox.Show("Dữ liệu không được bỏ trống!");
            }
            else
            {
                try
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql = "INSERT INTO NHANVIEN(MANV,TENNV,GIOITINH,NGAYSINH,SDT,TAIKHOAN,CHUCVU,DIACHI) VALUES('" + textNV_MANV.Text + "',N'" + textNV_HT.Text + "',N'" + cbNV_GT.Text + "','" + dtpNV_NS.Text + "','" + textNV_SDT.Text + "','" + textNV_TK.Text + "',N'" + cbNV_CV.Text + "',N'" + textNV_DC.Text + "')";
                    ketnoi.executeUpdate(sql);
                    ShowNV();
                    ketnoi.closeConn();
                    MessageBox.Show("Thêm thành công");
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể thêm");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textNV_MANV.Text == "")
            {
                MessageBox.Show("Mã nhân viên không được để trống");
            }
            else
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
                    textNV_MANV.Clear();
                    textNV_HT.Clear();
                    textNV_SDT.Clear();
                    textNV_TK.Clear();
                    textNV_DC.Clear();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể xóa");
                }
            }
        }

        private void dgv_NV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

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
            if (textNV_MANV.Text == "" || textNV_HT.Text == "" || textNV_SDT.Text == "" || textNV_TK.Text == "" || textNV_DC.Text == "")
            {
                MessageBox.Show("Chưa chọn nhân viên");
            }
            else
            {
                try
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql = "UPDATE NHANVIEN SET TENNV=N'" + textNV_HT.Text + "', GIOITINH=N'" + cbNV_GT.Text + "', NGAYSINH='" + dtpNV_NS.Text + "', SDT='" + textNV_SDT.Text + "', TAIKHOAN='" + textNV_TK.Text + "', CHUCVU=N'" + cbNV_CV.Text + "', DIACHI=N'" + textNV_DC.Text + "' WHERE MANV='" + textNV_MANV.Text + "'";
                    ketnoi.executeUpdate(sql);
                    ShowNV();
                    ketnoi.closeConn();
                    MessageBox.Show("Sửa thành công");
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể sửa");
                }
            }
        }

        private void cbSP_LTLSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSP_TM_Click(object sender, EventArgs e)
        {
            string str = "";
            try
            {
                Connection ketnoi = new Connection();
                ketnoi.openConn();
                string sql = "SELECT MAX(ID) FROM MON";
                DataTable dt = ketnoi.loadDataTable(sql);
                ketnoi.closeConn();
                str = "Mon" + (Convert.ToInt32(dt.Rows[0][0].ToString()) + 1);
            }
            catch (Exception)
            {

                str = "Mon1";
            }
            textSP_MASP.Text = str;
            if (textSP_TSP.Text == "" || textSP_DG.Text == "")
            {
                MessageBox.Show("Dữ liệu không được bỏ trống!");
            }
            else
            {
                try
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql1 = "SELECT MALOAI FROM LOAIMON WHERE TENLOAI =N'"+cbSP_LSP.Text+"'";
                    DataTable dt = ketnoi.loadDataTable(sql1);
                    string sql = "INSERT INTO MON VALUES ('" + str + "',N'" + textSP_TSP.Text + "','" + dt.Rows[0][0].ToString() + "'," + textSP_DG.Text + ")";
                    ketnoi.executeUpdate(sql);
                    ShowSP();
                    ketnoi.closeConn();
                    MessageBox.Show("Thêm thành công");
                }
                catch (Exception)
                {
                    MessageBox.Show("Tên món đã tồn tại");
                }
            }
        }

        private void cbSP_LSP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSP_CS_Click(object sender, EventArgs e)
        {
            if (textSP_TSP.Text == "" || textSP_DG.Text == "")
            {
                MessageBox.Show("Dữ liệu không được bỏ trống");
            }
            else
            {
                try
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql1 = "SELECT MALOAI FROM LOAIMON WHERE TENLOAI =N'" + cbSP_LSP.Text + "'";
                    DataTable dt = ketnoi.loadDataTable(sql1);
                    string sql = "UPDATE MON SET TENMON=N'" + textSP_TSP.Text + "',MALOAI='" + dt.Rows[0][0].ToString() + "',DONGIA=" + textSP_DG.Text + " WHERE MAMON='" + textSP_MASP.Text + "'";
                    ketnoi.executeUpdate(sql);
                    ShowSP();
                    ketnoi.closeConn();
                    MessageBox.Show("Sửa thành công");
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể sửa");
                }
            }
        }

        private void btnSP_XSP_Click(object sender, EventArgs e)
        {
            if (textSP_MASP.Text == "")
            {
                MessageBox.Show("Mã món không được để trống");
            }
            else
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
                    textSP_MASP.Clear();
                    textSP_TSP.Clear();
                    textSP_DG.Clear();
                    textSP_TK.Clear();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể xóa");
                }
            }
        }

        private void btnSP_LM_Click(object sender, EventArgs e)
        {
            textSP_MASP.Clear();
            textSP_TSP.Clear();
            textSP_DG.Clear();
            textSP_TK.Clear();
            textSP_MASP.ReadOnly = false;
            ShowCB_LTLSP();
            ShowCB_SP();
            ShowSP();
        }

        private void dgvLSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnLSP_TM_Click(object sender, EventArgs e)
        {
            string str = "";
            try
            {
                Connection ketnoi = new Connection();
                ketnoi.openConn();
                string sql = "SELECT MAX(ID) FROM LOAIMON";
                DataTable dt = ketnoi.loadDataTable(sql);
                ketnoi.closeConn();
                str = "LM" + (Convert.ToInt32(dt.Rows[0][0].ToString()) + 1);
            }
            catch (Exception)
            {

                str = "LM1";
            }

            textLSP_MSP.Text = str;
            if (textLSP_TSP.Text == "")
            {
                MessageBox.Show("Dữ liệu không được để trống");
            }
            else
            {
                try
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql = "INSERT INTO LOAIMON VALUES('" + str + "',N'" + textLSP_TSP.Text + "')";
                    ketnoi.executeUpdate(sql);
                    ShowLSP();
                    ketnoi.closeConn();
                    MessageBox.Show("Thêm thành công");
                }
                catch (Exception)
                {
                    MessageBox.Show("Tên loại đã tồn tại");
                }
            }
        }

        private void btnLSP_Sua_Click(object sender, EventArgs e)
        {
            if (textLSP_TSP.Text == "")
            {
                MessageBox.Show("Tên loại sản phẩm không được để trống");
            }
            else
            {
                try
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql = "UPDATE LOAIMON SET TENLOAI=N'" + textLSP_TSP.Text + "' WHERE MALOAI='" + textLSP_MSP.Text + "'";
                    ketnoi.executeUpdate(sql);
                    ShowLSP();
                    ketnoi.closeConn();
                    MessageBox.Show("Sửa thành công");
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể sửa");
                }
            }
        }

        private void btnLSP_XSP_Click(object sender, EventArgs e)
        {
            if (textLSP_MSP.Text == "")
            {
                MessageBox.Show("Mã loại không được để trống");
            }
            else
            {
                DialogResult result = MessageBox.Show("Toàn bộ dữ liệu liên quan sẽ bị xóa!", "Hủy phiếu nhập ", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        Connection ketnoi = new Connection();
                        ketnoi.openConn();
                        string sql1 = "DELETE FROM MON WHERE MALOAI ='" + textLSP_MSP.Text + "'";
                        ketnoi.executeUpdate(sql1);
                        string sql = "DELETE FROM LOAIMON WHERE MALOAI ='" + textLSP_MSP.Text + "'";
                        ketnoi.executeUpdate(sql);
                        ShowLSP();
                        ketnoi.closeConn();
                        MessageBox.Show("Xóa thành công");
                        textLSP_MSP.Clear();
                        textLSP_TSP.Clear();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Không thể xóa");
                    }
                }
            }
        }

        private void btnLSP_LM_Click(object sender, EventArgs e)
        {
            textLSP_MSP.ReadOnly = false;
            textLSP_MSP.Clear();
            textLSP_TSP.Clear();
            ShowLSP();
        }

        private void btnKH_Them_Click(object sender, EventArgs e)
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
            textKH_MAKH.Text = str;

            if (textKH_HT.Text == "" || textKH_SDT.Text == "")
            {
                MessageBox.Show("Dữ liệu không được để trống");
            }
            else
            {
                try
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql = "INSERT INTO KHACHHANG VALUES ('" + str + "',N'" + textKH_HT.Text + "','" + textKH_SDT.Text + "')";
                    ketnoi.executeUpdate(sql);
                    ShowKH();
                    ketnoi.closeConn();
                    MessageBox.Show("Thêm thành công");
                }
                catch (Exception)
                {
                    MessageBox.Show("Số điện thoại đã tồn tại");
                }
            }

        }

        private void btnKH_Sua_Click(object sender, EventArgs e)
        {
            if (textKH_HT.Text == "" || textKH_SDT.Text == "")
            {
                MessageBox.Show("Dữ liệu không được bỏ trống");
            }
            else
            {
                try
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql = "UPDATE KHACHHANG SET TENKH=N'" + textKH_HT.Text + "',SDT='" + textKH_SDT.Text + "' WHERE MAKH='" + textKH_MAKH.Text + "'";
                    ketnoi.executeUpdate(sql);
                    ShowKH();
                    ketnoi.closeConn();
                    MessageBox.Show("Sửa thành công");
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể sửa");
                }
            }
        }

        private void dgvKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnKH_Xoa_Click(object sender, EventArgs e)
        {
            if (textKH_MAKH.Text == "")
            {
                MessageBox.Show("Mã khách hàng không được để trống"); 
            }
            else
            {
                try
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql = "DELETE FROM KHACHHANG WHERE MAKH ='" + textKH_MAKH.Text + "'";
                    ketnoi.executeUpdate(sql);
                    ShowKH();
                    ketnoi.closeConn();
                    MessageBox.Show("Xóa thành công");
                    textKH_MAKH.ReadOnly = false;
                    textKH_MAKH.Clear();
                    textKH_HT.Clear();
                    textKH_SDT.Clear();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể xóa");
                }
            }
        }

        private void btnKH_LM_Click(object sender, EventArgs e)
        {
            textKH_MAKH.ReadOnly = false;
            textKH_MAKH.Clear();
            textKH_HT.Clear();
            textKH_SDT.Clear();
            ShowKH();
        }

        private void btnKH_Search_Click(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            string sql = "SELECT * FROM KHACHHANG WHERE TENKH LIKE N'%" + textKH_Search.Text + "%'";
            DataTable dt = ketnoi.loadDataTable(sql);
            dgvKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKH.DataSource = dt;
            ketnoi.closeConn();
        }

        private void btnSP_TK_Click(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            string sql = "SELECT TENMON AS N'Tên món',TENLOAI AS N'Tên Loại',DONGIA AS N'Đơn giá' FROM LOAIMON,MON WHERE MON.MALOAI = LOAIMON.MALOAI and TENMON LIKE N'%" + textSP_TK.Text + "%'";
            DataTable dt = ketnoi.loadDataTable(sql);
            dgvSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSP.DataSource = dt;
            ketnoi.closeConn();
        }

        private void btnSP_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLSP_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNV_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnKH_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgvKHO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnQLK_TM_Click(object sender, EventArgs e)
        {
            string str = "";
            try
            {
                Connection ketnoi = new Connection();
                ketnoi.openConn();
                string sql = "SELECT MAX(ID) FROM SANPHAM";
                DataTable dt = ketnoi.loadDataTable(sql);
                ketnoi.closeConn();
                str = "SP" + (Convert.ToInt32(dt.Rows[0][0].ToString()) + 1);
            }
            catch (Exception)
            {

                str = "SP1";
            }
            txtQLK_MSP.Text = str;
            if (txtQLK_TSP.Text == "" || txtQLK_DVT.Text == "")
            {
                MessageBox.Show("Dữ liệu không được để trống");
            }
            else
            {
                try
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql = "INSERT INTO SANPHAM(MASP,TENSP,DVT) VALUES('"+str+"',N'"+txtQLK_TSP.Text+"',N'"+txtQLK_DVT.Text+"')";
                    ketnoi.executeUpdate(sql);
                    ShowKho();
                    ketnoi.closeConn();
                    MessageBox.Show("Thêm thành công");
                }
                catch (Exception)
                {
                    MessageBox.Show("Tên sản phẩm đã tồn tại");
                }
            }
        }

        private void btnQLK_CS_Click(object sender, EventArgs e)
        {
            if (txtQLK_DVT.Text == "" || txtQLK_TSP.Text == "")
            {
                MessageBox.Show("Dữ liệu không được để trống");
            }
            else
            {
                try
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql = "UPDATE SANPHAM SET TENSP=N'" + txtQLK_TSP.Text + "', DVT=N'" + txtQLK_DVT.Text + "' WHERE MASP='" + txtQLK_MSP.Text + "'";
                    ketnoi.executeUpdate(sql);
                    ShowKho();
                    ketnoi.closeConn();
                    MessageBox.Show("Sửa thành công");
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể sửa");
                }
            }
        }

        private void btnQLK_Xoa_Click(object sender, EventArgs e)
        {
            if (txtQLK_MSP.Text == "")
            {
                MessageBox.Show("Mã sản phẩm không được để trống");
            }
            else
            {
                try
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql = "DELETE FROM SANPHAM WHERE MASP ='" + txtQLK_MSP.Text + "'";
                    ketnoi.executeUpdate(sql);
                    ShowKho();
                    txtQLK_MSP.Clear();
                    txtQLK_DVT.Clear();
                    txtQLK_TSP.Clear();
                    txtQLK_Search.Clear();
                    ketnoi.closeConn();
                    MessageBox.Show("Xóa thành công");
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể xóa");
                }
            }
        }

        private void btnQLK_LM_Click(object sender, EventArgs e)
        {
            txtQLK_MSP.ReadOnly = false;
            txtQLK_MSP.Clear();
            txtQLK_TSP.Clear();
            txtQLK_DVT.Clear();
            txtQLK_Search.Clear();
            ShowKho();
        }

        private void btnQLK_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnQLK_Search_Click(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            string sql = "SELECT TENSP AS N'Tên sản phẩm', DVT AS N'Đơn vị tính', SL AS N'Số lượng' FROM SANPHAM WHERE TENSP LIKE N'%" + txtQLK_Search.Text+"%'";
            DataTable dt = ketnoi.loadDataTable(sql);
            dgvKHO.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKHO.DataSource = dt;
            ketnoi.closeConn();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnPN_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public static string MAPN;
        private void btnPN_LP_Click(object sender, EventArgs e)
        {
            string str = "";
            try
            {
                Connection ketnoi = new Connection();
                ketnoi.openConn();
                string sql = "SELECT MAX(ID) FROM PHIEUNHAP";
                DataTable dt = ketnoi.loadDataTable(sql);
                ketnoi.closeConn();
                str = "PN" + (Convert.ToInt32(dt.Rows[0][0].ToString()) + 1);
            }
            catch (Exception)
            {

                str = "PN1";
            }
            textPN_MAPN.Text = str;
            if (textPN_MAPN.Text == "")
            {
                MessageBox.Show("Dữ liệu không được để trống");
            }
            else
            {
                try
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql = "INSERT INTO PHIEUNHAP VALUES ('" + str + "',N'" + cbPN_MNV.Text + "','" + dtpPN.Text + "')";
                    ketnoi.executeUpdate(sql);
                    ShowPN();
                    ketnoi.closeConn();
                    MAPN = textPN_MAPN.Text;
                    MessageBox.Show("Thêm thành công");
                    Phieunhap PN = new Phieunhap();
                    PN.Show();               
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể thêm");
                }
            }
        }
        private void btnPN_LM_Click(object sender, EventArgs e)
        {
            textPN_MAPN.ReadOnly = false;
            textPN_MAPN.Clear();
            ShowPN();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textPN_MAPN.Text == "")
            {
                MessageBox.Show("Mã phiếu nhập không được để trống");
            }
            else
            {
                try
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql = "DELETE FROM PHIEUNHAP WHERE MAPN ='" + textPN_MAPN.Text + "'";
                    string sql1 = "DELETE FROM CTPN WHERE MAPN ='" + textPN_MAPN.Text + "'";
                    ketnoi.executeUpdate(sql1);
                    ketnoi.executeUpdate(sql);
                    ShowPN();
                    textPN_MAPN.Clear();
                    ketnoi.closeConn();
                    MessageBox.Show("Xóa thành công");
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể xóa");
                }
            }
        }

        public static string CTPN_MAPN;
        private void btnPN_CTPN_Click(object sender, EventArgs e)
        {
            if (textPN_MAPN.Text == "")
            {
                MessageBox.Show("Chưa chọn mã phiếu nhập!");
            }
            else
            {
                MANV = cbPN_MNV.Text;
                CTPN_MAPN = textPN_MAPN.Text;
                CTPN ChitietPN = new CTPN();
                ChitietPN.ShowDialog();
            }
        }

        public static string MAPX;
        private void btnPX_LP_Click(object sender, EventArgs e)
        {
            string str = "";
            try
            {
                Connection ketnoi = new Connection();
                ketnoi.openConn();
                string sql = "SELECT MAX(ID) FROM PHIEUXUAT";
                DataTable dt = ketnoi.loadDataTable(sql);
                ketnoi.closeConn();
                str = "PX" + (Convert.ToInt32(dt.Rows[0][0].ToString()) + 1);
            }
            catch (Exception)
            {

                str = "PX1";
            }
            txtPX_MAPX.Text = str;

            try
            {
                Connection ketnoi = new Connection();
                ketnoi.openConn();
                string sql = "INSERT INTO PHIEUXUAT VALUES ('" + txtPX_MAPX.Text + "',N'" + cbPX_MANV.Text + "','" + dtpPX_NN.Text + "')";
                ketnoi.executeUpdate(sql);
                ShowPX();
                ketnoi.closeConn();
                MAPX = txtPX_MAPX.Text;
                MessageBox.Show("Lập phiếu thành công");
                Phieuxuat PX = new Phieuxuat();
                PX.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể lập phiếu");
            }

        }

        private void cbPN_MNV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvPX_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnPX_Xoa_Click(object sender, EventArgs e)
        {
            if (txtPX_MAPX.Text == "")
            {
                MessageBox.Show("Mã phiếu xuất không được để trống");
            }
            else
            {
                try
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql = "DELETE FROM PHIEUXUAT WHERE MAPX ='" + txtPX_MAPX.Text + "'";
                    string sql1 = "DELETE FROM CTPX WHERE MAPX ='" + txtPX_MAPX.Text + "'";
                    ketnoi.executeUpdate(sql1);
                    ketnoi.executeUpdate(sql);
                    ShowPX();
                    ketnoi.closeConn();
                    MessageBox.Show("Xóa thành công");
                    txtPX_MAPX.Clear();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể xóa");
                }
            }
        }

        private void btnPX_LM_Click(object sender, EventArgs e)
        {
            txtPX_MAPX.ReadOnly = false;
            txtPX_MAPX.Clear();
            ShowPX();
        }

        private void btnPX_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public static string MANV;
        private void btnPX_CTPX_Click(object sender, EventArgs e)
        {
            if (txtPX_MAPX.Text == "")
            {
                MessageBox.Show("Chưa chọn mã phiếu xuất!");
            }
            else
            {
                MANV = cbPX_MANV.Text;
                MAPX = txtPX_MAPX.Text;
                CTPX ChitietPX = new CTPX();
                ChitietPX.ShowDialog();
            }
        }

        private void dgvSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string MAMON, TENMON,DONGIA;
            int i;
            i = dgvSP.CurrentRow.Index;
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            try
            {
                string sql = "SELECT MAMON FROM MON WHERE TENMON =N'" + dgvSP.Rows[i].Cells[0].Value.ToString() + "'";
                DataTable dt = ketnoi.loadDataTable(sql);
                MAMON = dt.Rows[0][0].ToString();
                TENMON = dgvSP.Rows[i].Cells[0].Value.ToString();
                DONGIA = dgvSP.Rows[i].Cells[2].Value.ToString();
            }
            catch (Exception)
            {

                MAMON = "";
                TENMON = "";
                DONGIA = "";
            }
            textSP_MASP.Text = MAMON;
            textSP_TSP.Text = TENMON;
            textSP_DG.Text = DONGIA;
            ketnoi.closeConn();
        }

        private void dgvLSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textLSP_MSP.ReadOnly = true;
            int i;
            i = dgvLSP.CurrentRow.Index;
            textLSP_MSP.Text = dgvLSP.Rows[i].Cells[0].Value.ToString();
            textLSP_TSP.Text = dgvLSP.Rows[i].Cells[1].Value.ToString();
        }

        private void dgv_NV_CellClick(object sender, DataGridViewCellEventArgs e)
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
            cbNV_CV.Text = dgv_NV.Rows[i].Cells[6].Value.ToString();
            textNV_DC.Text = dgv_NV.Rows[i].Cells[7].Value.ToString();
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textKH_MAKH.ReadOnly = true;
            int i;
            i = dgvKH.CurrentRow.Index;
            textKH_MAKH.Text = dgvKH.Rows[i].Cells[0].Value.ToString();
            textKH_HT.Text = dgvKH.Rows[i].Cells[1].Value.ToString();
            textKH_SDT.Text = dgvKH.Rows[i].Cells[2].Value.ToString();
        }

        private void dgvKHO_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtQLK_MSP.ReadOnly = true;
            string MASP="";
            int i;
            i = dgvKHO.CurrentRow.Index;
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            try
            {
                string sql = "SELECT MASP FROM SANPHAM WHERE TENSP =N'" + dgvKHO.Rows[i].Cells[0].Value.ToString() + "'";
                DataTable dt = ketnoi.loadDataTable(sql);
                MASP = dt.Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MASP = "";
            }
            txtQLK_MSP.Text = MASP;
            txtQLK_TSP.Text = dgvKHO.Rows[i].Cells[0].Value.ToString();
            txtQLK_DVT.Text = dgvKHO.Rows[i].Cells[1].Value.ToString();
        }

        private void dgvPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textPN_MAPN.ReadOnly = true;
            int i;
            i = dgvPN.CurrentRow.Index;
            textPN_MAPN.Text = dgvPN.Rows[i].Cells[0].Value.ToString();
            cbPN_MNV.Text = dgvPN.Rows[i].Cells[1].Value.ToString();
        }

        private void dgvPX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPX_MAPX.ReadOnly = true;
            int i;
            i = dgvPX.CurrentRow.Index;
            txtPX_MAPX.Text = dgvPX.Rows[i].Cells[0].Value.ToString();
            cbPX_MANV.Text = dgvPX.Rows[i].Cells[1].Value.ToString();
        }

        private void cbSP_LTLSP_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                Connection ketnoi = new Connection();
                ketnoi.openConn();
                string lsp = cbSP_LTLSP.Text;
                string sql = "SELECT TENMON AS N'Tên món',TENLOAI AS N'Tên Loại',DONGIA AS N'Đơn giá' FROM LOAIMON,MON WHERE MON.MALOAI = LOAIMON.MALOAI and LOAIMON.TENLOAI=N'" + lsp + "' and MON.MALOAI = LOAIMON.MALOAI";
                DataTable dt2 = ketnoi.loadDataTable(sql);
                dgvSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvSP.DataSource = dt2;
                ketnoi.closeConn();
            }
            catch (Exception)
            {

                MessageBox.Show("Error!");
            }
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            Show_dgvBC();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void label48_Click(object sender, EventArgs e)
        {

        }
        public static string MACC;
        private void button7_Click(object sender, EventArgs e)
        {
            string str = "";
            try
            {
                Connection ketnoi = new Connection();
                ketnoi.openConn();
                string sql = "SELECT MAX(ID) FROM CHAMCONG";
                DataTable dt = ketnoi.loadDataTable(sql);
                ketnoi.closeConn();
                str = "MaCC" + (Convert.ToInt32(dt.Rows[0][0].ToString()) + 1);
            }
            catch (Exception)
            {

                str = "MaCC1";
            }
            txtCC_MaCC.Text = str;
            try
            {
                Connection ketnoi = new Connection();
                ketnoi.openConn();
                string sql = "INSERT INTO CHAMCONG VALUES ('" + txtCC_MaCC.Text + "','" + cbCC_MANV.Text + "','" + dtpCC.Text + "')";
                ketnoi.executeUpdate(sql);
                ShowCC();
                ketnoi.closeConn();
                MACC = txtCC_MaCC.Text;
                MessageBox.Show("Lập phiếu thành công");
                Chamcong CC = new Chamcong();
                CC.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể lập phiếu");
            }

        }

        private void btnCC_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCC_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCC_MaCC.Text=="")
                {
                    MessageBox.Show("Không thể xóa");
                }
                else
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql = "DELETE FROM CTCC WHERE MACC='" + txtCC_MaCC.Text + "'";
                    string sql1 = "DELETE FROM CHAMCONG WHERE MACC='" + txtCC_MaCC.Text + "'";
                    ketnoi.executeUpdate(sql);
                    ketnoi.executeUpdate(sql1);
                    ShowCC();
                    txtCC_MaCC.Clear();
                    ketnoi.closeConn();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgvCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvCC.CurrentRow.Index;
            txtCC_MaCC.Text = dgvCC.Rows[i].Cells[0].Value.ToString();
            cbCC_MANV.Text = dgvCC.Rows[i].Cells[1].Value.ToString();
        }
        public static string MAQL;
        private void btnCC_CTCC_Click(object sender, EventArgs e)
        {
            if (txtCC_MaCC.Text=="")
            {
                MessageBox.Show("Chưa chọn phiếu chấm công");
            }
            else
            {
                MACC = txtCC_MaCC.Text;
                MAQL = cbCC_MANV.Text;
                CTCC Chitietchamcong = new CTCC();
                Chitietchamcong.ShowDialog();
            }
            
        }

        private void btnCC_LM_Click(object sender, EventArgs e)
        {
            txtCC_MaCC.Clear();
            ShowCC();
        }
        public static string ngaybatdau, denngay;

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textNV_MANV.Text == "")
            {
                MessageBox.Show("Chưa chọn tài khoản");
            }
            else
            {
                Connection ketnoi = new Connection();
                ketnoi.openConn();
                string sql = "UPDATE NHANVIEN SET MATKHAU='12345' WHERE MANV='"+textNV_MANV.Text+"'";
                ketnoi.executeUpdate(sql);
                ketnoi.closeConn();
                MessageBox.Show("Đặt lại mật khẩu thành công");
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            DSBanChay DSBC = new DSBanChay();
            DSBC.ShowDialog();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            QuanLi ql = new QuanLi();
            ql.ShowDialog();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            QuanLi ql = new QuanLi();
            ql.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLi ql = new QuanLi();
            ql.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLi ql = new QuanLi();
            ql.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLi ql = new QuanLi();
            ql.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLi ql = new QuanLi();
            ql.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLi ql = new QuanLi();
            ql.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLi ql = new QuanLi();
            ql.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLi ql = new QuanLi();
            ql.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ngaybatdau = dtpStart.Text;
            denngay = dtpEnd.Text;
            BaoCaoDoanhThu RPDoanhThu = new BaoCaoDoanhThu();
            RPDoanhThu.ShowDialog();
        }
    }
}
