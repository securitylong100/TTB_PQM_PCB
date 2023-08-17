namespace IFM.Views.NIDEC.SMT
{
    partial class View_STM_Assy_Check_2
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View_STM_Assy_Check_2));
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bbiNew = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bbiSearch = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bbiPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bar_status = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.bsiRecordsCount = new DevExpress.XtraBars.BarStaticItem();
            this.gv_data = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.assy_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pcb_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.model_cd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.creator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.create_time = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_data = new DevExpress.XtraGrid.GridControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pn_background = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.txt_counter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_pcbbarcode = new System.Windows.Forms.TextBox();
            this.cbm_modelcd = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_enter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_barcode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_exportlink = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_data)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.pn_background.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.MergeOrder = 0;
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiNew);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // bbiNew
            // 
            this.bbiNew.Caption = "Clear";
            this.bbiNew.Id = 16;
            this.bbiNew.ImageOptions.ImageUri.Uri = "New";
            this.bbiNew.Name = "bbiNew";
            this.bbiNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiNew_ItemClick);
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiSearch);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiDelete);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiRefresh);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Tasks";
            // 
            // bbiSearch
            // 
            this.bbiSearch.Caption = "Search";
            this.bbiSearch.Id = 17;
            this.bbiSearch.ImageOptions.Image = global::IFM.Properties.Resources.Load;
            this.bbiSearch.ImageOptions.ImageUri.Uri = "Edit";
            this.bbiSearch.Name = "bbiSearch";
            this.bbiSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiEdit_ItemClick);
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Delete";
            this.bbiDelete.Id = 18;
            this.bbiDelete.ImageOptions.ImageUri.Uri = "Delete";
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiDelete_ItemClick);
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "Refresh";
            this.bbiRefresh.Id = 19;
            this.bbiRefresh.ImageOptions.ImageUri.Uri = "Refresh";
            this.bbiRefresh.Name = "bbiRefresh";
            this.bbiRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiRefresh_ItemClick);
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiPrintPreview);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Print and Export";
            // 
            // bbiPrintPreview
            // 
            this.bbiPrintPreview.Caption = "Print Preview";
            this.bbiPrintPreview.Id = 14;
            this.bbiPrintPreview.ImageOptions.ImageUri.Uri = "Preview";
            this.bbiPrintPreview.Name = "bbiPrintPreview";
            this.bbiPrintPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiPrintPreview_ItemClick);
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "Save";
            this.bbiSave.Id = 20;
            this.bbiSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiSave.ImageOptions.Image")));
            this.bbiSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiSave.ImageOptions.LargeImage")));
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiSave_ItemClick);
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.ribbonControl.SearchEditItem,
            this.bbiPrintPreview,
            this.bbiNew,
            this.bbiSearch,
            this.bbiDelete,
            this.bbiRefresh,
            this.bbiSave});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 21;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Size = new System.Drawing.Size(1186, 79);
            this.ribbonControl.StatusBar = this.bar_status;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bar_status
            // 
            this.bar_status.ItemLinks.Add(this.bsiRecordsCount);
            this.bar_status.Location = new System.Drawing.Point(0, 477);
            this.bar_status.Name = "bar_status";
            this.bar_status.Ribbon = this.ribbonControl;
            this.bar_status.Size = new System.Drawing.Size(1186, 31);
            // 
            // bsiRecordsCount
            // 
            this.bsiRecordsCount.Caption = "RECORDS : 0";
            this.bsiRecordsCount.Id = 15;
            this.bsiRecordsCount.Name = "bsiRecordsCount";
            // 
            // gv_data
            // 
            this.gv_data.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gv_data.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.assy_code,
            this.pcb_code,
            this.model_cd,
            this.creator,
            this.create_time});
            this.gv_data.GridControl = this.gc_data;
            this.gv_data.Name = "gv_data";
            this.gv_data.OptionsBehavior.Editable = false;
            this.gv_data.OptionsBehavior.ReadOnly = true;
            this.gv_data.OptionsEditForm.EditFormColumnCount = 2;
            this.gv_data.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            this.gv_data.OptionsView.ShowFooter = true;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "id";
            this.ID.Name = "ID";
            this.ID.Visible = true;
            this.ID.VisibleIndex = 0;
            // 
            // assy_code
            // 
            this.assy_code.Caption = "Barcode Housing";
            this.assy_code.FieldName = "assy_code";
            this.assy_code.Name = "assy_code";
            this.assy_code.Visible = true;
            this.assy_code.VisibleIndex = 1;
            // 
            // pcb_code
            // 
            this.pcb_code.Caption = "PCB Barcode";
            this.pcb_code.FieldName = "pcb_code";
            this.pcb_code.Name = "pcb_code";
            this.pcb_code.Visible = true;
            this.pcb_code.VisibleIndex = 2;
            // 
            // model_cd
            // 
            this.model_cd.Caption = "Model Code";
            this.model_cd.FieldName = "model_cd";
            this.model_cd.Name = "model_cd";
            this.model_cd.Visible = true;
            this.model_cd.VisibleIndex = 3;
            // 
            // creator
            // 
            this.creator.Caption = "Creator";
            this.creator.FieldName = "creator";
            this.creator.Name = "creator";
            this.creator.Visible = true;
            this.creator.VisibleIndex = 4;
            // 
            // create_time
            // 
            this.create_time.Caption = "Create Time";
            this.create_time.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.create_time.FieldName = "create_time";
            this.create_time.Name = "create_time";
            this.create_time.Visible = true;
            this.create_time.VisibleIndex = 5;
            // 
            // gc_data
            // 
            this.gc_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_data.Location = new System.Drawing.Point(3, 94);
            this.gc_data.MainView = this.gv_data;
            this.gc_data.MenuManager = this.ribbonControl;
            this.gc_data.Name = "gc_data";
            this.gc_data.Size = new System.Drawing.Size(1180, 301);
            this.gc_data.TabIndex = 2;
            this.gc_data.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_data});
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gc_data, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pn_background, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 79);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1186, 398);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // pn_background
            // 
            this.pn_background.BackColor = System.Drawing.Color.Silver;
            this.pn_background.Controls.Add(this.label7);
            this.pn_background.Controls.Add(this.txt_exportlink);
            this.pn_background.Controls.Add(this.label4);
            this.pn_background.Controls.Add(this.label5);
            this.pn_background.Controls.Add(this.dtp_to);
            this.pn_background.Controls.Add(this.dtp_from);
            this.pn_background.Controls.Add(this.txt_counter);
            this.pn_background.Controls.Add(this.label3);
            this.pn_background.Controls.Add(this.label2);
            this.pn_background.Controls.Add(this.txt_pcbbarcode);
            this.pn_background.Controls.Add(this.cbm_modelcd);
            this.pn_background.Controls.Add(this.label6);
            this.pn_background.Controls.Add(this.btn_enter);
            this.pn_background.Controls.Add(this.label1);
            this.pn_background.Controls.Add(this.txt_barcode);
            this.pn_background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_background.Location = new System.Drawing.Point(3, 3);
            this.pn_background.Name = "pn_background";
            this.pn_background.Size = new System.Drawing.Size(1180, 85);
            this.pn_background.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(940, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Date to:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(940, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Date from:";
            // 
            // dtp_to
            // 
            this.dtp_to.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dtp_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_to.Location = new System.Drawing.Point(1000, 45);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(146, 21);
            this.dtp_to.TabIndex = 35;
            // 
            // dtp_from
            // 
            this.dtp_from.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dtp_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_from.Location = new System.Drawing.Point(1000, 8);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(146, 21);
            this.dtp_from.TabIndex = 34;
            // 
            // txt_counter
            // 
            this.txt_counter.Location = new System.Drawing.Point(426, 45);
            this.txt_counter.Name = "txt_counter";
            this.txt_counter.ReadOnly = true;
            this.txt_counter.Size = new System.Drawing.Size(160, 21);
            this.txt_counter.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Qty PCB Sub:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(348, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Barcode PCB:";
            // 
            // txt_pcbbarcode
            // 
            this.txt_pcbbarcode.Location = new System.Drawing.Point(426, 9);
            this.txt_pcbbarcode.Name = "txt_pcbbarcode";
            this.txt_pcbbarcode.Size = new System.Drawing.Size(160, 21);
            this.txt_pcbbarcode.TabIndex = 30;
            // 
            // cbm_modelcd
            // 
            this.cbm_modelcd.FormattingEnabled = true;
            this.cbm_modelcd.Location = new System.Drawing.Point(103, 45);
            this.cbm_modelcd.Name = "cbm_modelcd";
            this.cbm_modelcd.Size = new System.Drawing.Size(160, 21);
            this.cbm_modelcd.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Model Code:";
            // 
            // btn_enter
            // 
            this.btn_enter.Location = new System.Drawing.Point(264, 45);
            this.btn_enter.Name = "btn_enter";
            this.btn_enter.Size = new System.Drawing.Size(50, 23);
            this.btn_enter.TabIndex = 10;
            this.btn_enter.Text = "Enter";
            this.btn_enter.UseVisualStyleBackColor = true;
            this.btn_enter.Click += new System.EventHandler(this.btn_enter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Barcode Housing:";
            // 
            // txt_barcode
            // 
            this.txt_barcode.Location = new System.Drawing.Point(103, 9);
            this.txt_barcode.Name = "txt_barcode";
            this.txt_barcode.Size = new System.Drawing.Size(211, 21);
            this.txt_barcode.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(611, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Link export:";
            // 
            // txt_exportlink
            // 
            this.txt_exportlink.Location = new System.Drawing.Point(681, 9);
            this.txt_exportlink.Name = "txt_exportlink";
            this.txt_exportlink.ReadOnly = true;
            this.txt_exportlink.Size = new System.Drawing.Size(219, 21);
            this.txt_exportlink.TabIndex = 38;
            this.txt_exportlink.Text = "\\\\192.168.193.1\\ftpin\\SMT\\PQM_SPI";
            // 
            // View_STM_Assy_Check_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 508);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.bar_status);
            this.Controls.Add(this.ribbonControl);
            this.Name = "View_STM_Assy_Check_2";
            this.Ribbon = this.ribbonControl;
            this.StatusBar = this.bar_status;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_data)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pn_background.ResumeLayout(false);
            this.pn_background.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.BarButtonItem bbiSearch;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem bbiPrintPreview;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar bar_status;
        private DevExpress.XtraBars.BarStaticItem bsiRecordsCount;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_data;
        private DevExpress.XtraGrid.GridControl gc_data;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pn_background;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_barcode;
        private System.Windows.Forms.Button btn_enter;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn assy_code;
        private DevExpress.XtraGrid.Columns.GridColumn model_cd;
        private DevExpress.XtraGrid.Columns.GridColumn creator;
        private DevExpress.XtraGrid.Columns.GridColumn create_time;
        private System.Windows.Forms.ComboBox cbm_modelcd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_pcbbarcode;
        private DevExpress.XtraGrid.Columns.GridColumn pcb_code;
        private System.Windows.Forms.TextBox txt_counter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_exportlink;
    }
}