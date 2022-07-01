namespace QuanLyCafe
{
    partial class Phieuxuat
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
            this.dgvLPX = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLPX_Xoa = new System.Windows.Forms.Button();
            this.btnLPX_Them = new System.Windows.Forms.Button();
            this.txtLPX_SL = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLPX_LSP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbLPX_SP = new System.Windows.Forms.ComboBox();
            this.txtLPX_MPX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLPX)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLPX
            // 
            this.dgvLPX.AllowUserToResizeRows = false;
            this.dgvLPX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLPX.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLPX.Location = new System.Drawing.Point(12, 175);
            this.dgvLPX.Name = "dgvLPX";
            this.dgvLPX.ReadOnly = true;
            this.dgvLPX.RowHeadersWidth = 51;
            this.dgvLPX.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLPX.Size = new System.Drawing.Size(811, 266);
            this.dgvLPX.TabIndex = 33;
            this.dgvLPX.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLPX_CellClick);
            this.dgvLPX.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLPN_CellContentClick);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(633, 129);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 29);
            this.button2.TabIndex = 32;
            this.button2.Text = "Hủy phiếu";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(731, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 29);
            this.button1.TabIndex = 31;
            this.button1.Text = "Hoàn tất";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLPX_Xoa
            // 
            this.btnLPX_Xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLPX_Xoa.Location = new System.Drawing.Point(552, 129);
            this.btnLPX_Xoa.Name = "btnLPX_Xoa";
            this.btnLPX_Xoa.Size = new System.Drawing.Size(75, 29);
            this.btnLPX_Xoa.TabIndex = 30;
            this.btnLPX_Xoa.Text = "Xóa";
            this.btnLPX_Xoa.UseVisualStyleBackColor = true;
            this.btnLPX_Xoa.Click += new System.EventHandler(this.btnLPX_Xoa_Click);
            // 
            // btnLPX_Them
            // 
            this.btnLPX_Them.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLPX_Them.Location = new System.Drawing.Point(471, 129);
            this.btnLPX_Them.Name = "btnLPX_Them";
            this.btnLPX_Them.Size = new System.Drawing.Size(75, 29);
            this.btnLPX_Them.TabIndex = 29;
            this.btnLPX_Them.Text = "Xuất";
            this.btnLPX_Them.UseVisualStyleBackColor = true;
            this.btnLPX_Them.Click += new System.EventHandler(this.btnLPX_Them_Click);
            // 
            // txtLPX_SL
            // 
            this.txtLPX_SL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLPX_SL.Location = new System.Drawing.Point(154, 112);
            this.txtLPX_SL.Name = "txtLPX_SL";
            this.txtLPX_SL.Size = new System.Drawing.Size(71, 26);
            this.txtLPX_SL.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(76, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "Số lượng";
            // 
            // txtLPX_LSP
            // 
            this.txtLPX_LSP.Enabled = false;
            this.txtLPX_LSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLPX_LSP.Location = new System.Drawing.Point(467, 76);
            this.txtLPX_LSP.Name = "txtLPX_LSP";
            this.txtLPX_LSP.Size = new System.Drawing.Size(144, 26);
            this.txtLPX_LSP.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(348, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Loại sản phẩm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Sản phẩm";
            // 
            // cbLPX_SP
            // 
            this.cbLPX_SP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLPX_SP.FormattingEnabled = true;
            this.cbLPX_SP.Location = new System.Drawing.Point(154, 78);
            this.cbLPX_SP.Name = "cbLPX_SP";
            this.cbLPX_SP.Size = new System.Drawing.Size(174, 28);
            this.cbLPX_SP.TabIndex = 21;
            this.cbLPX_SP.SelectedIndexChanged += new System.EventHandler(this.cbLPX_SP_SelectedIndexChanged);
            // 
            // txtLPX_MPX
            // 
            this.txtLPX_MPX.Enabled = false;
            this.txtLPX_MPX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLPX_MPX.Location = new System.Drawing.Point(154, 32);
            this.txtLPX_MPX.Name = "txtLPX_MPX";
            this.txtLPX_MPX.Size = new System.Drawing.Size(100, 26);
            this.txtLPX_MPX.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Mã phiếu xuất";
            // 
            // Phieuxuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 453);
            this.Controls.Add(this.dgvLPX);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLPX_Xoa);
            this.Controls.Add(this.btnLPX_Them);
            this.Controls.Add(this.txtLPX_SL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLPX_LSP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbLPX_SP);
            this.Controls.Add(this.txtLPX_MPX);
            this.Controls.Add(this.label1);
            this.Name = "Phieuxuat";
            this.Text = "Phieuxuat";
            this.Load += new System.EventHandler(this.Phieuxuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLPX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvLPX;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLPX_Xoa;
        private System.Windows.Forms.Button btnLPX_Them;
        private System.Windows.Forms.TextBox txtLPX_SL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLPX_LSP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbLPX_SP;
        private System.Windows.Forms.TextBox txtLPX_MPX;
        private System.Windows.Forms.Label label1;
    }
}