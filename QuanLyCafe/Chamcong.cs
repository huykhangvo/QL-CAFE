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
    public partial class Chamcong : Form
    {
        public Chamcong()
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
        /////////////////////////////////////////////////////////FUNCTION////////////////////////////////////////////////////////////

        void ShowCbCTCC_MaNV()
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            String sql = "select MANV+' - '+TENNV as hienthi,MANV from NHANVIEN";
            DataTable dt2 = ketnoi.loadDataTable(sql);
            cbCTCC_MANV.DataSource = dt2;
            cbCTCC_MANV.ValueMember = "MANV";
            cbCTCC_MANV.DisplayMember = "hienthi";
            ketnoi.closeConn();
        }
        void ShowCTCC()
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            String sql = "SELECT CTCC.MANV+' - '+TENNV AS N'Nhân viên',LUONGTHEONGAY AS N'Lương theo ngày',SONGAYLAM AS N'Số ngày làm', SONGAYNGHI AS N'Số ngày nghỉ', TAMUNG AS N'Tạm ứng',THUONG AS N'Thưởng',PHAT AS N'Phạt',GHICHU AS N'Ghi chú',THUCLANH AS N'Thực lãnh' FROM CTCC, NHANVIEN WHERE CTCC.MANV = NHANVIEN.MANV AND MACC = '"+txtCTCC_MaCC.Text+"'";
            DataTable dt2 = ketnoi.loadDataTable(sql);
            dgvCTCC.DataSource = dt2;
            dgvCTCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ketnoi.closeConn();
        }
        private void Chamcong_Load(object sender, EventArgs e)
        {
            txtCTCC_MaCC.Text = QLHeThong.MACC;
            ShowCbCTCC_MaNV();
        }

        private void btnLPN_Them_Click(object sender, EventArgs e)
        {
            if (txtCTCC_LTN.Text == "")
            {
                MessageBox.Show("Chưa nhập lương theo ngày!");
            }
            else
            {
                try
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql3 = "SELECT COUNT(*) FROM CTCC,CHAMCONG WHERE CTCC.MACC=CHAMCONG.MACC AND CHAMCONG.MACC='" + txtCTCC_MaCC.Text + "' AND CTCC.MANV='" + cbCTCC_MANV.SelectedValue.ToString() + "'";
                    DataTable dt1 = ketnoi.loadDataTable(sql3);
                    if (dt1.Rows[0][0].ToString() == "1")
                    {
                        MessageBox.Show("Bạn đã chấm công cho NV này rồi");
                        ketnoi.closeConn();
                    }
                    else
                    {
                        string sql = "INSERT INTO CTCC (MACC,MANV,LUONGTHEONGAY,SONGAYLAM,SONGAYNGHI,TAMUNG,THUONG,PHAT,GHICHU) VALUES('" + txtCTCC_MaCC.Text + "','" + cbCTCC_MANV.SelectedValue.ToString() + "','" + txtCTCC_LTN.Text + "','" + nudCTCC_SNL.Value.ToString() + "','" + nudCTCC_SNN.Value.ToString() + "','" + txtCTCC_TU.Text + "','" + txtCTCC_Thuong.Text + "','" + txtCTCC_Phat.Text + "',N'" + txtCTCC_GC.Text + "')";
                        ketnoi.executeUpdate(sql);
                        string sql1 = "UPDATE CTCC SET THUCLANH = LUONGTHEONGAY*SONGAYLAM - TAMUNG + THUONG - PHAT WHERE MACC ='" + txtCTCC_MaCC.Text + "'";
                        ketnoi.executeUpdate(sql1);
                        ShowCTCC();
                        ketnoi.closeConn();
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Không thể thêm");
                }
            }
        }

        private void dgvCTCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvCTCC.CurrentRow.Index;
            cbCTCC_MANV.Text = dgvCTCC.Rows[i].Cells[0].Value.ToString();
            txtCTCC_LTN.Text = dgvCTCC.Rows[i].Cells[1].Value.ToString();

        }

        private void btnLPN_Xoa_Click(object sender, EventArgs e)
        {
            Connection ketnoi = new Connection();
            ketnoi.openConn();
            string sql = "DELETE FROM CTCC WHERE MANV='"+cbCTCC_MANV.SelectedValue.ToString()+"'";
            ketnoi.executeUpdate(sql);
            ShowCTCC();
            ketnoi.closeConn();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn hủy chấm công?", "Hủy chấm công", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    Connection ketnoi = new Connection();
                    ketnoi.openConn();
                    string sql = "DELETE FROM CTCC WHERE MACC='"+txtCTCC_MaCC.Text+"'";
                    ketnoi.executeUpdate(sql);
                    string sql1 = "DELETE FROM CHAMCONG WHERE MACC='"+txtCTCC_MaCC.Text+"'";
                    ketnoi.executeUpdate(sql1);
                    this.Close();
                    ketnoi.closeConn();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể hủy");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lưu thành công");
            this.Close();
        }
    }
}
