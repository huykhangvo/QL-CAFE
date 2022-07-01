namespace QuanLyCafe
{
    partial class BaoCaoDoanhThu
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
            this.crRPDoanhThu = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crRPDoanhThu
            // 
            this.crRPDoanhThu.ActiveViewIndex = -1;
            this.crRPDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crRPDoanhThu.Cursor = System.Windows.Forms.Cursors.Default;
            this.crRPDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crRPDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.crRPDoanhThu.Name = "crRPDoanhThu";
            this.crRPDoanhThu.Size = new System.Drawing.Size(1256, 643);
            this.crRPDoanhThu.TabIndex = 0;
            // 
            // BaoCaoDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 643);
            this.Controls.Add(this.crRPDoanhThu);
            this.Name = "BaoCaoDoanhThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BaoCaoDoanhThu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BaoCaoDoanhThu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crRPDoanhThu;
    }
}