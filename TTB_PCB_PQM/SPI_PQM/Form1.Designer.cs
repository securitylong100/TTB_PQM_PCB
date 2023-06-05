
namespace SPI_PQM
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txt_browserin = new System.Windows.Forms.TextBox();
            this.btn_browserin = new System.Windows.Forms.Button();
            this.txt_logerror = new System.Windows.Forms.TextBox();
            this.btn_autoget = new System.Windows.Forms.Button();
            this.btn_browserout = new System.Windows.Forms.Button();
            this.txt_browserout = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nud_timer = new System.Windows.Forms.NumericUpDown();
            this.btn_manualget = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_timer = new System.Windows.Forms.Label();
            this.lbl_status = new System.Windows.Forms.Label();
            this.btn_reload = new System.Windows.Forms.Button();
            this.timer_auto = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_timer)).BeginInit();
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tableLayoutPanel1.Controls.Add(this.txt_browserin, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_browserin, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txt_logerror, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_autoget, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_browserout, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt_browserout, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.nud_timer, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_manualget, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbl_timer, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbl_status, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.btn_reload, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1007, 366);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txt_browserin
            // 
            this.txt_browserin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_browserin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_browserin.Location = new System.Drawing.Point(209, 6);
            this.txt_browserin.Multiline = true;
            this.txt_browserin.Name = "txt_browserin";
            this.txt_browserin.ReadOnly = true;
            this.txt_browserin.Size = new System.Drawing.Size(368, 34);
            this.txt_browserin.TabIndex = 7;
            // 
            // btn_browserin
            // 
            this.btn_browserin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_browserin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_browserin.Location = new System.Drawing.Point(6, 6);
            this.btn_browserin.Name = "btn_browserin";
            this.btn_browserin.Size = new System.Drawing.Size(194, 34);
            this.btn_browserin.TabIndex = 6;
            this.btn_browserin.Text = "Browser Folder In";
            this.btn_browserin.UseVisualStyleBackColor = true;
            this.btn_browserin.Click += new System.EventHandler(this.btn_browser_Click);
            // 
            // txt_logerror
            // 
            this.txt_logerror.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.SetColumnSpan(this.txt_logerror, 5);
            this.txt_logerror.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_logerror.ForeColor = System.Drawing.Color.Red;
            this.txt_logerror.Location = new System.Drawing.Point(6, 92);
            this.txt_logerror.Multiline = true;
            this.txt_logerror.Name = "txt_logerror";
            this.txt_logerror.Size = new System.Drawing.Size(995, 235);
            this.txt_logerror.TabIndex = 0;
            // 
            // btn_autoget
            // 
            this.btn_autoget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_autoget.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_autoget.Location = new System.Drawing.Point(586, 6);
            this.btn_autoget.Name = "btn_autoget";
            this.btn_autoget.Size = new System.Drawing.Size(144, 34);
            this.btn_autoget.TabIndex = 8;
            this.btn_autoget.Text = "AutoRun";
            this.btn_autoget.UseVisualStyleBackColor = true;
            this.btn_autoget.Click += new System.EventHandler(this.btn_autoget_Click);
            // 
            // btn_browserout
            // 
            this.btn_browserout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_browserout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_browserout.Location = new System.Drawing.Point(6, 49);
            this.btn_browserout.Name = "btn_browserout";
            this.btn_browserout.Size = new System.Drawing.Size(194, 34);
            this.btn_browserout.TabIndex = 9;
            this.btn_browserout.Text = "Browser Folder Out";
            this.btn_browserout.UseVisualStyleBackColor = true;
            this.btn_browserout.Click += new System.EventHandler(this.btn_browserout_Click);
            // 
            // txt_browserout
            // 
            this.txt_browserout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_browserout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_browserout.Location = new System.Drawing.Point(209, 49);
            this.txt_browserout.Multiline = true;
            this.txt_browserout.Name = "txt_browserout";
            this.txt_browserout.ReadOnly = true;
            this.txt_browserout.Size = new System.Drawing.Size(368, 34);
            this.txt_browserout.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(739, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 40);
            this.label1.TabIndex = 12;
            this.label1.Text = "Timer (s)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nud_timer
            // 
            this.nud_timer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nud_timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_timer.Location = new System.Drawing.Point(892, 6);
            this.nud_timer.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_timer.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nud_timer.Name = "nud_timer";
            this.nud_timer.Size = new System.Drawing.Size(109, 31);
            this.nud_timer.TabIndex = 13;
            this.nud_timer.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // btn_manualget
            // 
            this.btn_manualget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_manualget.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_manualget.Location = new System.Drawing.Point(586, 49);
            this.btn_manualget.Name = "btn_manualget";
            this.btn_manualget.Size = new System.Drawing.Size(144, 34);
            this.btn_manualget.TabIndex = 14;
            this.btn_manualget.Text = "Manual Get";
            this.btn_manualget.UseVisualStyleBackColor = true;
            this.btn_manualget.Click += new System.EventHandler(this.btn_manualget_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 3);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 333);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(724, 30);
            this.label2.TabIndex = 15;
            this.label2.Text = "Version: 0.1";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_timer
            // 
            this.lbl_timer.AutoSize = true;
            this.lbl_timer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_timer.Location = new System.Drawing.Point(892, 333);
            this.lbl_timer.Name = "lbl_timer";
            this.lbl_timer.Size = new System.Drawing.Size(109, 30);
            this.lbl_timer.TabIndex = 16;
            this.lbl_timer.Text = "60";
            this.lbl_timer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_status.Location = new System.Drawing.Point(739, 333);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(144, 30);
            this.lbl_status.TabIndex = 17;
            this.lbl_status.Text = "waiting upload";
            this.lbl_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_reload
            // 
            this.btn_reload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_reload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reload.Location = new System.Drawing.Point(739, 49);
            this.btn_reload.Name = "btn_reload";
            this.btn_reload.Size = new System.Drawing.Size(144, 34);
            this.btn_reload.TabIndex = 18;
            this.btn_reload.Text = "Reload";
            this.btn_reload.UseVisualStyleBackColor = true;
            this.btn_reload.Click += new System.EventHandler(this.btn_reload_Click);
            // 
            // timer_auto
            // 
            this.timer_auto.Tick += new System.EventHandler(this.timer_auto_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 366);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Tool01_PQM_SPI_v0.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_timer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txt_logerror;
        private System.Windows.Forms.Button btn_browserin;
        private System.Windows.Forms.TextBox txt_browserin;
        private System.Windows.Forms.Button btn_autoget;
        private System.Windows.Forms.Button btn_browserout;
        private System.Windows.Forms.TextBox txt_browserout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nud_timer;
        private System.Windows.Forms.Button btn_manualget;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_timer;
        private System.Windows.Forms.Timer timer_auto;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Button btn_reload;
    }
}

