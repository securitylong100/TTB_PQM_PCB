using IFM.DataAccess.Interfaces;
using MySql.Data.MySqlClient;
using System.Data;

namespace IFM.Business.Implements
{
    public class DkMySqlConnection : IDkConnection
    {
        private readonly string _connectionString;

        public DkMySqlConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public IDataParameter GetParameter(string name, object value)
        {
            return new MySqlParameter(name, value);
        }

        public IDbDataAdapter CreateAdapter(IDbCommand command)
        {
            return new MySqlDataAdapter((MySqlCommand)command);
        }
    }
}
