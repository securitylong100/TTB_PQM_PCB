using System.Data;

namespace IFM.DataAccess.Interfaces
{
    public interface IDkConnection
    {
        IDbConnection CreateConnection();
        IDbDataAdapter CreateAdapter(IDbCommand command);
        IDataParameter GetParameter(string name, object value);
    }
}
