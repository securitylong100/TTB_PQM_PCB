using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPI_PQM
{
    public partial class roletest : Form
    {
        public roletest()
        {
            InitializeComponent();
        }
        DataTable dt2 = new DataTable();
        DataTable dt = new DataTable();
        private void roletest_Load(object sender, EventArgs e)
        {
            string sql = "select * from tb_role_test";
            mysqlconnection con = new mysqlconnection();
            con.sqlDataAdapterFillDatatable(sql, ref dt);
            dataGridView1.DataSource = dt;

            string sql2 = "select * from m_role_test";
          
            con.sqlDataAdapterFillDatatable(sql2, ref dt2);
            dataGridView2.DataSource = dt2;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
