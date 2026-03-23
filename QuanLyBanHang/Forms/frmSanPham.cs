using ClosedXML.Excel;
using QuanLyBanHang.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QuanLyBanHang.Forms
{

    public partial class frmSanPham : Form
    {
        QLBHDbContext context = new QLBHDbContext(); // Khởi tạo biến ngữ cảnh CSDL
        bool xuLyThem = false; // Kiểm tra có nhấn vào nút Thêm hay không?
        int id; // Lấy mã sản phẩm (dùng cho Sửa và Xóa)
        string imagesFolder = Application.StartupPath.Replace("bin\\Debug\\net5.0-windows", "Images");
        public frmSanPham()
        {

            InitializeComponent();
        }
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            cboHangSanXuat.Enabled = giaTri;
            cboLoaiSanPham.Enabled = giaTri;
            txtTenSanPham.Enabled = giaTri;
            numSoLuong.Enabled = giaTri;
            numDonGia.Enabled = giaTri;
            txtMoTa.Enabled = giaTri;
            picHinhAnh.Enabled = giaTri;
            btnThem.Enabled = !giaTri;
            btnDoiAnh.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnTimKiem.Enabled = !giaTri;
            btnNhap.Enabled = !giaTri;
            btnXuat.Enabled = !giaTri;
        }
        public void LayLoaiSanPhamVaoComboBox()
        {
            cboLoaiSanPham.DataSource = context.LoaiSanPham.ToList();
            cboLoaiSanPham.ValueMember = "ID";
            cboLoaiSanPham.DisplayMember = "TenLoai";
        }
        public void LayHangSanXuatVaoComboBox()
        {
            cboHangSanXuat.DataSource = context.HangSanXuat.ToList();
            cboHangSanXuat.ValueMember = "ID";
            cboHangSanXuat.DisplayMember = "TenHangSanXuat";
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            context = new QLBHDbContext(); // Khởi tạo lại ngữ cảnh CSDL để đảm bảo dữ liệu mới nhất được tải lên
            BatTatChucNang(false);
            LayLoaiSanPhamVaoComboBox();
            LayHangSanXuatVaoComboBox();
            dataGridView.AutoGenerateColumns = false;
            List<DanhSachSanPham> sp = new List<DanhSachSanPham>();
            sp = context.SanPham.Select(r => new DanhSachSanPham
            {
                ID = r.ID,
                LoaiSanPhamID = r.LoaiSanPhamID,
                TenLoai = r.LoaiSanPham.TenLoai,
                HangSanXuatID = r.HangSanXuatID,
                TenHangSanXuat = r.HangSanXuat.TenHangSanXuat,
                TenSanPham = r.TenSanPham,
                SoLuong = r.SoLuong,
                DonGia = r.DonGia,
                HinhAnh = r.HinhAnh
            }).ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = sp;
            cboLoaiSanPham.DataBindings.Clear();
            cboLoaiSanPham.DataBindings.Add("SelectedValue", bindingSource, "LoaiSanPhamID", false, DataSourceUpdateMode.Never);
            cboHangSanXuat.DataBindings.Clear();
            cboHangSanXuat.DataBindings.Add("SelectedValue", bindingSource, "HangSanXuatID", false, DataSourceUpdateMode.Never);
            txtTenSanPham.DataBindings.Clear();
            txtTenSanPham.DataBindings.Add("Text", bindingSource, "TenSanPham", false, DataSourceUpdateMode.Never);
            txtMoTa.DataBindings.Clear();
            txtMoTa.DataBindings.Add("Text", bindingSource, "MoTa", false, DataSourceUpdateMode.Never);
            numSoLuong.DataBindings.Clear();
            numSoLuong.DataBindings.Add("Value", bindingSource, "SoLuong", false, DataSourceUpdateMode.Never);
            numDonGia.DataBindings.Clear();
            numDonGia.DataBindings.Add("Value", bindingSource, "DonGia", false, DataSourceUpdateMode.Never);
            picHinhAnh.DataBindings.Clear();
            Binding hinhAnh = new Binding("ImageLocation", bindingSource, "HinhAnh");
            hinhAnh.Format += (s, e) =>
            {
                e.Value = Path.Combine(imagesFolder, e.Value.ToString());
            };
            picHinhAnh.DataBindings.Add(hinhAnh);
            dataGridView.DataSource = bindingSource;
            TaoCacHelpString();
        }
        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "HinhAnh")
            {
                Image image = Image.FromFile(Path.Combine(imagesFolder, e.Value.ToString()));
                image = new Bitmap(image, 24, 24);
                e.Value = image;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            cboLoaiSanPham.Text = "";
            cboHangSanXuat.Text = "";
            txtTenSanPham.Clear();
            txtMoTa.Clear();
            numSoLuong.Value = 0;
            numDonGia.Value = 0;
            picHinhAnh.Image = null;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                xuLyThem = false;
                BatTatChucNang(true);

                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);

                txtTenSanPham.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể chuyển sang chế độ sửa.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BatTatChucNang(false);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboLoaiSanPham.Text))
                MessageBox.Show("Vui lòng chọn loại sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(cboHangSanXuat.Text))
                MessageBox.Show("Vui lòng chọn hãng sản xuất.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(txtTenSanPham.Text))
                MessageBox.Show("Vui lòng nhập tên sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numSoLuong.Value <= 0)
                MessageBox.Show("Số lượng phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numDonGia.Value <= 0)
                MessageBox.Show("Đơn giá sản phẩm phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (xuLyThem)
                {
                    SanPham sp = new SanPham();
                    sp.LoaiSanPhamID = Convert.ToInt32(cboLoaiSanPham.SelectedValue);
                    sp.HangSanXuatID = Convert.ToInt32(cboHangSanXuat.SelectedValue);
                    sp.TenSanPham = txtTenSanPham.Text;
                    sp.SoLuong = Convert.ToInt32(numSoLuong.Value);
                    sp.DonGia = Convert.ToInt32(numDonGia.Value);
                    sp.MoTa = txtMoTa.Text;
                    sp.HinhAnh = "no-image.png"; // Gán ảnh mặc định để tránh lỗi null khi load lại

                    context.SanPham.Add(sp);
                    context.SaveChanges();
                    context.SaveChanges();
                }
                else
                {
                    {

                        using (var db = new QLBHDbContext()) // Tạo kết nối mới để đảm bảo dữ liệu được cập nhật mới nhất từ CSDL, tránh trường hợp dữ liệu cũ trong context hiện tại chưa được cập nhật sau khi sửa xong mà vẫn dùng để tìm kiếm sản phẩm cần sửa, dẫn đến lỗi không tìm thấy sản phẩm cần sửa
                        {
                            var sp = db.SanPham.Find(id);

                            if (sp != null)
                            {
                                sp.LoaiSanPhamID = Convert.ToInt32(cboLoaiSanPham.SelectedValue);
                                sp.HangSanXuatID = Convert.ToInt32(cboHangSanXuat.SelectedValue);
                                sp.TenSanPham = txtTenSanPham.Text;
                                sp.SoLuong = Convert.ToInt32(numSoLuong.Value);
                                sp.DonGia = Convert.ToInt32(numDonGia.Value);
                                sp.MoTa = txtMoTa.Text;

                                // 4. Bắt buộc Entity Framework hiểu là dòng này ĐÃ SỬA (Quan trọng!)
                                // Dòng này giúp tránh trường hợp EF thấy giá trị giống nhau nên không thèm lưu
                                db.Entry(sp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                                // 5. Lưu
                                db.SaveChanges();
                                MessageBox.Show("Cập nhật thành công!");
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy sản phẩm có ID = " + id);
                            }
                        }
                    }
                    frmSanPham_Load(sender, e);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa sản phẩm " + txtTenSanPham.Text + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                SanPham sp = context.SanPham.Find(id);
                if (sp != null)
                {
                    context.SanPham.Remove(sp);
                }
                context.SaveChanges();
                frmSanPham_Load(sender, e);
            }

        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmSanPham_Load(sender, e);

        }

        private void btnDoiAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Cập nhật hình ảnh sản phẩm";
            openFileDialog.Filter = "Tập tin hình ảnh|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                string ext = Path.GetExtension(openFileDialog.FileName);
                string fileSavePath = Path.Combine(imagesFolder, fileName.GenerateSlug() + ext);
                File.Copy(openFileDialog.FileName, fileSavePath, true);
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                SanPham sp = context.SanPham.Find(id);
                sp.HinhAnh = fileName.GenerateSlug() + ext;
                context.SanPham.Update(sp);
                context.SaveChanges();
                frmSanPham_Load(sender, e);
            }

        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Nhập dữ liệu từ tập tin Excel";
            openFileDialog.Filter = "Tập tin Excel|*.xls;*.xlsx";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    using (XLWorkbook workbook = new XLWorkbook(openFileDialog.FileName))
                    {
                        IXLWorksheet worksheet = workbook.Worksheet(1);
                        bool firstRow = true;
                        string readRange = "1:1";
                        foreach (IXLRow row in worksheet.RowsUsed())
                        {
                            // Đọc dòng tiêu đề (dòng đầu tiên)
                            if (firstRow)
                            {
                                readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                                foreach (IXLCell cell in row.Cells(readRange))
                                    table.Columns.Add(cell.Value.ToString());
                                firstRow = false;
                            }
                            else // Đọc các dòng nội dung (các dòng tiếp theo)
                            {
                                table.Rows.Add();
                                int cellIndex = 0;
                                foreach (IXLCell cell in row.Cells(readRange))
                                {
                                    table.Rows[table.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                    cellIndex++;
                                }
                            }
                        }
                        if (table.Rows.Count > 0)
                        {
                            foreach (DataRow r in table.Rows)
                            {
                                SanPham sp = new SanPham();
                                sp.LoaiSanPhamID = context.LoaiSanPham.Where(l => l.TenLoai == r["TenLoai"].ToString()).Select(l => l.ID).FirstOrDefault();
                                sp.TenSanPham = r["TenLoai"].ToString();
                                sp.HangSanXuatID = context.HangSanXuat.Where(h => h.TenHangSanXuat == r["TenHangSanXuat"].ToString()).Select(h => h.ID).FirstOrDefault();
                                sp.SoLuong = Convert.ToInt32(r["SoLuong"].ToString());
                                sp.DonGia = Convert.ToInt32(r["DonGia"].ToString());
                                sp.MoTa = r["MoTa"].ToString();
                                sp.HinhAnh = "no-image.png"; // Gán ảnh mặc định để tránh lỗi null khi load lại
                                context.SanPham.Add(sp);
                            }
                            context.SaveChanges();
                            MessageBox.Show("Đã nhập thành công " + table.Rows.Count + " dòng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmSanPham_Load(sender, e);
                        }
                        if (firstRow)
                            MessageBox.Show("Tập tin Excel rỗng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất dữ liệu ra tập tin Excel";
            saveFileDialog.Filter = "Tập tin Excel|*.xls;*.xlsx";
            saveFileDialog.FileName = "SanPham_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[8] {
                    new DataColumn("ID", typeof(int)),
                    new DataColumn("loaisanphamID", typeof(int)),
                    new DataColumn("hangsanxuatID", typeof(int)),
                    new DataColumn("TenSanPham", typeof(string)),
                    new DataColumn("DonGia", typeof(int)),
                    new DataColumn("SoLuong", typeof(int)),
                    new DataColumn("HinhAnh", typeof(string)),
                    new DataColumn("MoTa", typeof(string)),
                    });
                    var SanPham = context.SanPham.ToList();
                    if (SanPham != null)
                    {
                        foreach (var p in SanPham)
                            table.Rows.Add(p.ID, p.LoaiSanPhamID, p.HangSanXuatID, p.TenSanPham, p.DonGia, p.SoLuong, p.HinhAnh, p.MoTa); ;
                    }
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "SanPham");
                        sheet.Columns().AdjustToContents();
                        wb.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Đã xuất dữ liệu ra tập tin Excel thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void TaoCacHelpString()
        {
            toolTip1.SetToolTip(btnThem, "Nhấn vào đây để thêm sản phẩm mới.");
            toolTip1.SetToolTip(btnSua, "Nhấn vào đây để sửa thông tin sản phẩm đã chọn.");
            toolTip1.SetToolTip(btnXoa, "Nhấn vào đây để xóa sản phẩm đã chọn.");
            toolTip1.SetToolTip(btnLuu, "Nhấn vào đây để lưu thông tin sản phẩm đang thêm hoặc sửa.");
            toolTip1.SetToolTip(btnHuyBo, "Nhấn vào đây để hủy bỏ thao tác đang thực hiện.");
            toolTip1.SetToolTip(btnDoiAnh, "Nhấn vào đây để thay đổi hình ảnh sản phẩm.");
            toolTip1.SetToolTip(btnTimKiem, "Nhấn vào đây để tìm kiếm sản phẩm theo tên.");
            toolTip1.SetToolTip(btnNhap, "Nhấn vào đây để nhập danh sách sản phẩm từ tập tin Excel.");
            toolTip1.SetToolTip(btnXuat, "Nhấn vào đây để xuất danh sách sản phẩm ra tập tin Excel.");
            toolTip1.SetToolTip(btnThoat, "Nhấn vào đây để thoát");
            toolTip1.SetToolTip(dataGridView, "Danh sách sản phẩm. Bạn có thể chọn một sản phẩm để sửa hoặc xóa.");
            toolTip1.SetToolTip(cboLoaiSanPham, "Chọn loại sản phẩm.");
            toolTip1.SetToolTip(cboHangSanXuat, "Chọn hãng sản xuất.");
            toolTip1.SetToolTip(txtTenSanPham, "Nhập tên sản phẩm.");
            toolTip1.SetToolTip(numSoLuong, "Nhập số lượng sản phẩm.");
            toolTip1.SetToolTip(numDonGia, "Nhập đơn giá sản phẩm.");
            toolTip1.SetToolTip(txtMoTa, "Nhập mô tả sản phẩm.");

        }
    }
    }
    public static class StringExtensions
    {
        // Hàm chuyển đổi chuỗi có dấu thành không dấu (Slug)
        public static string GenerateSlug(this string phrase)
        {
            if (string.IsNullOrEmpty(phrase)) return "";

            string str = phrase.ToLower();

            // Thay thế các ký tự tiếng Việt
            str = Regex.Replace(str, @"[áàảạãăắằẳẵặâấầẩẫậ]", "a");
            str = Regex.Replace(str, @"[éèẻẽẹêếềểễệ]", "e");
            str = Regex.Replace(str, @"[iíìỉĩị]", "i");
            str = Regex.Replace(str, @"[óòỏõọôốồổỗộơớờởỡợ]", "o");
            str = Regex.Replace(str, @"[úùủũụưứừửữự]", "u");
            str = Regex.Replace(str, @"[ýỳỷỹỵ]", "y");
            str = Regex.Replace(str, @"đ", "d");

            // Loại bỏ các ký tự đặc biệt không được phép trong tên file
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");

            // Chuyển khoảng trắng thành gạch ngang
            str = Regex.Replace(str, @"\s+", "-").Trim();

            return str;
        }
    }

