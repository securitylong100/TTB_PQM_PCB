using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AOI_PQM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataTable dt;
        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            postgreSQLconnection con = new postgreSQLconnection();
            string sql = @"SELECT * FROM ""LS16-B3A204311-PD"".aoi_board LIMIT 100";
            con.sqlDataAdapterFillDatatable(sql, ref dt);
        }
    }
}
