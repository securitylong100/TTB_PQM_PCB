using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Grid;
using IFM.Common;
using IFM.DataAccess.CQRS.Commands;
using IFM.DataAccess.CQRS.Queries;
using IFM.DataAccess.Models;
using IFM.DataAccess.Models.SYS;
using System;
using DevExpress.XtraEditors.Repository;
using System.Drawing;
using System.Windows.Forms;
using IFM.Class;
using System.Data;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace IFM.Views.NIDEC.PQM
{
    public partial class View_PQM_Viewer : RibbonForm
    {
       
        public View_PQM_Viewer()
        {
            InitializeComponent();
           
        }

        private void Gv_data_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

        }
        void BbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {
               

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
            
        }
     
        private void BbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            btn_enter_Click(sender, e);
        }
        private void BbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void BbiSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            btn_enter_Click(sender, e);
        }
        private void BbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
         
        }
        private void BbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

      

        private void btn_enter_Click(object sender, EventArgs e)
        {
           
        }

       
    }
}