namespace QuanLyCafe
{
    partial class Phieunhap
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtLPN_MPN = new System.Windows.Forms.TextBox();
            this.cbLPN_SP = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLPN_LSP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLPN_DG = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLPN_Them = new System.Windows.Forms.Button();
            this.btnLPN_Xoa = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dgvLPN = new System.Windows.Forms.DataGridView();
            this.txtPN_TC = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nudSL = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSL)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã phiếu nhập";
            // 
            // txtLPN_MPN
            // 
            this.txtLPN_MPN.Enabled = false;
            this.txtLPN_MPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLPN_MPN.Location = new System.Drawing.Point(155, 29);
            this.txtLPN_MPN.Name = "txtLPN_MPN";
            this.txtLPN_MPN.Size = new System.Drawing.Size(100, 26);
            this.txtLPN_MPN.TabIndex = 1;
            // 
            // cbLPN_SP
            // 
            this.cbLPN_SP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLPN_SP.FormattingEnabled = true;
            this.cbLPN_SP.Location = new System.Drawing.Point(155, 68);
            this.cbLPN_SP.Name = "cbLPN_SP";
            this.cbLPN_SP.Size = new System.Drawing.Size(174, 28);
            this.cbLPN_SP.TabIndex = 2;
            this.cbLPN_SP.SelectedIndexChanged += new System.EventHandler(this.cbLPN_SP_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sản phẩm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(376, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Loại sản phẩm";
            // 
            // txtLPN_LSP
            // 
            this.txtLPN_LSP.Enabled = false;
            this.txtLPN_LSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLPN_LSP.Location = new System.Drawing.Point(495, 68);
            this.txtLPN_LSP.Name = "txtLPN_LSP";
            this.txtLPN_LSP.Size = new System.Drawing.Size(144, 26);
            this.txtLPN_LSP.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(75, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Số lượng";
            // 
            // txtLPN_DG
            // 
            this.txtLPN_DG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLPN_DG.Location = new System.Drawing.Point(495, 103);
            this.txtLPN_DG.Name = "txtLPN_DG";
            this.txtLPN_DG.Size = new System.Drawing.Size(144, 26);
            this.txtLPN_DG.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(425, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Đơn giá";
            // 
            // btnLPN_Them
            // 
            this.btnLPN_Them.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLPN_Them.Location = new System.Drawing.Point(471, 137);
            this.btnLPN_Them.Name = "btnLPN_Them";
            this.btnLPN_Them.Size = new System.Drawing.Size(75, 29);
            this.btnLPN_Them.TabIndex = 10;
            this.btnLPN_Them.Text = "Thêm";
            this.btnLPN_Them.UseVisualStyleBackColor = true;
            this.btnLPN_Them.Click += new System.EventHandler(this.btnLPN_Them_Click);
            // 
            // btnLPN_Xoa
            // 
            this.btnLPN_Xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLPN_Xoa.Location = new System.Drawing.Point(552, 137);
            this.btnLPN_Xoa.Name = "btnLPN_Xoa";
            this.btnLPN_Xoa.Size = new System.Drawing.Size(75, 29);
            this.btnLPN_Xoa.TabIndex = 11;
            this.btnLPN_Xoa.Text = "Xóa";
            this.btnLPN_Xoa.UseVisualStyleBackColor = true;
            this.btnLPN_Xoa.Click += new System.EventHandler(this.btnLPN_Xoa_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(731, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 29);
            this.button1.TabIndex = 12;
            this.button1.Text = "Hoàn tất";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(633, 137);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 29);
            this.button2.TabIndex = 13;
            this.button2.Text = "Hủy phiếu";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgvLPN
            // 
            this.dgvLPN.AllowUserToResizeRows = false;
            this.dgvLPN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLPN.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLPN.Location = new System.Drawing.Point(12, 172);
            this.dgvLPN.Name = "dgvLPN";
            this.dgvLPN.ReadOnly = true;
            this.dgvLPN.RowHeadersWidth = 51;
            this.dgvLPN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLPN.Size = new System.Drawing.Size(811, 266);
            this.dgvLPN.TabIndex = 14;
            this.dgvLPN.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLPN_CellClick);
            this.dgvLPN.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLPN_CellContentClick);
            // 
            // txtPN_TC
            // 
            this.txtPN_TC.Enabled = false;
            this.txtPN_TC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPN_TC.Location = new System.Drawing.Point(106, 140);
            this.txtPN_TC.Name = "txtPN_TC";
            this.txtPN_TC.Size = new System.Drawing.Size(160, 26);
            this.txtPN_TC.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Tổng cộng";
            // 
            // nudSL
            // 
            this.nudSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSL.Location = new System.Drawing.Point(155, 102);
            this.nudSL.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSL.Name = "nudSL";
            this.nudSL.Size = new System.Drawing.Size(65, 26);
            this.nudSL.TabIndex = 19;
            this.nudSL.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Phieunhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 450);
            this.Controls.Add(this.nudSL);
            this.Controls.Add(this.txtPN_TC);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvLPN);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLPN_Xoa);
            this.Controls.Add(this.btnLPN_Them);
            this.Controls.Add(this.txtLPN_DG);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLPN_LSP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbLPN_SP);
            this.Controls.Add(this.txtLPN_MPN);
            this.Controls.Add(this.label1);
            this.Name = "Phieunhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu nhập";
            this.Load += new System.EventHandler(this.Phieunhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLPN_MPN;
        private System.Windows.Forms.ComboBox cbLPN_SP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLPN_LSP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLPN_DG;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLPN_Them;
        private System.Windows.Forms.Button btnLPN_Xoa;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvLPN;
        private System.Windows.Forms.TextBox txtPN_TC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudSL;
    }
}