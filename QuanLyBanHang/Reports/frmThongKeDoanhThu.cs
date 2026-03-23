using Microsoft.Reporting.WinForms;
using QuanLyBanHang.Data;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyBanHang.Reports
{
    public partial class frmThongKeDoanhThu : Form
    {
        private readonly QLBHDbContext context = new QLBHDbContext();

        private readonly QLBHDataSet.DanhSachHoaDon_ChiTietDataTable danhSachHoaDonDataTable =
            new QLBHDataSet.DanhSachHoaDon_ChiTietDataTable();

        private readonly string reportsFolder = Path.GetFullPath(
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Reports")
        );

        public frmThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void frmThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            try
            {
                var danhSachHoaDon = context.HoaDon_ChiTiet
                    .Select(r => new
                    {
                        r.ID,
                        r.HoaDonID,
                        r.SanPhamID,
                        TenSanPham = r.SanPham.TenSanPham,
                        SoLuongBan = (short)r.SoLuongBan,
                        r.DonGiaBan,
                        ThanhTien = (int)(r.SoLuongBan * r.DonGiaBan)
                    })
                    .ToList();

                danhSachHoaDonDataTable.Clear();

                foreach (var row in danhSachHoaDon)
                {
                    danhSachHoaDonDataTable.AddDanhSachHoaDon_ChiTietRow(
                        row.ID,
                        row.HoaDonID,
                        row.SanPhamID,
                        row.TenSanPham,
                        row.SoLuongBan,
                        row.DonGiaBan,
                        row.ThanhTien
                    );
                }
                this.Controls.Add(reportViewer1);

                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DanhSachCTHD";
                reportDataSource.Value = (DataTable)danhSachHoaDonDataTable;

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                reportViewer1.LocalReport.ReportPath =
                    Path.Combine(reportsFolder, "rptThongKeDoanhThu.rdlc");

                ReportParameter reportParameter =
                    new ReportParameter("MoTaKetQuaHienThi", "(Tất cả thời gian)");

                reportViewer1.LocalReport.SetParameters(reportParameter);

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị report: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLocKetQua_Click(object sender, EventArgs e)
        {
            try
            {
                var tuNgay = dtpTuNgay.Value.Date;
                var denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1);

                var danhSachHoaDon = context.HoaDon_ChiTiet
                    .Where(ct => ct.HoaDon.NgayLap >= tuNgay && ct.HoaDon.NgayLap <= denNgay)
                    .Select(r => new
                    {
                        r.ID,
                        r.HoaDonID,
                        r.SanPhamID,
                        TenSanPham = r.SanPham.TenSanPham,
                        SoLuongBan = (short)r.SoLuongBan,
                        r.DonGiaBan,
                        ThanhTien = (int)(r.SoLuongBan * r.DonGiaBan)
                    })
                    .ToList();

                danhSachHoaDonDataTable.Clear();

                foreach (var row in danhSachHoaDon)
                {
                    danhSachHoaDonDataTable.AddDanhSachHoaDon_ChiTietRow(
                        row.ID,
                        row.HoaDonID,
                        row.SanPhamID,
                        row.TenSanPham,
                        row.SoLuongBan,
                        row.DonGiaBan,
                        row.ThanhTien
                    );
                }

                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DanhSachCTHD";
                reportDataSource.Value = (DataTable)danhSachHoaDonDataTable;

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                reportViewer1.LocalReport.ReportPath =
                    Path.Combine(reportsFolder, "rptThongKeDoanhThu.rdlc");

                ReportParameter reportParameter = new ReportParameter(
                    "MoTaKetQuaHienThi",
                    "Từ ngày " + dtpTuNgay.Text + " - Đến ngày: " + dtpDenNgay.Text
                );

                reportViewer1.LocalReport.SetParameters(reportParameter);

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lọc dữ liệu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            try
            {
                var danhSachHoaDon = context.HoaDon_ChiTiet
                    .Select(r => new
                    {
                        r.ID,
                        r.HoaDonID,
                        r.SanPhamID,
                        TenSanPham = r.SanPham.TenSanPham,
                        SoLuongBan = (short)r.SoLuongBan,
                        r.DonGiaBan,
                        ThanhTien = (int)(r.SoLuongBan * r.DonGiaBan)
                    })
                    .ToList();

                danhSachHoaDonDataTable.Clear();

                foreach (var row in danhSachHoaDon)
                {
                    danhSachHoaDonDataTable.AddDanhSachHoaDon_ChiTietRow(
                        row.ID,
                        row.HoaDonID,
                        row.SanPhamID,
                        row.TenSanPham,
                        row.SoLuongBan,
                        row.DonGiaBan,
                        row.ThanhTien
                    );
                }

                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DanhSachCTHD";
                reportDataSource.Value = (DataTable)danhSachHoaDonDataTable;

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                reportViewer1.LocalReport.ReportPath =
                    Path.Combine(reportsFolder, "rptThongKeDoanhThu.rdlc");

                ReportParameter reportParameter =
                    new ReportParameter("MoTaKetQuaHienThi", "(Tất cả thời gian)");

                reportViewer1.LocalReport.SetParameters(reportParameter);

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị tất cả: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}