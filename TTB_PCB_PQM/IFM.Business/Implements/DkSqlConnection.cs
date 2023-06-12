using IFM.DataAccess.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace IFM.Business.Implements
{
    public class DkSqlConnection : IDkConnection
    {
        private readonly string _connectionString;

        public DkSqlConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public IDataParameter GetParameter(string name, object value)
        {
            return new SqlParameter(name, value);
        }

        public IDbDataAdapter CreateAdapter(IDbCommand command)
        {
            return new SqlDataAdapter((SqlCommand)command);
        }
    }
}
