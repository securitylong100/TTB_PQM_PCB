using IFM.DataAccess.Interfaces;
using IFM.DataAccess.Models.SYS;
using IFM.DataAccess.Models.NIDEC;
using System;
using System.Data;

namespace IFM.DataAccess.CQRS.Commands
{
    public class SMTModel_UpdateMasterCommand : IDkCommand
    {
        public Guid Guid { get; }
        public m_smt_model[] ToolMaster { get; }

        public SMTModel_UpdateMasterCommand(params m_smt_model[] roles)
        {
            Guid = Guid.NewGuid();
            ToolMaster = roles;
        }
    }

    internal class SMTModel_UpdateMasterHandler : DkCommandHandler<SMTModel_UpdateMasterCommand>
    {
        public SMTModel_UpdateMasterHandler(IDkSession session) : base(session)
        {
        }

        public override int Handle(SMTModel_UpdateMasterCommand command)
        {
            try
            {
                string sql = $@"UPDATE smt_m_model SET 
                                      {nameof(m_smt_model.model_columns)}=@{nameof(m_smt_model.model_columns)}                                   
                                      ,{nameof(m_smt_model.model_rows)}=@{nameof(m_smt_model.model_rows)}
                                      ,{nameof(m_smt_model.active_status)}=@{nameof(m_smt_model.active_status)}
                                      ,{nameof(m_smt_model.create_time)}=@{nameof(m_smt_model.create_time)}
                                 WHERE {nameof(m_smt_model.model_cd)}=@{nameof(m_smt_model.model_cd)};
                                     
                                 INSERT INTO smt_m_model (
                                             {nameof(m_smt_model.model_cd)},
                                             {nameof(m_smt_model.model_columns)},  
                                             {nameof(m_smt_model.active_status)},       
                                             {nameof(m_smt_model.model_rows)})
                                      SELECT  @{nameof(m_smt_model.model_cd)}
                                             ,@{nameof(m_smt_model.model_columns)}
                                             ,@{nameof(m_smt_model.active_status)}
                                             ,@{nameof(m_smt_model.model_rows)}                                           
                                      WHERE NOT EXISTS(
                                         SELECT 1 FROM smt_m_model
                                         WHERE {nameof(m_smt_model.model_cd)}=@{nameof(m_smt_model.model_cd)}
                                      );";
                int result = 0;
                foreach (var item in command.ToolMaster)
                {
                    Session.DbCommand.Transaction = Session.DbTransaction;
                    Session.DbCommand.CommandType = CommandType.Text;
                    Session.DbCommand.CommandText = sql;
                    Session.DbCommand.Parameters.Clear();
                    // Session.AddParameter(item);
                    Session.AddParameter(new
                    {
                        item.model_cd,
                        item.model_columns,                 
                        item.model_rows,
                        item.active_status,
                        item.create_time
                    });
                    result += Session.DbCommand.ExecuteNonQuery();
                }
                Session.SaveChanged();
                return result;
            }
            catch
            {
                Session.Rollback();
                throw;
            }
            finally
            {
                Session.Close();
            }
        }
    }
}
