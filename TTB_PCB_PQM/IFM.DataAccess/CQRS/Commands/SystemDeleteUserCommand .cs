using IFM.DataAccess.Interfaces;
using IFM.DataAccess.Models.SYS;
using System;
using System.Data;

namespace IFM.DataAccess.CQRS.Commands
{
    public class SystemDeleteUserCommand : IDkCommand
    {
        public Guid Guid { get; }
        public int Id { get; }

        public SystemDeleteUserCommand(int id)
        {
            Id = id;
            Guid = Guid.NewGuid();
        }
    }

    internal class SystemDeleteUserHandler : DkCommandHandler<SystemDeleteUserCommand>
    {
        public SystemDeleteUserHandler(IDkSession session) : base(session)
        {
        }

        public override int Handle(SystemDeleteUserCommand command)
        {
            string sql = $@"UPDATE m_user SET {nameof(m_user.status)}='2'
                            WHERE {nameof(m_user.ID)}=@Id;";
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
