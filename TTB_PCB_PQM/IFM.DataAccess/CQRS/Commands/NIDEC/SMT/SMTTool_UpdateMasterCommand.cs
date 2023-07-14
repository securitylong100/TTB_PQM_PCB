using IFM.DataAccess.Interfaces;
using IFM.DataAccess.Models.SYS;
using IFM.DataAccess.Models.NIDEC;
using System;
using System.Data;

namespace IFM.DataAccess.CQRS.Commands
{
    public class SMTTool_UpdateMasterCommand : IDkCommand
    {
        public Guid Guid { get; }
        public m_smt_tool[] ToolMaster { get; }

        public SMTTool_UpdateMasterCommand(params m_smt_tool[] roles)
        {
            Guid = Guid.NewGuid();
            ToolMaster = roles;
        }
    }

    internal class SMTTool_UpdateMasterHandler : DkCommandHandler<SMTTool_UpdateMasterCommand>
    {
        public SMTTool_UpdateMasterHandler(IDkSession session) : base(session)
        {
        }

        public override int Handle(SMTTool_UpdateMasterCommand command)
        {
            try
            {
                string sql = $@"UPDATE smt_m_tool_master SET 
                                       {nameof(m_smt_tool.tool_name)}=@{nameof(m_smt_tool.tool_name)}
                                      ,{nameof(m_smt_tool.tool_station)}=@{nameof(m_smt_tool.tool_station)}
                                      ,{nameof(m_smt_tool.model_cd)}=@{nameof(m_smt_tool.model_cd)}
                                      ,{nameof(m_smt_tool.tool_active)}=@{nameof(m_smt_tool.tool_active)}
                                      ,{nameof(m_smt_tool.priority)}=@{nameof(m_smt_tool.priority)}
                                      ,{nameof(m_smt_tool.status)}=@{nameof(m_smt_tool.status)}
                                      ,{nameof(m_smt_tool.comments)}=@{nameof(m_smt_tool.comments)}     
                                      ,{nameof(m_smt_tool.updater)}=@{nameof(m_smt_tool.updater)}
                                 WHERE {nameof(m_smt_tool.tool_cd)}=@{nameof(m_smt_tool.tool_cd)};
                                 INSERT INTO smt_m_tool_master (
                                             {nameof(m_smt_tool.tool_cd)},
                                             {nameof(m_smt_tool.tool_name)},
                                             {nameof(m_smt_tool.tool_station)},
                                             {nameof(m_smt_tool.model_cd)},
                                             {nameof(m_smt_tool.tool_active)},
                                             {nameof(m_smt_tool.priority)},
                                             {nameof(m_smt_tool.status)},
                                             {nameof(m_smt_tool.comments)},
                                             {nameof(m_smt_tool.updater)},
                                             {nameof(m_smt_tool.creator)})
                                      SELECT  @{nameof(m_smt_tool.tool_cd)}
                                             ,@{nameof(m_smt_tool.tool_name)}
                                             ,@{nameof(m_smt_tool.tool_station)}
                                             ,@{nameof(m_smt_tool.model_cd)}
                                             ,@{nameof(m_smt_tool.tool_active)}
                                             ,@{nameof(m_smt_tool.priority)}
                                             ,@{nameof(m_smt_tool.status)}
                                             ,@{nameof(m_smt_tool.comments)}
                                             ,@{nameof(m_smt_tool.updater)}
                                             ,@{nameof(m_smt_tool.creator)}
                                      WHERE NOT EXISTS(
                                         SELECT 1 FROM smt_m_tool_master
                                         WHERE {nameof(m_smt_tool.tool_cd)}=@{nameof(m_smt_tool.tool_cd)}
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
                        item.tool_cd,
                        item.tool_name,
                        item.tool_station,
                        item.model_cd,
                        item.tool_active,
                        item.comments,
                        item.status,
                        item.priority,
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
