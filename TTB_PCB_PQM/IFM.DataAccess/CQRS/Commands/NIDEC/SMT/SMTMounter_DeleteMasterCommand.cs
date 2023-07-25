using IFM.DataAccess.Interfaces;
using IFM.DataAccess.Models.SYS;
using System;
using System.Data;
using IFM.DataAccess.Models.NIDEC;

namespace IFM.DataAccess.CQRS.Commands
{
    public class SMTMounter_DeleteMasterCommand : IDkCommand
    {
        public Guid Guid { get; }
        public int Id { get; }

        public SMTMounter_DeleteMasterCommand(int id)
        {
            Id = id;
            Guid = Guid.NewGuid();
        }
    }
    internal class SMTMounter_DeleteMasterHandler : DkCommandHandler<SMTMounter_DeleteMasterCommand>
    {
        public SMTMounter_DeleteMasterHandler(IDkSession session) : base(session)
        {
        }

        public override int Handle(SMTMounter_DeleteMasterCommand command)
        {
            string sql = $@"delete from smt_m_mounter_items 
                            WHERE {nameof(m_smt_mounter.ID)}=@Id;";
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
