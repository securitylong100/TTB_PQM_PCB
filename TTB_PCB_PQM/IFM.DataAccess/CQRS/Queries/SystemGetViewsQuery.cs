using IFM.DataAccess.Extensions;
using IFM.DataAccess.Interfaces;
using IFM.DataAccess.Models.SYS;
using System;
using System.Collections.Generic;
using System.Data;

namespace IFM.DataAccess.CQRS.Queries
{
    public class SystemGetViewsQuery : IDkQuery<IEnumerable<m_assignment>>
    {
        public Guid Guid { get; }
        public string Filter { get; }

        public SystemGetViewsQuery() : this(string.Empty) { }

        public SystemGetViewsQuery(string filter)
        {
            Guid = Guid.NewGuid();
            Filter = filter;
        }
    }

    internal class SystemGetViewsHandler : DkQueryHandler<SystemGetViewsQuery, IEnumerable<m_assignment>>
    {
        public SystemGetViewsHandler(IDkSession session) : base(session)
        {
        }

        public override IEnumerable<m_assignment> Handle(SystemGetViewsQuery query)
        {
            string sql = $@"SELECT {nameof(m_assignment.ID)},
                                       {nameof(m_assignment.assign_code)},
                                       {nameof(m_assignment.assign_name)},
                                       {nameof(m_assignment.assign_name_vn)},
                                       {nameof(m_assignment.assign_view)},
                                       {nameof(m_assignment.parent_code)},
                                       {nameof(m_assignment.priority)},
                                       {nameof(m_assignment.status)},
                                       {nameof(m_assignment.comments)},
                                       {nameof(m_assignment.updater)},
                                       {nameof(m_assignment.update_time)},
                                       {nameof(m_assignment.creator)},
                                       {nameof(m_assignment.create_time)}
                                  FROM m_assignments ";
            if (!string.IsNullOrWhiteSpace(query.Filter))
            {
                sql += $" WHERE {query.Filter}";
            }
            sql += $" ORDER BY {nameof(m_assignment.priority)};";
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
