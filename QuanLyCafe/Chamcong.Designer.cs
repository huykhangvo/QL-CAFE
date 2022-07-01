namespace QuanLyCafe
{
    partial class Chamcong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCTCC_MaCC = new System.Windows.Forms.TextBox();
            this.dgvCTCC = new System.Windows.Forms.DataGridView();
            this.cbCTCC_MANV = new System.Windows.Forms.ComboBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCTCC_LTN = new System.Windows.Forms.TextBox();
            this.nudCTCC_SNL = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudCTCC_SNN = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCTCC_TU = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCTCC_Thuong = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCTCC_Phat = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCTCC_GC = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLPN_Xoa = new System.Windows.Forms.Button();
            this.btnLPN_Them = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCTCC_SNL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCTCC_SNN)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã chấm công";
            // 
            // txtCTCC_MaCC
            // 
            this.txtCTCC_MaCC.Enabled = false;
            this.txtCTCC_MaCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCTCC_MaCC.Location = new System.Drawing.Point(134, 17);
            this.txtCTCC_MaCC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCTCC_MaCC.Name = "txtCTCC_MaCC";
            this.txtCTCC_MaCC.Size = new System.Drawing.Size(83, 26);
            this.txtCTCC_MaCC.TabIndex = 3;
            // 
            // dgvCTCC
            // 
            this.dgvCTCC.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCTCC.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCTCC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCTCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCTCC.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCTCC.Location = new System.Drawing.Point(9, 187);
            this.dgvCTCC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvCTCC.Name = "dgvCTCC";
            this.dgvCTCC.RowHeadersWidth = 51;
            this.dgvCTCC.RowTemplate.Height = 24;
            this.dgvCTCC.Size = new System.Drawing.Size(1192, 339);
            this.dgvCTCC.TabIndex = 5;
            this.dgvCTCC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCTCC_CellClick);
            // 
            // cbCTCC_MANV
            // 
            this.cbCTCC_MANV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCTCC_MANV.FormattingEnabled = true;
            this.cbCTCC_MANV.Location = new System.Drawing.Point(134, 62);
            this.cbCTCC_MANV.Name = "cbCTCC_MANV";
            this.cbCTCC_MANV.Size = new System.Drawing.Size(255, 28);
            this.cbCTCC_MANV.TabIndex = 39;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.Location = new System.Drawing.Point(32, 64);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(103, 20);
            this.label51.TabIndex = 38;
            this.label51.Text = "Mã nhân viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(410, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 41;
            this.label2.Text = "Lương theo ngày";
            // 
            // txtCTCC_LTN
            // 
            this.txtCTCC_LTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCTCC_LTN.Location = new System.Drawing.Point(540, 62);
            this.txtCTCC_LTN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCTCC_LTN.Name = "txtCTCC_LTN";
            this.txtCTCC_LTN.Size = new System.Drawing.Size(144, 26);
            this.txtCTCC_LTN.TabIndex = 40;
            // 
            // nudCTCC_SNL
            // 
            this.nudCTCC_SNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCTCC_SNL.Location = new System.Drawing.Point(797, 63);
            this.nudCTCC_SNL.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudCTCC_SNL.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.nudCTCC_SNL.Name = "nudCTCC_SNL";
            this.nudCTCC_SNL.Size = new System.Drawing.Size(51, 26);
            this.nudCTCC_SNL.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(691, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 43;
            this.label3.Text = "Số ngày làm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(853, 64);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 20);
            this.label4.TabIndex = 45;
            this.label4.Text = "Số ngày nghỉ";
            // 
            // nudCTCC_SNN
            // 
            this.nudCTCC_SNN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCTCC_SNN.Location = new System.Drawing.Point(960, 63);
            this.nudCTCC_SNN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudCTCC_SNN.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.nudCTCC_SNN.Name = "nudCTCC_SNN";
            this.nudCTCC_SNN.Size = new System.Drawing.Size(51, 26);
            this.nudCTCC_SNN.TabIndex = 44;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(62, 113);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 20);
            this.label5.TabIndex = 47;
            this.label5.Text = "Tạm ứng";
            // 
            // txtCTCC_TU
            // 
            this.txtCTCC_TU.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCTCC_TU.Location = new System.Drawing.Point(134, 110);
            this.txtCTCC_TU.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCTCC_TU.Name = "txtCTCC_TU";
            this.txtCTCC_TU.Size = new System.Drawing.Size(144, 26);
            this.txtCTCC_TU.TabIndex = 46;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(296, 113);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 49;
            this.label6.Text = "Thưởng";
            // 
            // txtCTCC_Thuong
            // 
            this.txtCTCC_Thuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCTCC_Thuong.Location = new System.Drawing.Point(360, 110);
            this.txtCTCC_Thuong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCTCC_Thuong.Name = "txtCTCC_Thuong";
            this.txtCTCC_Thuong.Size = new System.Drawing.Size(144, 26);
            this.txtCTCC_Thuong.TabIndex = 48;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(527, 113);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 20);
            this.label7.TabIndex = 51;
            this.label7.Text = "Phạt";
            // 
            // txtCTCC_Phat
            // 
            this.txtCTCC_Phat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCTCC_Phat.Location = new System.Drawing.Point(571, 110);
            this.txtCTCC_Phat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCTCC_Phat.Name = "txtCTCC_Phat";
            this.txtCTCC_Phat.Size = new System.Drawing.Size(144, 26);
            this.txtCTCC_Phat.TabIndex = 50;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(742, 113);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 20);
            this.label8.TabIndex = 53;
            this.label8.Text = "Ghi chú";
            // 
            // txtCTCC_GC
            // 
            this.txtCTCC_GC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCTCC_GC.Location = new System.Drawing.Point(806, 110);
            this.txtCTCC_GC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCTCC_GC.Multiline = true;
            this.txtCTCC_GC.Name = "txtCTCC_GC";
            this.txtCTCC_GC.Size = new System.Drawing.Size(339, 63);
            this.txtCTCC_GC.TabIndex = 52;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(591, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 29);
            this.button2.TabIndex = 57;
            this.button2.Text = "Hủy phiếu";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(689, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 29);
            this.button1.TabIndex = 56;
            this.button1.Text = "Hoàn tất";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLPN_Xoa
            // 
            this.btnLPN_Xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLPN_Xoa.Location = new System.Drawing.Point(510, 152);
            this.btnLPN_Xoa.Name = "btnLPN_Xoa";
            this.btnLPN_Xoa.Size = new System.Drawing.Size(75, 29);
            this.btnLPN_Xoa.TabIndex = 55;
            this.btnLPN_Xoa.Text = "Xóa";
            this.btnLPN_Xoa.UseVisualStyleBackColor = true;
            this.btnLPN_Xoa.Click += new System.EventHandler(this.btnLPN_Xoa_Click);
            // 
            // btnLPN_Them
            // 
            this.btnLPN_Them.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLPN_Them.Location = new System.Drawing.Point(429, 152);
            this.btnLPN_Them.Name = "btnLPN_Them";
            this.btnLPN_Them.Size = new System.Drawing.Size(75, 29);
            this.btnLPN_Them.TabIndex = 54;
            this.btnLPN_Them.Text = "Thêm";
            this.btnLPN_Them.UseVisualStyleBackColor = true;
            this.btnLPN_Them.Click += new System.EventHandler(this.btnLPN_Them_Click);
            // 
            // Chamcong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 535);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLPN_Xoa);
            this.Controls.Add(this.btnLPN_Them);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCTCC_GC);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCTCC_Phat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCTCC_Thuong);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCTCC_TU);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudCTCC_SNN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudCTCC_SNL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCTCC_LTN);
            this.Controls.Add(this.cbCTCC_MANV);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.dgvCTCC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCTCC_MaCC);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Chamcong";
            this.Text = "Chamcong";
            this.Load += new System.EventHandler(this.Chamcong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCTCC_SNL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCTCC_SNN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCTCC_MaCC;
        private System.Windows.Forms.DataGridView dgvCTCC;
        private System.Windows.Forms.ComboBox cbCTCC_MANV;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCTCC_LTN;
        private System.Windows.Forms.NumericUpDown nudCTCC_SNL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudCTCC_SNN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCTCC_TU;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCTCC_Thuong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCTCC_Phat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCTCC_GC;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLPN_Xoa;
        private System.Windows.Forms.Button btnLPN_Them;
    }
}