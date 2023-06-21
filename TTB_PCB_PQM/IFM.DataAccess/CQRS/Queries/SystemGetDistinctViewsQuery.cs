using IFM.DataAccess.Extensions;
using IFM.DataAccess.Interfaces;
using IFM.DataAccess.Models.SYS;
using System;
using System.Collections.Generic;
using System.Data;

namespace IFM.DataAccess.CQRS.Queries
{
    public class SystemGetDistinctViewsQuery : IDkQuery<IEnumerable<m_assignment>>
    {
        public Guid Guid { get; }
        public string Filter { get; }

        public SystemGetDistinctViewsQuery() : this(string.Empty) { }

        public SystemGetDistinctViewsQuery(string filter)
        {
            Guid = Guid.NewGuid();
            Filter = filter;
        }
    }

    internal class SystemGetDistinctViewsHandler : DkQueryHandler<SystemGetDistinctViewsQuery, IEnumerable<m_assignment>>
    {
        public SystemGetDistinctViewsHandler(IDkSession session) : base(session)
        {
        }
        public override IEnumerable<m_assignment> Handle(SystemGetDistinctViewsQuery query)
        {
            string sql = $@"select distinct assign_code  from m_assignments ma 
                            where 1=1 
                            and assign_view <> '' ";
            if (!string.IsNullOrWhiteSpace(query.Filter))
            {
                sql += $" WHERE {query.Filter}";
            }
            sql += $" ORDER BY {nameof(m_assignment.assign_code)};";
            try
            {
                Session.DbCommand.CommandText = sql;
                Session.DbCommand.CommandType = CommandType.Text;
                return Session.DbCommand.ExecuteReader().MapToList<m_assignment>();
            }
            finally
            {
                Session.Close();
            }
        }
    }

}
