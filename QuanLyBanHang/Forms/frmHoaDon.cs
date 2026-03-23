using ClosedXML.Excel;
using QuanLyBanHang.Data;
using QuanLyBanHang.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.Forms
{
    public partial class frmHoaDon : Form
    {
        QLBHDbContext context = new QLBHDbContext(); // Khởi tạo biến ngữ cảnh CSDL
        int id;
        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Columns["TongTienHoaDon"].DataPropertyName = "TongTienHoaDon";
            dataGridView.Columns["XemChiTiet"].DataPropertyName = "XemChiTiet";
            List<DanhSachHoaDon> hd = new List<DanhSachHoaDon>();
            hd = context.HoaDon.Select(r => new DanhSachHoaDon
            {
                ID = r.ID,
                NhanVienID = r.NhanVienID,
                HoVaTenNhanVien = r.NhanVien.HoVaTen,
                KhachHangID = r.KhachHangID,
                HoVaTenKhachHang = r.KhachHang.HoVaTen,
                NgayLap = r.NgayLap,
                GhiChuHoaDon = r.GhiChuHoaDon,
                TongTienHoaDon = r.HoaDon_ChiTiet.Sum(r => r.SoLuongBan * r.DonGiaBan),
                XemChiTiet = "Xem chi tiết"
            }).ToList();
            dataGridView.DataSource = hd;
            TaoCacHelpString();
        }
        private void btnLapHoaDon_Click(object sender, EventArgs e)
        {
            using (frmHoaDon_ChiTiet chiTiet = new frmHoaDon_ChiTiet())
            {
                chiTiet.ShowDialog();
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            using (frmHoaDon_ChiTiet chiTiet = new frmHoaDon_ChiTiet(id))
            {
                chiTiet.ShowDialog();
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Lấy ID của hóa đơn cần xóa từ DataGridView
            int id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            if (MessageBox.Show("Xác nhận xóa hóa đơn?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Tìm hóa đơn trong cơ sở dữ liệu
                HoaDon hoaDon = context.HoaDon.Find(id);
                if (hoaDon != null)
                {
                    // Xóa hóa đơn khỏi cơ sở dữ liệu
                    context.HoaDon.Remove(hoaDon);
                    context.SaveChanges();
                    // Cập nhật lại DataGridView sau khi xóa
                    frmHoaDon_Load(sender, e);
                }
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.Title = "Xuất dữ liệu ra tập tin Excel";
            saveFileDialog.FileName = "DanhSachHoaDon_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Danh sách hóa đơn");
                        // Thêm tiêu đề cột
                        for (int i = 0; i < dataGridView.Columns.Count; i++)
                        {
                            worksheet.Cell(1, i + 1).Value = dataGridView.Columns[i].HeaderText;
                        }
                        // Thêm dữ liệu từ DataGridView
                        for (int i = 0; i < dataGridView.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataGridView.Columns.Count; j++)
                            {
                                worksheet.Cell(i + 2, j + 1).Value = dataGridView.Rows[i].Cells[j].Value?.ToString() ?? "";
                            }
                        }
                        // Lưu tập tin Excel
                        workbook.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx";
            openFileDialog.Title = "Nhập dữ liệu từ tập tin Excel";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook workbook = new XLWorkbook(openFileDialog.FileName))
                    {
                        var worksheet = workbook.Worksheet(1); // Lấy sheet đầu tiên
                        var rows = worksheet.RangeUsed().RowsUsed().Skip(1); // Bỏ qua hàng tiêu đề
                        foreach (var row in rows)
                        {
                            // Đọc dữ liệu từ từng cột và tạo đối tượng HoaDon
                            HoaDon hoaDon = new HoaDon
                            {
                                NhanVienID = Convert.ToInt32(row.Cell(2).Value), // Cột NhanVienID
                                KhachHangID = Convert.ToInt32(row.Cell(4).Value), // Cột KhachHangID
                                NgayLap = Convert.ToDateTime(row.Cell(6).Value), // Cột NgayLap
                                GhiChuHoaDon = row.Cell(7).Value.ToString() // Cột GhiChuHoaDon
                            };
                            context.HoaDon.Add(hoaDon);
                        }
                        context.SaveChanges();
                        MessageBox.Show("Nhập dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmHoaDon_Load(sender, e); // Tải lại dữ liệu sau khi nhập
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi nhập dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            using (frmInHoaDon inHoaDon = new frmInHoaDon(id))
            {
                inHoaDon.ShowDialog();
            }

        }
        private void TaoCacHelpString()
        {
            toolTip1.SetToolTip(btnLapHoaDon, "Nhấn vào đây để lập hóa đơn mới.");
            toolTip1.SetToolTip(btnSua, "Nhấn vào đây để sửa hóa đơn đã chọn.");
            toolTip1.SetToolTip(btnXoa, "Nhấn vào đây để xóa hóa đơn đã chọn.");
            toolTip1.SetToolTip(btnXuat, "Nhấn vào đây để xuất danh sách hóa đơn ra tập tin Excel.");
            toolTip1.SetToolTip(btnNhap, "Nhấn vào đây để nhập danh sách hóa đơn từ tập tin Excel.");
            toolTip1.SetToolTip(btnInHoaDon, "Nhấn vào đây để in hóa đơn đã chọn.");
            toolTip1.SetToolTip(dataGridView, "Danh sách hóa đơn. Bạn có thể chọn một hóa đơn để sửa, xóa hoặc in.");
            toolTip1.SetToolTip(btnTimKiem, "Nhấn vào đây để tìm kiếm hóa đơn theo tên nhân viên hoặc khách hàng.");
            toolTip1.SetToolTip(btnThoat, "Nhấn vào đây để thoát khỏi màn hình");
        }
    }
}
