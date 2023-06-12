using IFM.Common.Views;
using System;
using System.Windows.Forms;

namespace IFM
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // ClsSession.App.LoadSettings();
            //Application.Run(new view_crms_summary());
            //Application.Run(ClsSession.App.FrmLogin);
            //ClsVariables.App.FrmLogin.ShowDialog();
            Application.Run(new frm_login());
            //Application.Run(new frm_MainList("Long Lê"));
        }
    }
}
