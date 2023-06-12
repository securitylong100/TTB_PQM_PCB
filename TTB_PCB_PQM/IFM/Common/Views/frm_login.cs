using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace IFM.Common.Views
{
    public partial class frm_login : XtraForm
    {
        public frm_login()
        {
            InitializeComponent();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (this.Visible)
            {
                bsi_version.Caption = $"[ver{ClsSession.App.Version}]";
                txt_user.Text = ClsSession.App.Settings.UserName;
                cb_remember_user.Checked = !string.IsNullOrEmpty(txt_user.Text);
                txt_user.Focus();
                txt_user.SelectAll();
            }
            base.OnVisibleChanged(e);
        }

        private void Btn_confirm_Click(object sender, EventArgs e)
        {
            try
            {
                ClsSession.App.SplashScreen.ShowWaitForm();
                ClsSession.App.SplashScreen.SetWaitFormCaption("Đăng Nhập");
                ClsSession.App.SplashScreen.SetWaitFormDescription("Đang đăng nhập...");
                if (string.IsNullOrWhiteSpace(txt_user.Text))
                {
                    bsi_status.Caption = "Tên đăng nhập không được bỏ trống";
                    txt_user.Focus();
                    txt_user.SelectAll();
                    //MessageBox.Show("Tên đăng nhập không được bỏ trống", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txt_pass.Text))
                {
                    bsi_status.Caption = "Mật Khẩu không được bỏ trống";
                    txt_pass.Focus();
                    txt_pass.SelectAll();
                    //MessageBox.Show("Mật Khẩu không được bỏ trống", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ClsSession.App.Settings.UserName = cb_remember_user.Checked ? txt_user.Text : string.Empty;
                ClsSession.App.SaveSettings();
                if (ClsSession.App.Login(txt_user.Text, txt_pass.Text))
                {
                    if (!cb_remember_user.Checked) txt_user.Text = string.Empty;
                    txt_pass.Text = string.Empty;
                    bsi_status.Caption = string.Empty;
                    txt_user.Focus();
                    txt_user.SelectAll();
                    ClsSession.App.SplashScreen.SetWaitFormDescription("Đang mở dashboard...");
                    frm_dashboard dashboard = new frm_dashboard();
                    dashboard.FormClosed += (obj, ev) => this.Show();
                    dashboard.Show();
                    this.Hide();
                    return;
                }
                bsi_status.Caption = "Tên đăng nhập hoặc Mật khẩu không đúng";
                txt_user.Focus();
                txt_user.SelectAll();
            }
            finally
            {
                ClsSession.App.SplashScreen.CloseWaitForm();
            }
        }

        private void Txt_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Tab)
                btn_confirm.PerformClick();
        }
    }
}