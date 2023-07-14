using IFM.DataAccess.Extensions;
using IFM.DataAccess.Interfaces;
using IFM.DataAccess.Models.NIDEC;
using IFM.DataAccess.Models.SYS;
using System;
using System.Collections.Generic;
using System.Data;

namespace IFM.DataAccess.CQRS.Queries.NIDEC.SMT
{ 
    public class SMTTool_GetMasterQuery : IDkQuery<IEnumerable<m_smt_tool>>
    {
        public Guid Guid { get; }
        public string Filter { get; }

        public SMTTool_GetMasterQuery() : this(string.Empty) { }

        public SMTTool_GetMasterQuery(string filter)
        {
            Filter = filter;
            Guid = Guid.NewGuid();
        }
    }
    internal class SMTTool_GetMasterHandler : DkQueryHandler<SMTTool_GetMasterQuery, IEnumerable<m_smt_tool>>
    {
        public SMTTool_GetMasterHandler(IDkSession session) : base(session)
        {
        }

        public override IEnumerable<m_smt_tool> Handle(SMTTool_GetMasterQuery query)
        {
            string sql = @"SELECT ID,
                                  tool_cd,
                                  tool_name,
                                  tool_station,
                                  model_cd,
                                  tool_active,
                                  priority,
                                  status,
                                  comments,
                                  updater,
                                  update_time,
                                  creator,
                                  create_time
                              FROM smt_m_tool_master";
            if (!string.IsNullOrWhiteSpace(query.Filter))
            {
                sql += $" WHERE {query.Filter}";
            }
            sql += $" WHERE 1=1 and  {nameof(m_smt_tool.status)} <3 ";
            sql += $" ORDER BY {nameof(m_smt_tool.priority)};";
            try
            {
                Session.DbCommand.CommandText = sql;
                Session.DbCommand.CommandType = CommandType.Text;
                return Session.DbCommand.ExecuteReader().MapToList<m_smt_tool>();
            }
            finally
            {
                Session.Close();
            }
        }
    }
}
