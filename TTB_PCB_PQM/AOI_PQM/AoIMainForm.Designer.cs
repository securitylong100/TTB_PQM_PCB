
namespace AOI_PQM
{
    partial class AoIMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AoIMainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txt_browserout = new System.Windows.Forms.TextBox();
            this.btn_browserout = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_manualget = new System.Windows.Forms.Button();
            this.btn_reload = new System.Windows.Forms.Button();
            this.btn_autoget = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nud_timer = new System.Windows.Forms.NumericUpDown();
            this.nud_DBday = new System.Windows.Forms.NumericUpDown();
            this.nud_ServerDay = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_status = new System.Windows.Forms.Label();
            this.lbl_timer = new System.Windows.Forms.Label();
            this.txt_logerror = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbm_model = new System.Windows.Forms.ComboBox();
            this.maincontrol = new DevExpress.XtraGrid.GridControl();
            this.maingrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.timer_auto = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_timer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_DBday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ServerDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maincontrol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maingrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel1.Controls.Add(this.txt_browserout, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_browserout, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_autoget, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.nud_timer, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.nud_DBday, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.nud_ServerDay, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbl_status, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbl_timer, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.txt_logerror, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbm_model, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.maincontrol, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1035, 366);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txt_browserout
            // 
            this.txt_browserout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_browserout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_browserout.Location = new System.Drawing.Point(209, 6);
            this.txt_browserout.Multiline = true;
            this.txt_browserout.Name = "txt_browserout";
            this.txt_browserout.ReadOnly = true;
            this.txt_browserout.Size = new System.Drawing.Size(378, 34);
            this.txt_browserout.TabIndex = 7;
            // 
            // btn_browserout
            // 
            this.btn_browserout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_browserout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_browserout.Location = new System.Drawing.Point(6, 6);
            this.btn_browserout.Name = "btn_browserout";
            this.btn_browserout.Size = new System.Drawing.Size(194, 34);
            this.btn_browserout.TabIndex = 6;
            this.btn_browserout.Text = "Browser Folder Out";
            this.btn_browserout.UseVisualStyleBackColor = true;
            this.btn_browserout.Click += new System.EventHandler(this.btn_browserout_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btn_manualget, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_reload, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(209, 49);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(378, 44);
            this.tableLayoutPanel2.TabIndex = 19;
            // 
            // btn_manualget
            // 
            this.btn_manualget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_manualget.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_manualget.Location = new System.Drawing.Point(6, 6);
            this.btn_manualget.Name = "btn_manualget";
            this.btn_manualget.Size = new System.Drawing.Size(178, 32);
            this.btn_manualget.TabIndex = 0;
            this.btn_manualget.Text = "Manual Get";
            this.btn_manualget.UseVisualStyleBackColor = true;
            this.btn_manualget.Click += new System.EventHandler(this.btn_manualget_Click);
            // 
            // btn_reload
            // 
            this.btn_reload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_reload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reload.Location = new System.Drawing.Point(193, 6);
            this.btn_reload.Name = "btn_reload";
            this.btn_reload.Size = new System.Drawing.Size(179, 32);
            this.btn_reload.TabIndex = 1;
            this.btn_reload.Text = "Reload";
            this.btn_reload.UseVisualStyleBackColor = true;
            this.btn_reload.Click += new System.EventHandler(this.btn_reload_Click);
            // 
            // btn_autoget
            // 
            this.btn_autoget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_autoget.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_autoget.Location = new System.Drawing.Point(6, 49);
            this.btn_autoget.Name = "btn_autoget";
            this.btn_autoget.Size = new System.Drawing.Size(194, 44);
            this.btn_autoget.TabIndex = 20;
            this.btn_autoget.Text = "AutoGet";
            this.btn_autoget.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(596, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 40);
            this.label1.TabIndex = 21;
            this.label1.Text = "Timer Auto Get";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(749, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 40);
            this.label3.TabIndex = 22;
            this.label3.Text = "DB check NoDay";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(902, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 40);
            this.label4.TabIndex = 23;
            this.label4.Text = "Server check NoDay";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nud_timer
            // 
            this.nud_timer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nud_timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_timer.Location = new System.Drawing.Point(596, 49);
            this.nud_timer.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_timer.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_timer.Name = "nud_timer";
            this.nud_timer.Size = new System.Drawing.Size(144, 26);
            this.nud_timer.TabIndex = 24;
            this.nud_timer.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // nud_DBday
            // 
            this.nud_DBday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_DBday.Location = new System.Drawing.Point(749, 49);
            this.nud_DBday.Name = "nud_DBday";
            this.nud_DBday.Size = new System.Drawing.Size(120, 26);
            this.nud_DBday.TabIndex = 25;
            this.nud_DBday.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // nud_ServerDay
            // 
            this.nud_ServerDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_ServerDay.Location = new System.Drawing.Point(902, 49);
            this.nud_ServerDay.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nud_ServerDay.Name = "nud_ServerDay";
            this.nud_ServerDay.Size = new System.Drawing.Size(118, 26);
            this.nud_ServerDay.TabIndex = 26;
            this.nud_ServerDay.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label5, 3);
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(6, 333);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(734, 30);
            this.label5.TabIndex = 27;
            this.label5.Text = "Version 0.1";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_status.Location = new System.Drawing.Point(749, 333);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(144, 30);
            this.lbl_status.TabIndex = 28;
            this.lbl_status.Text = "waiting upload";
            this.lbl_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_timer
            // 
            this.lbl_timer.AutoSize = true;
            this.lbl_timer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_timer.Location = new System.Drawing.Point(902, 333);
            this.lbl_timer.Name = "lbl_timer";
            this.lbl_timer.Size = new System.Drawing.Size(127, 30);
            this.lbl_timer.TabIndex = 29;
            this.lbl_timer.Text = "60";
            this.lbl_timer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_logerror
            // 
            this.txt_logerror.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.SetColumnSpan(this.txt_logerror, 2);
            this.txt_logerror.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_logerror.ForeColor = System.Drawing.Color.Red;
            this.txt_logerror.Location = new System.Drawing.Point(6, 145);
            this.txt_logerror.Multiline = true;
            this.txt_logerror.Name = "txt_logerror";
            this.txt_logerror.Size = new System.Drawing.Size(581, 182);
            this.txt_logerror.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 40);
            this.label2.TabIndex = 31;
            this.label2.Text = "Model (TableName)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbm_model
            // 
            this.cbm_model.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbm_model.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbm_model.FormattingEnabled = true;
            this.cbm_model.Location = new System.Drawing.Point(209, 102);
            this.cbm_model.Name = "cbm_model";
            this.cbm_model.Size = new System.Drawing.Size(378, 28);
            this.cbm_model.TabIndex = 32;
            // 
            // maincontrol
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.maincontrol, 3);
            this.maincontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maincontrol.Location = new System.Drawing.Point(596, 145);
            this.maincontrol.MainView = this.maingrid;
            this.maincontrol.Name = "maincontrol";
            this.maincontrol.Size = new System.Drawing.Size(433, 182);
            this.maincontrol.TabIndex = 33;
            this.maincontrol.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.maingrid});
            // 
            // maingrid
            // 
            this.maingrid.GridControl = this.maincontrol;
            this.maingrid.Name = "maingrid";
            // 
            // AoIMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 366);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AoIMainForm";
            this.Text = "Tool01_PQM_AOI_v0.1";
            this.Load += new System.EventHandler(this.AoIMainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_timer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_DBday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ServerDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maincontrol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maingrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Timer timer_auto;
        private System.Windows.Forms.TextBox txt_browserout;
        private System.Windows.Forms.Button btn_browserout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_manualget;
        private System.Windows.Forms.Button btn_reload;
        private System.Windows.Forms.Button btn_autoget;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nud_timer;
        private System.Windows.Forms.NumericUpDown nud_DBday;
        private System.Windows.Forms.NumericUpDown nud_ServerDay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Label lbl_timer;
        private System.Windows.Forms.TextBox txt_logerror;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbm_model;
        private DevExpress.XtraGrid.GridControl maincontrol;
        private DevExpress.XtraGrid.Views.Grid.GridView maingrid;
    }
}

