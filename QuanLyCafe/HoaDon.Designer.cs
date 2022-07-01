namespace QuanLyCafe
{
    partial class HoaDon
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
            this.txtHD_MaHD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.crHD = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // txtHD_MaHD
            // 
            this.txtHD_MaHD.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHD_MaHD.Location = new System.Drawing.Point(114, 16);
            this.txtHD_MaHD.Name = "txtHD_MaHD";
            this.txtHD_MaHD.Size = new System.Drawing.Size(100, 26);
            this.txtHD_MaHD.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã hóa đơn:";
            // 
            // crHD
            // 
            this.crHD.ActiveViewIndex = -1;
            this.crHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crHD.Cursor = System.Windows.Forms.Cursors.Default;
            this.crHD.Location = new System.Drawing.Point(12, 48);
            this.crHD.Name = "crHD";
            this.crHD.Size = new System.Drawing.Size(1016, 662);
            this.crHD.TabIndex = 3;
            // 
            // HoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 722);
            this.Controls.Add(this.crHD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHD_MaHD);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "HoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hóa đơn";
            this.Load += new System.EventHandler(this.Form7_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtHD_MaHD;
        private System.Windows.Forms.Label label1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crHD;
    }
}