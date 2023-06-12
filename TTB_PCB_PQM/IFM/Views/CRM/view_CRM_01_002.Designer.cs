
namespace IFM.Views.CRM
{
    partial class view_CRM_01_002
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(view_CRM_01_002));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.calc_bonussalary = new DevExpress.XtraEditors.CalcEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.calc_Basicsalary = new DevExpress.XtraEditors.CalcEdit();
            this.chb_insurance = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chb_user = new System.Windows.Forms.CheckBox();
            this.cbm_username = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbm_usercd = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_add = new System.Windows.Forms.Button();
            this.lbl_rowscount = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.gc_main = new DevExpress.XtraGrid.GridControl();
            this.gv_main = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemToggleSwitch1 = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calc_bonussalary.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calc_Basicsalary.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemToggleSwitch1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.gc_main, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(746, 474);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.calc_bonussalary);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.calc_Basicsalary);
            this.panel1.Controls.Add(this.chb_insurance);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.chb_user);
            this.panel1.Controls.Add(this.cbm_username);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbm_usercd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 94);
            this.panel1.TabIndex = 0;
            // 
            // calc_bonussalary
            // 
            this.calc_bonussalary.Location = new System.Drawing.Point(407, 57);
            this.calc_bonussalary.Name = "calc_bonussalary";
            this.calc_bonussalary.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calc_bonussalary.Size = new System.Drawing.Size(138, 20);
            this.calc_bonussalary.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(322, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Lương Thưởng";
            // 
            // calc_Basicsalary
            // 
            this.calc_Basicsalary.Location = new System.Drawing.Point(407, 17);
            this.calc_Basicsalary.Name = "calc_Basicsalary";
            this.calc_Basicsalary.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calc_Basicsalary.Size = new System.Drawing.Size(138, 20);
            this.calc_Basicsalary.TabIndex = 21;
            // 
            // chb_insurance
            // 
            this.chb_insurance.AutoSize = true;
            this.chb_insurance.Location = new System.Drawing.Point(646, 21);
            this.chb_insurance.Name = "chb_insurance";
            this.chb_insurance.Size = new System.Drawing.Size(15, 14);
            this.chb_insurance.TabIndex = 20;
            this.chb_insurance.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(587, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Bảo Hiểm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(322, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Lương Căn Bản";
            // 
            // chb_user
            // 
            this.chb_user.AutoSize = true;
            this.chb_user.Location = new System.Drawing.Point(249, 21);
            this.chb_user.Name = "chb_user";
            this.chb_user.Size = new System.Drawing.Size(15, 14);
            this.chb_user.TabIndex = 16;
            this.chb_user.UseVisualStyleBackColor = true;
            this.chb_user.CheckedChanged += new System.EventHandler(this.chb_user_CheckedChanged);
            // 
            // cbm_username
            // 
            this.cbm_username.FormattingEnabled = true;
            this.cbm_username.Location = new System.Drawing.Point(97, 56);
            this.cbm_username.Name = "cbm_username";
            this.cbm_username.Size = new System.Drawing.Size(167, 21);
            this.cbm_username.TabIndex = 15;
            this.cbm_username.SelectedIndexChanged += new System.EventHandler(this.cbm_username_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Tên Nhân Viên";
            // 
            // cbm_usercd
            // 
            this.cbm_usercd.FormattingEnabled = true;
            this.cbm_usercd.Location = new System.Drawing.Point(97, 17);
            this.cbm_usercd.Name = "cbm_usercd";
            this.cbm_usercd.Size = new System.Drawing.Size(146, 21);
            this.cbm_usercd.TabIndex = 6;
            this.cbm_usercd.SelectedIndexChanged += new System.EventHandler(this.cbm_usercd_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mã Nhân Viên";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_add);
            this.panel2.Controls.Add(this.lbl_rowscount);
            this.panel2.Controls.Add(this.btn_Search);
            this.panel2.Controls.Add(this.btn_export);
            this.panel2.Controls.Add(this.btn_save);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(6, 444);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(734, 24);
            this.panel2.TabIndex = 1;
            // 
            // btn_add
            // 
            this.btn_add.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.Image")));
            this.btn_add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_add.Location = new System.Drawing.Point(135, 1);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(96, 22);
            this.btn_add.TabIndex = 4;
            this.btn_add.Text = "    Add New";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // lbl_rowscount
            // 
            this.lbl_rowscount.AutoSize = true;
            this.lbl_rowscount.Location = new System.Drawing.Point(903, 6);
            this.lbl_rowscount.Name = "lbl_rowscount";
            this.lbl_rowscount.Size = new System.Drawing.Size(62, 13);
            this.lbl_rowscount.TabIndex = 3;
            this.lbl_rowscount.Text = "RowsCount";
            this.lbl_rowscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_Search
            // 
            this.btn_Search.Image = ((System.Drawing.Image)(resources.GetObject("btn_Search.Image")));
            this.btn_Search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Search.Location = new System.Drawing.Point(3, 1);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(85, 22);
            this.btn_Search.TabIndex = 2;
            this.btn_Search.Text = "     Load Data";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // btn_export
            // 
            this.btn_export.Image = global::IFM.Properties.Resources.Excel;
            this.btn_export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_export.Location = new System.Drawing.Point(412, 1);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(95, 22);
            this.btn_export.TabIndex = 1;
            this.btn_export.Text = "     Export to Excel";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_save
            // 
            this.btn_save.Image = global::IFM.Properties.Resources.Save;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save.Location = new System.Drawing.Point(269, 1);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(98, 22);
            this.btn_save.TabIndex = 0;
            this.btn_save.Text = "     Update to DB";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // gc_main
            // 
            this.gc_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_main.Location = new System.Drawing.Point(6, 109);
            this.gc_main.MainView = this.gv_main;
            this.gc_main.Name = "gc_main";
            this.gc_main.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemToggleSwitch1});
            this.gc_main.Size = new System.Drawing.Size(734, 326);
            this.gc_main.TabIndex = 2;
            this.gc_main.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_main});
            // 
            // gv_main
            // 
            this.gv_main.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn6,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gv_main.GridControl = this.gc_main;
            this.gv_main.Name = "gv_main";
            this.gv_main.OptionsView.ColumnAutoWidth = false;
            this.gv_main.OptionsView.ShowFooter = true;
            this.gv_main.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gv_main_RowStyle);
            this.gv_main.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gv_main_PopupMenuShowing);
            this.gv_main.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gv_main_CellValueChanged);
            this.gv_main.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gv_main_KeyDown);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = true;
            this.ID.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "User Name";
            this.gridColumn1.FieldName = "user_name";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Basicsalary Month";
            this.gridColumn2.DisplayFormat.FormatString = "{0:0,0 vnđ}";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "basicsalary_month";
            this.gridColumn2.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Bonus Salary Money";
            this.gridColumn6.DisplayFormat.FormatString = "{0:0,0 vnđ}";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "bonussalary";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Money insurance";
            this.gridColumn3.FieldName = "money_insurance";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Update By";
            this.gridColumn4.FieldName = "u_update";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Update Date";
            this.gridColumn5.FieldName = "d_update";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 6;
            // 
            // repositoryItemToggleSwitch1
            // 
            this.repositoryItemToggleSwitch1.AutoHeight = false;
            this.repositoryItemToggleSwitch1.Name = "repositoryItemToggleSwitch1";
            this.repositoryItemToggleSwitch1.OffText = "Off";
            this.repositoryItemToggleSwitch1.OnText = "On";
            // 
            // view_CRM_01_002
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 474);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "view_CRM_01_002";
            this.Text = "m_salary";
            this.Load += new System.EventHandler(this.view_CRM_01_002_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calc_bonussalary.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calc_Basicsalary.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemToggleSwitch1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ComboBox cbm_usercd;
        private System.Windows.Forms.ComboBox cbm_username;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_rowscount;
        private System.Windows.Forms.Button btn_add;
        private DevExpress.XtraGrid.GridControl gc_main;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_main;
        private System.Windows.Forms.CheckBox chb_user;
        private System.Windows.Forms.CheckBox chb_insurance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.CalcEdit calc_Basicsalary;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch repositoryItemToggleSwitch1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.CalcEdit calc_bonussalary;
        private System.Windows.Forms.Label label4;
    }
}