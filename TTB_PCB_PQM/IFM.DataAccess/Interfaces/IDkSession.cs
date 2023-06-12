using System.Data;

namespace IFM.DataAccess.Interfaces
{
    public interface IDkSession
    {
        IDbCommand DbCommand { get; }
        IDbConnection DbConnection { get; }
        IDbTransaction DbTransaction { get; }
        void AddParameters(params IDataParameter[] parameters);
        void AddParameter(object parameter);
        void SaveChanged();
        void Rollback();
        void Close();
    }
}
