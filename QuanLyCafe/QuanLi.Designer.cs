namespace QuanLyCafe
{
    partial class QuanLi
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
            this.btnHETHONG = new System.Windows.Forms.Button();
            this.btnBANHANG = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnQuaylai = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHETHONG
            // 
            this.btnHETHONG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnHETHONG.Enabled = false;
            this.btnHETHONG.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHETHONG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHETHONG.Location = new System.Drawing.Point(13, 66);
            this.btnHETHONG.Margin = new System.Windows.Forms.Padding(2);
            this.btnHETHONG.Name = "btnHETHONG";
            this.btnHETHONG.Size = new System.Drawing.Size(231, 125);
            this.btnHETHONG.TabIndex = 0;
            this.btnHETHONG.Text = "QUẢN LÝ HỆ THỐNG";
            this.btnHETHONG.UseVisualStyleBackColor = false;
            this.btnHETHONG.Click += new System.EventHandler(this.btnHETHONG_Click);
            // 
            // btnBANHANG
            // 
            this.btnBANHANG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBANHANG.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBANHANG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBANHANG.Location = new System.Drawing.Point(261, 66);
            this.btnBANHANG.Margin = new System.Windows.Forms.Padding(2);
            this.btnBANHANG.Name = "btnBANHANG";
            this.btnBANHANG.Size = new System.Drawing.Size(231, 125);
            this.btnBANHANG.TabIndex = 1;
            this.btnBANHANG.Text = "QUẢN LÝ BÁN HÀNG";
            this.btnBANHANG.UseVisualStyleBackColor = false;
            this.btnBANHANG.Click += new System.EventHandler(this.btnBANHANG_Click);
            this.btnBANHANG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnBANHANG_KeyDown);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button3.Location = new System.Drawing.Point(399, 11);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 34);
            this.button3.TabIndex = 2;
            this.button3.Text = "THOÁT";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnQuaylai
            // 
            this.btnQuaylai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnQuaylai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuaylai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnQuaylai.Location = new System.Drawing.Point(11, 11);
            this.btnQuaylai.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuaylai.Name = "btnQuaylai";
            this.btnQuaylai.Size = new System.Drawing.Size(104, 34);
            this.btnQuaylai.TabIndex = 3;
            this.btnQuaylai.Text = "ĐĂNG XUẤT";
            this.btnQuaylai.UseVisualStyleBackColor = false;
            this.btnQuaylai.Click += new System.EventHandler(this.button1_Click);
            // 
            // QuanLi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::QuanLyCafe.Properties.Resources.bk;
            this.ClientSize = new System.Drawing.Size(511, 223);
            this.ControlBox = false;
            this.Controls.Add(this.btnQuaylai);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnBANHANG);
            this.Controls.Add(this.btnHETHONG);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "QuanLi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lí";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHETHONG;
        private System.Windows.Forms.Button btnBANHANG;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnQuaylai;
    }
}