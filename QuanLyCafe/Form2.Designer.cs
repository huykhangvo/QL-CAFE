namespace QuanLyCafe
{
    partial class Form2
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
            this.btnHETHONG.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHETHONG.Location = new System.Drawing.Point(57, 95);
            this.btnHETHONG.Name = "btnHETHONG";
            this.btnHETHONG.Size = new System.Drawing.Size(308, 225);
            this.btnHETHONG.TabIndex = 0;
            this.btnHETHONG.Text = "QUẢN LÍ HỆ THỐNG";
            this.btnHETHONG.UseVisualStyleBackColor = true;
            this.btnHETHONG.Click += new System.EventHandler(this.btnHETHONG_Click);
            // 
            // btnBANHANG
            // 
            this.btnBANHANG.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBANHANG.Location = new System.Drawing.Point(442, 95);
            this.btnBANHANG.Name = "btnBANHANG";
            this.btnBANHANG.Size = new System.Drawing.Size(308, 225);
            this.btnBANHANG.TabIndex = 1;
            this.btnBANHANG.Text = "QUẢN LÍ BÁN HÀNG";
            this.btnBANHANG.UseVisualStyleBackColor = true;
            this.btnBANHANG.Click += new System.EventHandler(this.btnBANHANG_Click);
            this.btnBANHANG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnBANHANG_KeyDown);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(660, 26);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 30);
            this.button3.TabIndex = 2;
            this.button3.Text = "THOÁT";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnQuaylai
            // 
            this.btnQuaylai.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuaylai.Location = new System.Drawing.Point(57, 26);
            this.btnQuaylai.Name = "btnQuaylai";
            this.btnQuaylai.Size = new System.Drawing.Size(107, 30);
            this.btnQuaylai.TabIndex = 3;
            this.btnQuaylai.Text = "QUAY LẠI";
            this.btnQuaylai.UseVisualStyleBackColor = true;
            this.btnQuaylai.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 370);
            this.ControlBox = false;
            this.Controls.Add(this.btnQuaylai);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnBANHANG);
            this.Controls.Add(this.btnHETHONG);
            this.Name = "Form2";
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