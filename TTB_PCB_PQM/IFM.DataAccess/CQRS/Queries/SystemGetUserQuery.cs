using IFM.DataAccess.Extensions;
using IFM.DataAccess.Interfaces;
using IFM.DataAccess.Models.SYS;
using System;
using System.Collections.Generic;
using System.Data;

namespace IFM.DataAccess.CQRS.Queries
{
    public class SystemGetUserQuery : IDkQuery<IEnumerable<m_user>>
    {
        public Guid Guid { get; }
        public string Filter { get; }

        public SystemGetUserQuery() : this(string.Empty) { }

        public SystemGetUserQuery(string filter)
        {
            Guid = Guid.NewGuid();
            Filter = filter;
        }
    }

    internal class SystemGetUserHandler : DkQueryHandler<SystemGetUserQuery, IEnumerable<m_user>>
    {
        public SystemGetUserHandler(IDkSession session) : base(session)
        {
        }
        public override IEnumerable<m_user> Handle(SystemGetUserQuery query)
        {
            string sql = $@"SELECT {nameof(m_user.ID)},
                                       {nameof(m_user.user_cd)},
                                       {nameof(m_user.user_name)},
                                       {nameof(m_user.user_pass)},
                                       {nameof(m_user.status)},
                                       {nameof(m_user.comments)},
                                       {nameof(m_user.user_role)},
                                       {nameof(m_user.user_email)},
                                       {nameof(m_user.user_permision)},
                                       {nameof(m_user.user_lang)}
                                  FROM m_user ";
            if (!string.IsNullOrWhiteSpace(query.Filter))
            {
                sql += $" WHERE {query.Filter}";
            }
            sql += $" ORDER BY {nameof(m_user.user_role)};";
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
