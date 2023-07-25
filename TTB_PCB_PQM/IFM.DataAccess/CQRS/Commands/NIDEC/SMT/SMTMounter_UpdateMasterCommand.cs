using IFM.DataAccess.Interfaces;
using IFM.DataAccess.Models.SYS;
using IFM.DataAccess.Models.NIDEC;
using System;
using System.Data;

namespace IFM.DataAccess.CQRS.Commands
{
    public class SMTMounter_UpdateMasterCommand : IDkCommand
    {
        public Guid Guid { get; }
        public m_smt_mounter[] ToolMaster { get; }

        public SMTMounter_UpdateMasterCommand(params m_smt_mounter[] roles)
        {
            Guid = Guid.NewGuid();
            ToolMaster = roles;
        }
    }

    internal class SMTMounter_UpdateMasterHandler : DkCommandHandler<SMTMounter_UpdateMasterCommand>
    {
        public SMTMounter_UpdateMasterHandler(IDkSession session) : base(session)
        {
        }

        public override int Handle(SMTMounter_UpdateMasterCommand command)
        {
            try
            {
                string sql = $@"UPDATE smt_m_mounter_items SET 
                                      {nameof(m_smt_mounter.item_list)}=@{nameof(m_smt_mounter.item_list)}                                   
                                      ,{nameof(m_smt_mounter.status)}=@{nameof(m_smt_mounter.status)}
                                      ,{nameof(m_smt_mounter.comments)}=@{nameof(m_smt_mounter.comments)}     
                                      ,{nameof(m_smt_mounter.updater)}=@{nameof(m_smt_mounter.updater)}
                                 WHERE {nameof(m_smt_mounter.model_cd)}=@{nameof(m_smt_mounter.model_cd)}
                                   and {nameof(m_smt_mounter.item_list)}=@{nameof(m_smt_mounter.item_list)};
                                     
                                 INSERT INTO smt_m_mounter_items (
                                             {nameof(m_smt_mounter.model_cd)},
                                             {nameof(m_smt_mounter.item_list)},                                           
                                             {nameof(m_smt_mounter.status)},
                                             {nameof(m_smt_mounter.comments)},
                                             {nameof(m_smt_mounter.updater)},
                                             {nameof(m_smt_mounter.creator)})
                                      SELECT  @{nameof(m_smt_mounter.model_cd)}
                                             ,@{nameof(m_smt_mounter.item_list)}
                                             ,@{nameof(m_smt_mounter.status)}
                                             ,@{nameof(m_smt_mounter.comments)}
                                             ,@{nameof(m_smt_mounter.updater)}
                                             ,@{nameof(m_smt_mounter.creator)}
                                      WHERE NOT EXISTS(
                                         SELECT 1 FROM smt_m_mounter_items
                                         WHERE {nameof(m_smt_mounter.model_cd)}=@{nameof(m_smt_mounter.model_cd)}
                                           and {nameof(m_smt_mounter.item_list)}=@{nameof(m_smt_mounter.item_list)}      
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
                        item.item_list,                 
                        item.comments,
                        item.status,
                        item.creator,
                        item.create_time,
                        item.updater,
                        item.update_time
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
