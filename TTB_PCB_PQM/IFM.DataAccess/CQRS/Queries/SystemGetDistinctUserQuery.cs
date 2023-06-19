using IFM.DataAccess.Extensions;
using IFM.DataAccess.Interfaces;
using IFM.DataAccess.Models.SYS;
using System;
using System.Collections.Generic;
using System.Data;

namespace IFM.DataAccess.CQRS.Queries
{
    public class SystemGetDistinctUserQuery : IDkQuery<IEnumerable<m_user>>
    {
        public Guid Guid { get; }
        public string Filter { get; }

        public SystemGetDistinctUserQuery() : this(string.Empty) { }

        public SystemGetDistinctUserQuery(string filter)
        {
            Guid = Guid.NewGuid();
            Filter = filter;
        }
    }

    internal class SystemGetDistinctUserHandler : DkQueryHandler<SystemGetDistinctUserQuery, IEnumerable<m_user>>
    {
        public SystemGetDistinctUserHandler(IDkSession session) : base(session)
        {
        }
        public override IEnumerable<m_user> Handle(SystemGetDistinctUserQuery query)
        {
            string sql = $@"SELECT distinct user_cd
                                  FROM m_user ";
            if (!string.IsNullOrWhiteSpace(query.Filter))
            {
                sql += $" WHERE {query.Filter}";
            }
            sql += $" ORDER BY {nameof(m_user.user_cd)};";
            try
            {
                Session.DbCommand.CommandText = sql;
                Session.DbCommand.CommandType = CommandType.Text;
                return Session.DbCommand.ExecuteReader().MapToList<m_user>();
            }
            finally
            {
                Session.Close();
            }
        }
    }

}
