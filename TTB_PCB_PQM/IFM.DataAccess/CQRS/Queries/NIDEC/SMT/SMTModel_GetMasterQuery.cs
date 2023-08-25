using IFM.DataAccess.Extensions;
using IFM.DataAccess.Interfaces;
using IFM.DataAccess.Models.NIDEC;
using IFM.DataAccess.Models.SYS;
using System;
using System.Collections.Generic;
using System.Data;

namespace IFM.DataAccess.CQRS.Queries.NIDEC.SMT
{ 
    public class SMTModel_GetMasterQuery : IDkQuery<IEnumerable<m_smt_model>>
    {
        public Guid Guid { get; }
        public string Filter { get; }

        public SMTModel_GetMasterQuery() : this(string.Empty) { }

        public SMTModel_GetMasterQuery(string filter)
        {
            Filter = filter;
            Guid = Guid.NewGuid();
        }
    }
    internal class SMTModel_GetMasterHandler : DkQueryHandler<SMTModel_GetMasterQuery, IEnumerable<m_smt_model>>
    {
        public SMTModel_GetMasterHandler(IDkSession session) : base(session)
        {
        }

        public override IEnumerable<m_smt_model> Handle(SMTModel_GetMasterQuery query)
        {
            string sql = @"SELECT id as ID,
                                  model_cd,
                                  model_columns,                                
                                  model_rows, 
                                  active_status,                  
                                  create_time
                              FROM smt_m_model";
            if (!string.IsNullOrWhiteSpace(query.Filter))
            {
                sql += $" WHERE {query.Filter}";
            }
          
            try
            {
                Session.DbCommand.CommandText = sql;
                Session.DbCommand.CommandType = CommandType.Text;
                return Session.DbCommand.ExecuteReader().MapToList<m_smt_model>();
            }
            finally
            {
                Session.Close();
            }
        }
    }
}
