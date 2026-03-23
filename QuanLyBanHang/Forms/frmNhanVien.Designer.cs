namespace QuanLyBanHang.Forms
{
    partial class frmNhanVien
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
            components = new System.ComponentModel.Container();
            cboQuyenHan = new ComboBox();
            txtMatKhau = new TextBox();
            txtTenDangNhap = new TextBox();
            lblQuyenHan = new Label();
            lblMK = new Label();
            btnXoa = new Button();
            gpbThongTinNhanVien = new GroupBox();
            lblTenDangNhap = new Label();
            btnXuat = new Button();
            btnTimKiem = new Button();
            btnNhap = new Button();
            lblDiaChi = new Label();
            lblSDT = new Label();
            txtDiaChi = new TextBox();
            txtDienThoai = new TextBox();
            btnThoat = new Button();
            btnHuyBo = new Button();
            btnLuu = new Button();
            btnSua = new Button();
            btnThem = new Button();
            txtHoVaTen = new TextBox();
            lblTenNV = new Label();
            QuyenHan = new DataGridViewTextBoxColumn();
            TenDangNhap = new DataGridViewTextBoxColumn();
            DiaChi = new DataGridViewTextBoxColumn();
            DienThoai = new DataGridViewTextBoxColumn();
            HoVaTen = new DataGridViewTextBoxColumn();
            ID = new DataGridViewTextBoxColumn();
            dataGridView = new DataGridView();
            gpbDanhSach = new GroupBox();
            toolTip1 = new ToolTip(components);
            gpbThongTinNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            gpbDanhSach.SuspendLayout();
            SuspendLayout();
            // 
            // cboQuyenHan
            // 
            cboQuyenHan.FormattingEnabled = true;
            cboQuyenHan.Items.AddRange(new object[] { "Quản Lí", "Nhân Viên" });
            cboQuyenHan.Location = new Point(589, 114);
            cboQuyenHan.Margin = new Padding(4);
            cboQuyenHan.Name = "cboQuyenHan";
            cboQuyenHan.Size = new Size(225, 33);
            cboQuyenHan.TabIndex = 18;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(589, 72);
            txtMatKhau.Margin = new Padding(4);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(225, 31);
            txtMatKhau.TabIndex = 17;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(589, 30);
            txtTenDangNhap.Margin = new Padding(4);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(225, 31);
            txtTenDangNhap.TabIndex = 16;
            // 
            // lblQuyenHan
            // 
            lblQuyenHan.AutoSize = true;
            lblQuyenHan.Location = new Point(433, 115);
            lblQuyenHan.Margin = new Padding(4, 0, 4, 0);
            lblQuyenHan.Name = "lblQuyenHan";
            lblQuyenHan.Size = new Size(128, 25);
            lblQuyenHan.TabIndex = 15;
            lblQuyenHan.Text = "Quyền Hạn (*):";
            // 
            // lblMK
            // 
            lblMK.AutoSize = true;
            lblMK.Location = new Point(433, 77);
            lblMK.Margin = new Padding(4, 0, 4, 0);
            lblMK.Name = "lblMK";
            lblMK.Size = new Size(114, 25);
            lblMK.TabIndex = 14;
            lblMK.Text = "Mật Khẩu (*):";
            // 
            // btnXoa
            // 
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(858, 114);
            btnXoa.Margin = new Padding(4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(111, 36);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // gpbThongTinNhanVien
            // 
            gpbThongTinNhanVien.Controls.Add(cboQuyenHan);
            gpbThongTinNhanVien.Controls.Add(txtMatKhau);
            gpbThongTinNhanVien.Controls.Add(txtTenDangNhap);
            gpbThongTinNhanVien.Controls.Add(lblQuyenHan);
            gpbThongTinNhanVien.Controls.Add(lblMK);
            gpbThongTinNhanVien.Controls.Add(lblTenDangNhap);
            gpbThongTinNhanVien.Controls.Add(btnXuat);
            gpbThongTinNhanVien.Controls.Add(btnTimKiem);
            gpbThongTinNhanVien.Controls.Add(btnNhap);
            gpbThongTinNhanVien.Controls.Add(lblDiaChi);
            gpbThongTinNhanVien.Controls.Add(lblSDT);
            gpbThongTinNhanVien.Controls.Add(txtDiaChi);
            gpbThongTinNhanVien.Controls.Add(txtDienThoai);
            gpbThongTinNhanVien.Controls.Add(btnThoat);
            gpbThongTinNhanVien.Controls.Add(btnHuyBo);
            gpbThongTinNhanVien.Controls.Add(btnLuu);
            gpbThongTinNhanVien.Controls.Add(btnXoa);
            gpbThongTinNhanVien.Controls.Add(btnSua);
            gpbThongTinNhanVien.Controls.Add(btnThem);
            gpbThongTinNhanVien.Controls.Add(txtHoVaTen);
            gpbThongTinNhanVien.Controls.Add(lblTenNV);
            gpbThongTinNhanVien.Location = new Point(9, 8);
            gpbThongTinNhanVien.Margin = new Padding(4);
            gpbThongTinNhanVien.Name = "gpbThongTinNhanVien";
            gpbThongTinNhanVien.Padding = new Padding(4);
            gpbThongTinNhanVien.Size = new Size(1215, 195);
            gpbThongTinNhanVien.TabIndex = 6;
            gpbThongTinNhanVien.TabStop = false;
            gpbThongTinNhanVien.Text = "Thông tin nhân viên";
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Location = new Point(432, 35);
            lblTenDangNhap.Margin = new Padding(4, 0, 4, 0);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new Size(156, 25);
            lblTenDangNhap.TabIndex = 13;
            lblTenDangNhap.Text = "Tên đăng nhập (*):";
            // 
            // btnXuat
            // 
            btnXuat.ForeColor = Color.Black;
            btnXuat.Location = new Point(1096, 114);
            btnXuat.Margin = new Padding(4);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(111, 36);
            btnXuat.TabIndex = 6;
            btnXuat.Text = "Xuất...";
            btnXuat.UseVisualStyleBackColor = true;
            btnXuat.Click += btnXuat_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.ForeColor = Color.Black;
            btnTimKiem.Location = new Point(1096, 29);
            btnTimKiem.Margin = new Padding(4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(111, 36);
            btnTimKiem.TabIndex = 7;
            btnTimKiem.Text = "Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnNhap
            // 
            btnNhap.ForeColor = Color.Black;
            btnNhap.Location = new Point(1096, 71);
            btnNhap.Margin = new Padding(4);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(111, 36);
            btnNhap.TabIndex = 12;
            btnNhap.Text = "Nhập...";
            btnNhap.UseVisualStyleBackColor = true;
            btnNhap.Click += btnNhap_Click;
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Location = new Point(6, 115);
            lblDiaChi.Margin = new Padding(4, 0, 4, 0);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(92, 25);
            lblDiaChi.TabIndex = 11;
            lblDiaChi.Text = "Địa chỉ (*):";
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.Location = new Point(6, 77);
            lblSDT.Margin = new Padding(4, 0, 4, 0);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(144, 25);
            lblSDT.TabIndex = 10;
            lblSDT.Text = "Số điện thoại (*):";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(162, 110);
            txtDiaChi.Margin = new Padding(4);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(260, 31);
            txtDiaChi.TabIndex = 9;
            // 
            // txtDienThoai
            // 
            txtDienThoai.Location = new Point(162, 72);
            txtDienThoai.Margin = new Padding(4);
            txtDienThoai.Name = "txtDienThoai";
            txtDienThoai.Size = new Size(260, 31);
            txtDienThoai.TabIndex = 8;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(976, 114);
            btnThoat.Margin = new Padding(4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(111, 36);
            btnThoat.TabIndex = 7;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnHuyBo
            // 
            btnHuyBo.Location = new Point(976, 71);
            btnHuyBo.Margin = new Padding(4);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(111, 36);
            btnHuyBo.TabIndex = 6;
            btnHuyBo.Text = "Hủy bỏ";
            btnHuyBo.UseVisualStyleBackColor = true;
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // btnLuu
            // 
            btnLuu.ForeColor = Color.Blue;
            btnLuu.Location = new Point(976, 29);
            btnLuu.Margin = new Padding(4);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(111, 36);
            btnLuu.TabIndex = 5;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(858, 71);
            btnSua.Margin = new Padding(4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(111, 36);
            btnSua.TabIndex = 3;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(858, 29);
            btnThem.Margin = new Padding(4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(111, 36);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // txtHoVaTen
            // 
            txtHoVaTen.Location = new Point(162, 30);
            txtHoVaTen.Margin = new Padding(4);
            txtHoVaTen.Name = "txtHoVaTen";
            txtHoVaTen.Size = new Size(260, 31);
            txtHoVaTen.TabIndex = 1;
            // 
            // lblTenNV
            // 
            lblTenNV.AutoSize = true;
            lblTenNV.Location = new Point(6, 35);
            lblTenNV.Margin = new Padding(4, 0, 4, 0);
            lblTenNV.Name = "lblTenNV";
            lblTenNV.Size = new Size(117, 25);
            lblTenNV.TabIndex = 0;
            lblTenNV.Text = "Họ và Tên (*):";
            // 
            // QuyenHan
            // 
            QuyenHan.DataPropertyName = "QuyenHan";
            QuyenHan.FillWeight = 104.898041F;
            QuyenHan.HeaderText = "Quyền Hạn";
            QuyenHan.MinimumWidth = 6;
            QuyenHan.Name = "QuyenHan";
            // 
            // TenDangNhap
            // 
            TenDangNhap.DataPropertyName = "TenDangNhap";
            TenDangNhap.FillWeight = 104.898041F;
            TenDangNhap.HeaderText = "Tên Đăng Nhập";
            TenDangNhap.MinimumWidth = 6;
            TenDangNhap.Name = "TenDangNhap";
            // 
            // DiaChi
            // 
            DiaChi.DataPropertyName = "DiaChi";
            DiaChi.FillWeight = 128.342239F;
            DiaChi.HeaderText = "Địa Chỉ";
            DiaChi.MinimumWidth = 6;
            DiaChi.Name = "DiaChi";
            // 
            // DienThoai
            // 
            DienThoai.DataPropertyName = "DienThoai";
            DienThoai.FillWeight = 112.190414F;
            DienThoai.HeaderText = "Điện Thoại";
            DienThoai.MinimumWidth = 6;
            DienThoai.Name = "DienThoai";
            // 
            // HoVaTen
            // 
            HoVaTen.DataPropertyName = "HoVaTen";
            HoVaTen.FillWeight = 124.366913F;
            HoVaTen.HeaderText = "Họ và Tên";
            HoVaTen.MinimumWidth = 6;
            HoVaTen.Name = "HoVaTen";
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.FillWeight = 25.30435F;
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ID, HoVaTen, DienThoai, DiaChi, TenDangNhap, QuyenHan });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(4, 28);
            dataGridView.Margin = new Padding(4);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(1207, 472);
            dataGridView.TabIndex = 1;
            // 
            // gpbDanhSach
            // 
            gpbDanhSach.Controls.Add(dataGridView);
            gpbDanhSach.Location = new Point(7, 169);
            gpbDanhSach.Margin = new Padding(4);
            gpbDanhSach.Name = "gpbDanhSach";
            gpbDanhSach.Padding = new Padding(4);
            gpbDanhSach.Size = new Size(1215, 504);
            gpbDanhSach.TabIndex = 7;
            gpbDanhSach.TabStop = false;
            gpbDanhSach.Text = "Danh sách khách hàng:";
            // 
            // frmNhanVien
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1231, 681);
            Controls.Add(gpbThongTinNhanVien);
            Controls.Add(gpbDanhSach);
            Name = "frmNhanVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmNhanVien";
            Load += frmNhanVien_Load;
            gpbThongTinNhanVien.ResumeLayout(false);
            gpbThongTinNhanVien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            gpbDanhSach.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cboQuyenHan;
        private TextBox txtMatKhau;
        private TextBox txtTenDangNhap;
        private Label lblQuyenHan;
        private Label lblMK;
        private Button btnXoa;
        private GroupBox gpbThongTinNhanVien;
        private Label lblTenDangNhap;
        private Button btnXuat;
        private Button btnTimKiem;
        private Button btnNhap;
        private Label lblDiaChi;
        private Label lblSDT;
        private TextBox txtDiaChi;
        private TextBox txtDienThoai;
        private Button btnThoat;
        private Button btnHuyBo;
        private Button btnLuu;
        private Button btnSua;
        private Button btnThem;
        private TextBox txtHoVaTen;
        private Label lblTenNV;
        private DataGridViewTextBoxColumn QuyenHan;
        private DataGridViewTextBoxColumn TenDangNhap;
        private DataGridViewTextBoxColumn DiaChi;
        private DataGridViewTextBoxColumn DienThoai;
        private DataGridViewTextBoxColumn HoVaTen;
        private DataGridViewTextBoxColumn ID;
        private DataGridView dataGridView;
        private GroupBox gpbDanhSach;
        private ToolTip toolTip1;
    }
}