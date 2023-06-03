using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace AOI_PQM
{
    class postgreSQLconnection
    {
        public NpgsqlConnection connection;
        //server on aoi machine
        // public static string conStringIpqcDbP4 = @"Server=127.0.0.1;Port=5432;User Id=postgres;Password=sinictek;Database=postges; CommandTimeout=100; Timeout=100;";
        //server localhost on long pc
        public static string conStringIpqcDbP4 = @"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=aoi_db; CommandTimeout=100; Timeout=100;";
        public string sqlExecuteScalarString_Autosystem(string sql)
        {
            string response;
            try
            {
                connection = new NpgsqlConnection(conStringIpqcDbP4);
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                response = Convert.ToString(command.ExecuteScalar());
                connection.Close();
                return response;
            }
            catch
            {
                return String.Empty;
            }
        }
        public void sqlDataAdapterFillDatatable(string sql, ref DataTable dt)
        {
            try
            {
                connection = new NpgsqlConnection(conStringIpqcDbP4);
                NpgsqlCommand command = new NpgsqlCommand();

                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter())
                {
                    command.CommandText = sql;
                    command.Connection = connection;
                    adapter.SelectCommand = command;
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                connection.Close();
            }

        }
    }
}
