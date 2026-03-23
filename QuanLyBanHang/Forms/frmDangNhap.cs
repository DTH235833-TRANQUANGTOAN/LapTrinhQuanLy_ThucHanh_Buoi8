using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHang.Data;
using QuanLyBanHang.Forms;
namespace QuanLyBanHang.Forms
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;


        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            helpProvider1.SetShowHelp(btnDangNhap, true);
                helpProvider1.SetHelpString(btnDangNhap, "Nhấn vào đây để đăng nhập vào hệ thống.");
            helpProvider1.SetShowHelp(btnHuyBo, true);
                helpProvider1.SetHelpString(btnHuyBo, "Nhấn vào đây để hủy đăng nhập và thoát chương trình.");
            helpProvider1.SetShowHelp(txtTenDangNhap, true);
                helpProvider1.SetHelpString(txtTenDangNhap, "Nhập tên đăng nhập của bạn vào đây.");
            helpProvider1.SetShowHelp(txtMatKhau, true);
                helpProvider1.SetHelpString(txtMatKhau, "Nhập mật khẩu của bạn vào đây. Bạn có thể nhấn Enter để đăng nhập nhanh.");
        }
    }
}
