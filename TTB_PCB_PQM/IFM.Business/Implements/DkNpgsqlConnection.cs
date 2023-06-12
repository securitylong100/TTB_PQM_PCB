using IFM.DataAccess.Interfaces;
using Npgsql;
using System.Data;

namespace IFM.Business.Implements
{
    public class DkNpgsqlConnection : IDkConnection
    {
        private readonly string _connectionString;

        public DkNpgsqlConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }

        public IDataParameter GetParameter(string name, object value)
        {
            return new NpgsqlParameter(name, value);
        }

        public IDbDataAdapter CreateAdapter(IDbCommand command)
        {
            return new NpgsqlDataAdapter((NpgsqlCommand)command);
        }
    }
}
