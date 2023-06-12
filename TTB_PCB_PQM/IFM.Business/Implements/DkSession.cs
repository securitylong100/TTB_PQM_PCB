using IFM.DataAccess.Extensions;
using IFM.DataAccess.Interfaces;
using System.Data;
using System.Linq;

namespace IFM.Business.Implements
{
    public class DkSession : IDkSession
    {
        private readonly int _timeout;
        private IDbCommand _dbCommand;
        private IDbConnection _dbConnection;
        private IDbTransaction _dbTransaction;
        private readonly IDkConnection _connection;

        public IDbConnection DbConnection => Open();
        public IDbTransaction DbTransaction => BeginTransaction();
        public IDbDataAdapter DbAdapter => _connection?.CreateAdapter(DbCommand);
        public IDbCommand DbCommand
        {
            get
            {
                if (_dbCommand == null)
                {
                    _dbCommand = DbConnection?.CreateCommand();
                }
                return _dbCommand;
            }
        }

        public DkSession(IDkConnection connection, int timeout = 5)
        {
            _timeout = timeout;
            _connection = connection;
        }

        public void AddParameters(params IDataParameter[] parameters)
        {
            if (DbCommand != null)
            {
                foreach (var parameter in parameters)
                {
                    DbCommand.Parameters.Add(parameter);
                }
            }
        }

        public void AddParameter(object parameter)
        {
            if (parameter != null)
            {
                var parameters = parameter.GetType().GetProperties()
                    .Select(p => _connection.GetParameter($"@{p.Name}", p.GetValue(parameter)))
                    .ToArray();
                AddParameters(parameters);
            }
        }

        private IDbTransaction BeginTransaction()
        {
            if (_dbConnection != null && _dbTransaction == null)
            {
                _dbTransaction = _dbConnection.BeginTransaction();
            }
            return _dbTransaction;
        }

        private IDbConnection Open()
        {
            if (_dbConnection == null || _dbConnection.State == ConnectionState.Broken)
            {
                _dbConnection = _connection.CreateConnection();
            }
            if (_dbConnection.State == ConnectionState.Closed)
            {
                _dbConnection.QuickOpen(_timeout);
            }
            return _dbConnection;
        }

        public void SaveChanged()
        {
            _dbTransaction?.Commit();
        }

        public void Rollback()
        {
            _dbTransaction?.Rollback();
        }

        public void Close()
        {
            if (_dbCommand != null)
            {
                _dbCommand.Dispose();
                _dbCommand = null;
            }
            if (_dbTransaction != null)
            {
                _dbTransaction.Dispose();
                _dbTransaction = null;
            }
            if (_dbConnection.State != ConnectionState.Closed)
            {
                _dbConnection.Close();
            }
        }

        public void Dispose()
        {
            Close();
            _dbConnection.Dispose();
            _dbConnection = null;
        }
    }
}
