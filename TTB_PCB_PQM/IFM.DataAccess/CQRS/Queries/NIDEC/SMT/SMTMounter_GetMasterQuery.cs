using IFM.DataAccess.Extensions;
using IFM.DataAccess.Interfaces;
using IFM.DataAccess.Models.NIDEC;
using IFM.DataAccess.Models.SYS;
using System;
using System.Collections.Generic;
using System.Data;

namespace IFM.DataAccess.CQRS.Queries.NIDEC.SMT
{ 
    public class SMTMounter_GetMasterQuery : IDkQuery<IEnumerable<m_smt_mounter>>
    {
        public Guid Guid { get; }
        public string Filter { get; }

        public SMTMounter_GetMasterQuery() : this(string.Empty) { }

        public SMTMounter_GetMasterQuery(string filter)
        {
            Filter = filter;
            Guid = Guid.NewGuid();
        }
    }
    internal class SMTMounter_GetMasterHandler : DkQueryHandler<SMTMounter_GetMasterQuery, IEnumerable<m_smt_mounter>>
    {
        public SMTMounter_GetMasterHandler(IDkSession session) : base(session)
        {
        }

        public override IEnumerable<m_smt_mounter> Handle(SMTMounter_GetMasterQuery query)
        {
            string sql = @"SELECT ID,
                                  model_cd,
                                  item_list,                                
                                  status,
                                  comments,
                                  updater,
                                  update_time,
                                  creator,
                                  create_time
                              FROM smt_m_mounter_items";
            if (!string.IsNullOrWhiteSpace(query.Filter))
            {
                sql += $" WHERE {query.Filter}";
            }
            sql += $" WHERE 1=1 and  {nameof(m_smt_mounter.status)} <3 ";     
            try
            {
                Session.DbCommand.CommandText = sql;
                Session.DbCommand.CommandType = CommandType.Text;
                return Session.DbCommand.ExecuteReader().MapToList<m_smt_mounter>();
            }
            finally
            {
                Session.Close();
            }
        }
    }
}
