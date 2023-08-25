using IFM.DataAccess.Interfaces;
using IFM.DataAccess.Models.SYS;
using System;
using System.Data;
using IFM.DataAccess.Models.NIDEC;

namespace IFM.DataAccess.CQRS.Commands
{
    public class SMTModel_DeleteMasterCommand : IDkCommand
    {
        public Guid Guid { get; }
        public int Id { get; }

        public SMTModel_DeleteMasterCommand(int id)
        {
            Id = id;
            Guid = Guid.NewGuid();
        }
    }
    internal class SMTModel_DeleteMasterHandler : DkCommandHandler<SMTModel_DeleteMasterCommand>
    {
        public SMTModel_DeleteMasterHandler(IDkSession session) : base(session)
        {
        }

        public override int Handle(SMTModel_DeleteMasterCommand command)
        {
            string sql = $@"delete from smt_m_model 
                            WHERE {nameof(m_smt_model.ID)}=@Id;";
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
