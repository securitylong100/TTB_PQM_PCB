namespace IFM.Views
{
    partial class frm_wait
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
            this.pnl_processing = new DevExpress.XtraWaitForm.ProgressPanel();
            this.tbl_main = new System.Windows.Forms.TableLayoutPanel();
            this.tbl_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_processing
            // 
            this.pnl_processing.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnl_processing.Appearance.Options.UseBackColor = true;
            this.pnl_processing.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.pnl_processing.AppearanceCaption.Options.UseFont = true;
            this.pnl_processing.AppearanceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.pnl_processing.AppearanceDescription.Options.UseFont = true;
            this.pnl_processing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_processing.ImageHorzOffset = 20;
            this.pnl_processing.Location = new System.Drawing.Point(0, 17);
            this.pnl_processing.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.pnl_processing.Name = "pnl_processing";
            this.pnl_processing.Size = new System.Drawing.Size(246, 39);
            this.pnl_processing.TabIndex = 0;
            this.pnl_processing.Text = "Processing";
            // 
            // tbl_main
            // 
            this.tbl_main.AutoSize = true;
            this.tbl_main.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tbl_main.BackColor = System.Drawing.Color.Transparent;
            this.tbl_main.ColumnCount = 1;
            this.tbl_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl_main.Controls.Add(this.pnl_processing, 0, 0);
            this.tbl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_main.Location = new System.Drawing.Point(0, 0);
            this.tbl_main.Name = "tbl_main";
            this.tbl_main.Padding = new System.Windows.Forms.Padding(0, 14, 0, 14);
            this.tbl_main.RowCount = 1;
            this.tbl_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl_main.Size = new System.Drawing.Size(246, 73);
            this.tbl_main.TabIndex = 1;
            // 
            // frm_wait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(246, 73);
            this.Controls.Add(this.tbl_main);
            this.DoubleBuffered = true;
            this.Name = "frm_wait";
            this.Text = "Waiting";
            this.tbl_main.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraWaitForm.ProgressPanel pnl_processing;
        private System.Windows.Forms.TableLayoutPanel tbl_main;
    }
}
