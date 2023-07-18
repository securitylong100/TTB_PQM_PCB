namespace IFM.Common.Views
{
    partial class frm_login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_login));
            this.bm_main = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.cbo_skins = new DevExpress.XtraBars.SkinDropDownButtonItem();
            this.bsi_status = new DevExpress.XtraBars.BarStaticItem();
            this.bsi_version = new DevExpress.XtraBars.BarStaticItem();
            this.tbl_main = new DevExpress.Utils.Layout.TablePanel();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.btn_confirm = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cb_remember_user = new DevExpress.XtraEditors.CheckEdit();
            this.txt_pass = new DevExpress.XtraEditors.TextEdit();
            this.txt_user = new DevExpress.XtraEditors.TextEdit();
            this.lbl_user = new DevExpress.XtraEditors.LabelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.bm_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_main)).BeginInit();
            this.tbl_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cb_remember_user.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_pass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_user.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // bm_main
            // 
            this.bm_main.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3});
            this.bm_main.DockControls.Add(this.barDockControlTop);
            this.bm_main.DockControls.Add(this.barDockControlBottom);
            this.bm_main.DockControls.Add(this.barDockControlLeft);
            this.bm_main.DockControls.Add(this.barDockControlRight);
            this.bm_main.Form = this;
            this.bm_main.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.cbo_skins,
            this.bsi_status,
            this.bsi_version});
            this.bm_main.MaxItemId = 3;
            this.bm_main.StatusBar = this.bar3;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.bm_main;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.barDockControlTop.Size = new System.Drawing.Size(440, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 265);
            this.barDockControlBottom.Manager = this.bm_main;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.barDockControlBottom.Size = new System.Drawing.Size(440, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.bm_main;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 265);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(440, 0);
            this.barDockControlRight.Manager = this.bm_main;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 265);
            // 
            // cbo_skins
            // 
            this.cbo_skins.Id = 0;
            this.cbo_skins.Name = "cbo_skins";
            // 
            // bsi_status
            // 
            this.bsi_status.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring;
            this.bsi_status.Id = 1;
            this.bsi_status.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsi_status.ItemAppearance.Normal.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Critical;
            this.bsi_status.ItemAppearance.Normal.Options.UseFont = true;
            this.bsi_status.ItemAppearance.Normal.Options.UseForeColor = true;
            this.bsi_status.Name = "bsi_status";
            this.bsi_status.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // bsi_version
            // 
            this.bsi_version.Caption = "Version";
            this.bsi_version.Id = 2;
            this.bsi_version.Name = "bsi_version";
            // 
            // tbl_main
            // 
            this.tbl_main.Appearance.BackColor = System.Drawing.Color.White;
            this.tbl_main.Appearance.Options.UseBackColor = true;
            this.tbl_main.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
            this.tbl_main.Controls.Add(this.tablePanel1);
            this.tbl_main.Controls.Add(this.lblTitle);
            this.tbl_main.Controls.Add(this.pictureEdit1);
            this.tbl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_main.Location = new System.Drawing.Point(0, 0);
            this.tbl_main.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbl_main.Name = "tbl_main";
            this.tbl_main.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 64F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 26F)});
            this.tbl_main.Size = new System.Drawing.Size(440, 265);
            this.tbl_main.TabIndex = 5;
            this.tbl_main.UseSkinIndents = true;
            // 
            // tablePanel1
            // 
            this.tbl_main.SetColumn(this.tablePanel1, 0);
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 60F)});
            this.tbl_main.SetColumnSpan(this.tablePanel1, 2);
            this.tablePanel1.Controls.Add(this.btn_confirm);
            this.tablePanel1.Controls.Add(this.labelControl1);
            this.tablePanel1.Controls.Add(this.cb_remember_user);
            this.tablePanel1.Controls.Add(this.txt_pass);
            this.tablePanel1.Controls.Add(this.txt_user);
            this.tablePanel1.Controls.Add(this.lbl_user);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(13, 76);
            this.tablePanel1.Name = "tablePanel1";
            this.tbl_main.SetRow(this.tablePanel1, 1);
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 36F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 48F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(414, 176);
            this.tablePanel1.TabIndex = 2;
            this.tablePanel1.UseSkinIndents = true;
            // 
            // btn_confirm
            // 
            this.tablePanel1.SetColumn(this.btn_confirm, 1);
            this.btn_confirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_confirm.Location = new System.Drawing.Point(137, 116);
            this.btn_confirm.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.btn_confirm.Name = "btn_confirm";
            this.tablePanel1.SetRow(this.btn_confirm, 3);
            this.btn_confirm.Size = new System.Drawing.Size(236, 42);
            this.btn_confirm.TabIndex = 6;
            this.btn_confirm.Text = "Login";
            this.btn_confirm.Click += new System.EventHandler(this.Btn_confirm_Click);
            // 
            // labelControl1
            // 
            this.tablePanel1.SetColumn(this.labelControl1, 0);
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("labelControl1.ImageOptions.SvgImage")));
            this.labelControl1.Location = new System.Drawing.Point(13, 52);
            this.labelControl1.Name = "labelControl1";
            this.tablePanel1.SetRow(this.labelControl1, 1);
            this.labelControl1.Size = new System.Drawing.Size(92, 36);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Password:";
            // 
            // cb_remember_user
            // 
            this.tablePanel1.SetColumn(this.cb_remember_user, 1);
            this.cb_remember_user.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_remember_user.Location = new System.Drawing.Point(109, 92);
            this.cb_remember_user.MenuManager = this.bm_main;
            this.cb_remember_user.Name = "cb_remember_user";
            this.cb_remember_user.Properties.Caption = "Rember user";
            this.tablePanel1.SetRow(this.cb_remember_user, 2);
            this.cb_remember_user.Size = new System.Drawing.Size(292, 19);
            this.cb_remember_user.TabIndex = 4;
            // 
            // txt_pass
            // 
            this.tablePanel1.SetColumn(this.txt_pass, 1);
            this.txt_pass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_pass.Location = new System.Drawing.Point(112, 60);
            this.txt_pass.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.txt_pass.MenuManager = this.bm_main;
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.Properties.UseSystemPasswordChar = true;
            this.tablePanel1.SetRow(this.txt_pass, 1);
            this.txt_pass.Size = new System.Drawing.Size(286, 20);
            this.txt_pass.TabIndex = 3;
            this.txt_pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_pass_KeyDown);
            // 
            // txt_user
            // 
            this.tablePanel1.SetColumn(this.txt_user, 1);
            this.txt_user.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_user.EnterMoveNextControl = true;
            this.txt_user.Location = new System.Drawing.Point(112, 20);
            this.txt_user.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.txt_user.MenuManager = this.bm_main;
            this.txt_user.Name = "txt_user";
            this.txt_user.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_user.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tablePanel1.SetRow(this.txt_user, 0);
            this.txt_user.Size = new System.Drawing.Size(286, 20);
            this.txt_user.TabIndex = 2;
            // 
            // lbl_user
            // 
            this.tablePanel1.SetColumn(this.lbl_user, 0);
            this.lbl_user.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_user.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lbl_user.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lbl_user.ImageOptions.Image")));
            this.lbl_user.Location = new System.Drawing.Point(13, 12);
            this.lbl_user.Name = "lbl_user";
            this.tablePanel1.SetRow(this.lbl_user, 0);
            this.lbl_user.Size = new System.Drawing.Size(92, 36);
            this.lbl_user.TabIndex = 0;
            this.lbl_user.Text = "User name:";
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Appearance.Options.UseTextOptions = true;
            this.lblTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTitle.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblTitle.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.tbl_main.SetColumn(this.lblTitle, 1);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Location = new System.Drawing.Point(136, 15);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.lblTitle.Name = "lblTitle";
            this.tbl_main.SetRow(this.lblTitle, 0);
            this.lblTitle.Size = new System.Drawing.Size(287, 54);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Nidec Corporation ";
            // 
            // pictureEdit1
            // 
            this.tbl_main.SetColumn(this.pictureEdit1, 0);
            this.pictureEdit1.EditValue = global::IFM.Properties.Resources.ifm_horizontal;
            this.pictureEdit1.Location = new System.Drawing.Point(17, 23);
            this.pictureEdit1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pictureEdit1.MenuManager = this.bm_main;
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowMenu = false;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.tbl_main.SetRow(this.pictureEdit1, 0);
            this.pictureEdit1.Size = new System.Drawing.Size(107, 38);
            this.pictureEdit1.TabIndex = 0;
            // 
            // frm_login
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 288);
            this.Controls.Add(this.tbl_main);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IconOptions.Image = global::IFM.Properties.Resources.ifm_vertical1;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.bm_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_main)).EndInit();
            this.tbl_main.ResumeLayout(false);
            this.tbl_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cb_remember_user.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_pass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_user.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.BarManager bm_main;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.SkinDropDownButtonItem cbo_skins;
        private DevExpress.XtraBars.BarStaticItem bsi_status;
        private DevExpress.Utils.Layout.TablePanel tbl_main;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.CheckEdit cb_remember_user;
        private DevExpress.XtraEditors.TextEdit txt_pass;
        private DevExpress.XtraEditors.TextEdit txt_user;
        private DevExpress.XtraEditors.LabelControl lbl_user;
        private DevExpress.XtraEditors.SimpleButton btn_confirm;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraBars.BarStaticItem bsi_version;
    }
}