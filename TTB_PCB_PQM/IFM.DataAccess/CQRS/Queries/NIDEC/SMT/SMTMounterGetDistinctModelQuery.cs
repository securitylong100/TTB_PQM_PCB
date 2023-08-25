using IFM.DataAccess.Extensions;
using IFM.DataAccess.Interfaces;
using IFM.DataAccess.Models.NIDEC;
using IFM.DataAccess.Models.SYS;
using System;
using System.Collections.Generic;
using System.Data;

namespace IFM.DataAccess.CQRS.Queries.NIDEC.SMT
{ 
    public class SMTMounterGetDistinctModelQuery : IDkQuery<IEnumerable<m_smt_tool>>
    {
        public Guid Guid { get; }
        public string Filter { get; }

        public SMTMounterGetDistinctModelQuery() : this(string.Empty) { }

        public SMTMounterGetDistinctModelQuery(string filter)
        {
            Filter = filter;
            Guid = Guid.NewGuid();
        }
    }
    internal class SMTMounterGetDistinctModelHandler : DkQueryHandler<SMTMounterGetDistinctModelQuery, IEnumerable<m_smt_tool>>
    {
        public SMTMounterGetDistinctModelHandler(IDkSession session) : base(session)
        {
        }

        public override IEnumerable<m_smt_tool> Handle(SMTMounterGetDistinctModelQuery query)
        {
            string sql = @"select distinct (model_cd) from smt_m_model ";
            
            sql += $" ORDER BY {nameof(m_smt_tool.model_cd)};";
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
