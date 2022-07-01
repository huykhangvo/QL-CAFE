using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            LoadListView();
        }
        void ShowResult(Panel pnl, Label lb)
        {
            RadioButton rdb = null;

            
            if(rdb != null)
            {
                pnl.Text = rdb.Text;
                lb.Text = pnl.Text;
            }
        }

        void LoadListView()
        {
            listviewDmsp.Columns.Add("STT");
            listviewDmsp.Columns.Add("Tên sản phẩm");
            listviewDmsp.Columns.Add("Số lượng");
            listviewDmsp.Columns.Add("Đơn giá");
            listviewDmsp.Columns.Add("Thành tiền");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            //DateTime tg = DateTime.Now;
            //lbTime.Text = DateTime.Now.ToLongTimeString() + "," + tg.ToString("dd/MM/yyyy ");
            //string[] arr = new string[3];
            //ListViewItem itm;
            //thêm item vào listview
            //if (cbbLoainuoc.Text == "Cà phê")
            //{
            //    arr[0] = "01";
            //    arr[1] = "Cà phê đá";
            //    arr[2] = "20.000";
            //    itm = new ListViewItem(arr);
            //    listView2.Items.Add(itm);
            //}
            //arr[0] = "01";
            //arr[1] = "Cà phê đá";
            //arr[2] = "20.000";
            //itm = new ListViewItem(arr);
            //listView2.Items.Add(itm);
        
            //Thêm tiêu đề cho cột

            //listView2.Columns.Add("Tên sản phẩm", 100);
            //listView2.Columns.Add("Giá", 70);
            //listView2.Columns.Add("Số lượng", 70);

            //Thêm Item vào listview

            ////Thêm Item đầu tiên
            //arr[0] = "01";
            //arr[1] = "Cà phê đá";
            //arr[2] = "20.000 vnđ";
            //itm = new ListViewItem(arr);
            //listView2.Items.Add(itm);

            ////Thêm Item thứ 2
            //arr[0] = "02";
            //arr[1] = "Cà phê sữa đá";
            //arr[2] = "22.000 vnđ";
            //itm = new ListViewItem(arr);
            //listView2.Items.Add(itm);

        }

        private void lbTime_Click(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lbTime.Text = (DateTime.Now.ToLongTimeString() + "," + DateTime.Now.ToString("dd/MM/yyyy"));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ShowResult(panel1, lbSoban);

            
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            Form7 frm7 = new Form7();
            frm7.Show();
            //this.Hide();
        }

        private void lbSoban_Click(object sender, EventArgs e)
        { 
            
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            lbSoban.Text = radioButton3.Text;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

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
            //lbDanhmuc.AutoSize = false;
            //lbDanhmuc.Height = 2;
            //lbDanhmuc.BorderStyle = BorderStyle.Fixed3D;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listviewDmsp_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    FormBorderStyle = FormBorderStyle.None;
            //    WindowState = FormWindowState.Maximized;
            //    TopMost = true;
            //}
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
            //thêm item vào listview

            //arr[0] = "01";
            //arr[1] = "Cà phê đá";
            //arr[2] = "20.000";
            //itm = new ListViewItem(arr);
            //listView2.Items.Add(itm);

            
        }

        private void cbbLoainuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loainuoc;
            loainuoc = cbbLoainuoc.Text;
            string[] arr = new string[3];
            ListViewItem itm;
            if (loainuoc == "Cà phê")
            {
                listView2.Items.Clear();
                //Thêm Item đầu tiên
                arr[0] = "01";
                arr[1] = "Cà phê đá";
                arr[2] = "20.000 vnđ";
                itm = new ListViewItem(arr);
                listView2.Items.Add(itm);

                //Thêm Item thứ 2
                arr[0] = "02";
                arr[1] = "Cà phê sữa đá";
                arr[2] = "22.000 vnđ";
                itm = new ListViewItem(arr);
                listView2.Items.Add(itm);
            }
            else if ( loainuoc  == "Đá xay")
            {
                listView2.Items.Clear();
            //Thêm Item đầu tiên
                arr[0] = "01";
                arr[1] = "Socolate đá xay";
                arr[2] = "35.000 vnđ";
                itm = new ListViewItem(arr);
                listView2.Items.Add(itm);

                //Thêm Item thứ 2
                arr[0] = "02";
                arr[1] = "Oreo Đá xay";
                arr[2] = "35.000 vnđ";
                itm = new ListViewItem(arr);
                listView2.Items.Add(itm);
            }
        }
    }
}
