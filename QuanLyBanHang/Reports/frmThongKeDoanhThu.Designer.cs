namespace QuanLyBanHang.Reports
{
    partial class frmThongKeDoanhThu
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
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            panelTop = new Panel();
            btnHienTatCa = new Button();
            dtpDenNgay = new DateTimePicker();
            dtpTuNgay = new DateTimePicker();
            btnLocKetQua = new Button();
            lblLoaiSanPham = new Label();
            lblHangSanXuat = new Label();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // reportViewer1
            // 
            reportViewer1.Dock = DockStyle.Fill;
            reportViewer1.Location = new Point(0, 100);
            reportViewer1.Margin = new Padding(4);
            reportViewer1.Name = "reportViewer1";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(1544, 462);
            reportViewer1.TabIndex = 1;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(btnHienTatCa);
            panelTop.Controls.Add(dtpDenNgay);
            panelTop.Controls.Add(dtpTuNgay);
            panelTop.Controls.Add(btnLocKetQua);
            panelTop.Controls.Add(lblLoaiSanPham);
            panelTop.Controls.Add(lblHangSanXuat);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(4);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1544, 100);
            panelTop.TabIndex = 1;
            // 
            // btnHienTatCa
            // 
            btnHienTatCa.Location = new Point(1319, 30);
            btnHienTatCa.Margin = new Padding(4);
            btnHienTatCa.Name = "btnHienTatCa";
            btnHienTatCa.Size = new Size(165, 40);
            btnHienTatCa.TabIndex = 7;
            btnHienTatCa.Text = "Hiện tất cả";
            btnHienTatCa.UseVisualStyleBackColor = true;
            btnHienTatCa.Click += btnHienTatCa_Click;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.Location = new Point(819, 33);
            dtpDenNgay.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
            dtpDenNgay.MinDate = new DateTime(2020, 1, 1, 0, 0, 0, 0);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(300, 31);
            dtpDenNgay.TabIndex = 6;
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.Location = new Point(341, 33);
            dtpTuNgay.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
            dtpTuNgay.MinDate = new DateTime(2020, 1, 1, 0, 0, 0, 0);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(300, 31);
            dtpTuNgay.TabIndex = 5;
            // 
            // btnLocKetQua
            // 
            btnLocKetQua.Location = new Point(1146, 30);
            btnLocKetQua.Margin = new Padding(4);
            btnLocKetQua.Name = "btnLocKetQua";
            btnLocKetQua.Size = new Size(165, 40);
            btnLocKetQua.TabIndex = 4;
            btnLocKetQua.Text = "Lọc kết quả";
            btnLocKetQua.UseVisualStyleBackColor = true;
            btnLocKetQua.Click += btnLocKetQua_Click;
            // 
            // lblLoaiSanPham
            // 
            lblLoaiSanPham.AutoSize = true;
            lblLoaiSanPham.Location = new Point(681, 38);
            lblLoaiSanPham.Margin = new Padding(4, 0, 4, 0);
            lblLoaiSanPham.Name = "lblLoaiSanPham";
            lblLoaiSanPham.Size = new Size(131, 25);
            lblLoaiSanPham.TabIndex = 2;
            lblLoaiSanPham.Text = "Loại sản phẩm:";
            // 
            // lblHangSanXuat
            // 
            lblHangSanXuat.AutoSize = true;
            lblHangSanXuat.Location = new Point(205, 38);
            lblHangSanXuat.Margin = new Padding(4, 0, 4, 0);
            lblHangSanXuat.Name = "lblHangSanXuat";
            lblHangSanXuat.Size = new Size(129, 25);
            lblHangSanXuat.TabIndex = 0;
            lblHangSanXuat.Text = "Hãng sản xuất:";
            // 
            // frmThongKeDoanhThu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1544, 562);
            Controls.Add(panelTop);
            Name = "frmThongKeDoanhThu";
            Text = "frmThongKeDoanhThu";
            Load += frmThongKeDoanhThu_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Panel panelTop;
        private Button btnLocKetQua;
        private Label lblLoaiSanPham;
        private Label lblHangSanXuat;
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private Button btnHienTatCa;
    }
}