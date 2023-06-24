using IFM.DataAccess.Interfaces;
using IFM.DataAccess.Models.SYS;
using System;
using System.Data;
using IFM.DataAccess.Models.NIDEC;

namespace IFM.DataAccess.CQRS.Commands
{
    public class SMTTool_DeleteMasterCommand : IDkCommand
    {
        public Guid Guid { get; }
        public int Id { get; }

        public SMTTool_DeleteMasterCommand(int id)
        {
            Id = id;
            Guid = Guid.NewGuid();
        }
    }
    internal class SMTTool_DeleteMasterHandler : DkCommandHandler<SMTTool_DeleteMasterCommand>
    {
        public SMTTool_DeleteMasterHandler(IDkSession session) : base(session)
        {
        }

        public override int Handle(SMTTool_DeleteMasterCommand command)
        {
            string sql = $@"delete from smt_m_tool_master 
                            WHERE {nameof(m_smt_tool.ID)}=@Id;";
            try
            {
                Session.DbCommand.CommandText = sql;
                Session.DbCommand.CommandType = CommandType.Text;
                Session.DbCommand.Transaction = Session.DbTransaction;
                Session.AddParameter(new { command.Id });
                int result = Session.DbCommand.ExecuteNonQuery();
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
