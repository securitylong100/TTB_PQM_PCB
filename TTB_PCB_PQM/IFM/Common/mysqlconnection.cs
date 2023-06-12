using IFM.DataAccess.Extensions;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;


namespace IFM.Class
{
    class mysqlconnection
    {
        public MySqlConnection connection;
        //server IFM domain
        //public static string conStringIpqcDbP4 = @"server=112.213.89.73;uid=ifmsolut_admin;pwd=longifm@123;database=ifmsolut_erp;charset=utf8";
        //server Tuyến
        // public static string conStringIpqcDbP4 = @"server=149.28.148.99;port= 6033;uid=root;pwd=my_secret_password;database=app_db;charset=utf8";
        public static string conectionEncrypt = "9AgtUBuXjBZ1Fb6cyM3CVJby7cko39v1Tg4fyXhizf0ZSEEWPxUseN2bPo3roixa4/T4UFJCbAQdjybXB3/xa5+8urIX1Es8F7SseLdtZJuHiVvFaaRWYIzBacN8NBBi";
        public static string conStringIpqcDbP4 = De_Encrypt.Decrypt(conectionEncrypt);
        public void getComboBoxData(string sql, ref System.Windows.Forms.ComboBox cmb)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command;
            DataSet ds = new DataSet();
            try
            {
                connection = new MySqlConnection(conStringIpqcDbP4);
                connection.Open();
                command = new MySqlCommand(sql, connection);
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                adapter.Dispose();
                command.Dispose();

                cmb.Items.Clear();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    cmb.Items.Add(row[0].ToString());
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                connection.Close();
            }
        }

        public void getAutoCompleteData(string sql, ref TextBox txt)
        {
            txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command;
            DataSet ds = new DataSet();
            try
            {
                connection = new MySqlConnection(conStringIpqcDbP4);
                connection.Open();
                command = new MySqlCommand(sql, connection);
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                adapter.Dispose();
                command.Dispose();
                connection.Close();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    DataCollection.Add(row[0].ToString());
                }
                txt.AutoCompleteCustomSource = DataCollection;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                connection.Close();
            }
        }

        public double sqlExecuteScalarDouble(string sql)
        {
            double response;
            try
            {
                connection = new MySqlConnection(conStringIpqcDbP4);
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                response = Convert.ToDouble(command.ExecuteScalar());
                connection.Close();
                return response;
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL executeschalar moethod failed." + System.Environment.NewLine + ex.Message
                                , "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                connection.Close();
                return 100;
            }
        }

        public string sqlExecuteScalarString(string sql)
        {
            string response;
            try
            {
                connection = new MySqlConnection(conStringIpqcDbP4);
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                response = Convert.ToString(command.ExecuteScalar());
                connection.Close();
                return response;
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL executeschalar method failed." + System.Environment.NewLine + ex.Message
                                , "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                connection.Close();
                return String.Empty;
            }
        }
        public string sqlExecuteScalarString_Autosystem(string sql)
        {
            string response;
            try
            {
                connection = new MySqlConnection(conStringIpqcDbP4);
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                response = Convert.ToString(command.ExecuteScalar());
                connection.Close();
                return response;
            }
            catch
            {
                return String.Empty;
            }
        }

        public bool sqlExecuteScalarBool(string sql)
        {
            bool response;
            try
            {
                connection = new MySqlConnection(conStringIpqcDbP4);
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                response = (bool)command.ExecuteScalar();
                connection.Close();
                return response;
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL executeschalar moethod failed." + System.Environment.NewLine + ex.Message
                                , "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                connection.Close();
                return false;
            }
        }

        public long sqlExecuteScalarLong(string sql)
        {
            long response;
            try
            {
                connection = new MySqlConnection(conStringIpqcDbP4);
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                response = (long)command.ExecuteScalar();
                connection.Close();
                return response;
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL executeschalar moethod failed." + System.Environment.NewLine + ex.Message
                                , "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                connection.Close();
                return 0;
            }
        }

        public bool sqlExecuteNonQuery(string sql)
        {
            try
            {
                connection = new MySqlConnection(conStringIpqcDbP4);
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                int response = command.ExecuteNonQuery();
                if (response >= 1)
                {
                    //if (result_message_show) { MessageBox.Show("Successful!", "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Information); }                    
                    connection.Close();
                    return true;
                }
                else
                {
                    MessageBox.Show("Not successful!", "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    connection.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not successful!" + System.Environment.NewLine + ex.Message
                                , "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                connection.Close();
                return false;
            }
        }

        public bool sqlExecuteNonQuery(string sql, object parameter)
        {
            try
            {
                connection = new MySqlConnection(conStringIpqcDbP4);
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                if (parameter != null)
                {
                    foreach (var property in parameter.GetType().GetProperties())
                    {
                        command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(parameter));
                    }
                }
                int response = command.ExecuteNonQuery();
                if (response >= 1)
                {
                    //if (result_message_show) { MessageBox.Show("Successful!", "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Information); }                    
                    return true;
                }
                else
                {
                    MessageBox.Show("Not successful!", "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not successful!" + System.Environment.NewLine + ex.Message
                                , "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public int sqlExecuteNonQueryInt(string sql, bool result_message_show)
        {
            try
            {
                connection = new MySqlConnection(conStringIpqcDbP4);
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                int response = command.ExecuteNonQuery();
                if (response >= 1)
                {
                    if (result_message_show) { MessageBox.Show("Successful!", "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    connection.Close();
                    return response;
                }
                else
                {
                    if (result_message_show) { MessageBox.Show("Not successful!", "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    connection.Close();
                    return 0;
                }
            }
            catch (Exception ex)
            {
                if (result_message_show)
                {
                    MessageBox.Show("Not successful!" + System.Environment.NewLine + ex.Message, "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                connection.Close();
                return 0;
            }
        }

        public void sqlDataAdapterFillDatatable(string sql, ref DataTable dt)
        {
            try
            {
                connection = new MySqlConnection(conStringIpqcDbP4);
                MySqlCommand command = new MySqlCommand();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter())
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
        public void SP_DataAdapterFillDatatable(string SP, ref DataTable dt)
        {
            try
            {
                connection = new MySqlConnection(conStringIpqcDbP4);
                MySqlCommand command = new MySqlCommand();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = SP;
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

        public void SP_DataAdapterFillDatatable(string SP, object parameter, ref DataTable dt)
        {
            try
            {
                using (connection = new MySqlConnection(conStringIpqcDbP4))
                {
                    using (MySqlCommand command = new MySqlCommand())
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = SP;
                            command.Connection = connection;
                            if (parameter != null)
                            {
                                foreach (var property in parameter.GetType().GetProperties())
                                {
                                    command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(parameter));
                                }
                            }
                            adapter.SelectCommand = command;
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                connection.Close();
            }
        }

        public int SP_sqlExecuteScalarInt(string SP) //int >0 is ok
        {
            int response;
            try
            {
                connection = new MySqlConnection(conStringIpqcDbP4);
                connection.Open();
                MySqlCommand command = new MySqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = SP
                };
                response = int.Parse(command.ExecuteScalar().ToString());
                connection.Close();
                return response;
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL executeschalar method failed." + System.Environment.NewLine + ex.Message
                                , "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                connection.Close();
                return 0;
            }
        }


    }
}
