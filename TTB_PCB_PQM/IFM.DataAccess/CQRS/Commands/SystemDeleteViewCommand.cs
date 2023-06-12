using IFM.DataAccess.Interfaces;
using IFM.DataAccess.Models.SYS;
using System;
using System.Data;

namespace IFM.DataAccess.CQRS.Commands
{
    public class SystemDeleteViewCommand : IDkCommand
    {
        public Guid Guid { get; }
        public int Id { get; }

        public SystemDeleteViewCommand(int id)
        {
            Id = id;
            Guid = Guid.NewGuid();
        }
    }

    internal class SystemDeleteViewHandler : DkCommandHandler<SystemDeleteViewCommand>
    {
        public SystemDeleteViewHandler(IDkSession session) : base(session)
        {
        }

        public override int Handle(SystemDeleteViewCommand command)
        {
            string sql = $@"UPDATE m_assignments SET {nameof(m_assignment.status)}='2'
                            WHERE {nameof(m_assignment.ID)}=@Id;";
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
