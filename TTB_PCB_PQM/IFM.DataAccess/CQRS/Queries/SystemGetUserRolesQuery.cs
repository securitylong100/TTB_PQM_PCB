using IFM.DataAccess.Extensions;
using IFM.DataAccess.Interfaces;
using IFM.DataAccess.Models.SYS;
using System;
using System.Collections.Generic;
using System.Data;

namespace IFM.DataAccess.CQRS.Queries
{
    public class SystemGetUserRolesQuery : IDkQuery<IEnumerable<m_user_role>>
    {
        public Guid Guid { get; }
        public string Filter { get; }

        public SystemGetUserRolesQuery() : this(string.Empty) { }

        public SystemGetUserRolesQuery(string filter)
        {
            Filter = filter;
            Guid = Guid.NewGuid();
        }
    }
    internal class SystemGetUserRolesHandler : DkQueryHandler<SystemGetUserRolesQuery, IEnumerable<m_user_role>>
    {
        public SystemGetUserRolesHandler(IDkSession session) : base(session)
        {
        }

        public override IEnumerable<m_user_role> Handle(SystemGetUserRolesQuery query)
        {
            string sql = @"SELECT ID,
                                  user_cd,
                                  assign_code,
                                  priority,
                                  status,
                                  comments,
                                  updater,
                                  update_time,
                                  creator,
                                  create_time
                              FROM m_user_roles";
            if (!string.IsNullOrWhiteSpace(query.Filter))
            {
                sql += $" WHERE {query.Filter}";
            }
            sql += $" WHERE 1=1 and  {nameof(m_user_role.status)} <3 ";
            sql += $" ORDER BY {nameof(m_user_role.priority)};";
            try
            {
                Session.DbCommand.CommandText = sql;
                Session.DbCommand.CommandType = CommandType.Text;
                return Session.DbCommand.ExecuteReader().MapToList<m_user_role>();
            }
            finally
            {
                Session.Close();
            }
        }
    }
}
