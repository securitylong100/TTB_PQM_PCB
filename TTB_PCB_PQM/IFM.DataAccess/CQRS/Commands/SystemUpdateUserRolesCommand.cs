using IFM.DataAccess.Interfaces;
using IFM.DataAccess.Models.SYS;
using System;
using System.Data;

namespace IFM.DataAccess.CQRS.Commands
{
    public class SystemUpdateUserRolesCommand : IDkCommand
    {
        public Guid Guid { get; }
        public m_user_role[] Roles { get; }

        public SystemUpdateUserRolesCommand(params m_user_role[] roles)
        {
            Guid = Guid.NewGuid();
            Roles = roles;
        }
    }

    internal class SystemUpdateUserRolesHandler : DkCommandHandler<SystemUpdateUserRolesCommand>
    {
        public SystemUpdateUserRolesHandler(IDkSession session) : base(session)
        {
        }

        public override int Handle(SystemUpdateUserRolesCommand command)
        {
            try
            {
                string sql = $@"UPDATE m_user_roles SET 
                                       {nameof(m_user_role.priority)}=@{nameof(m_user_role.priority)}
                                      ,{nameof(m_user_role.status)}=@{nameof(m_user_role.status)}
                                      ,{nameof(m_user_role.comments)}=@{nameof(m_user_role.comments)}
                                      ,{nameof(m_user_role.updater)}=@{nameof(m_user_role.updater)}
                                 WHERE {nameof(m_user_role.user_cd)}=@{nameof(m_user_role.user_cd)}
                                   AND {nameof(m_user_role.assign_code)}=@{nameof(m_user_role.assign_code)};
                                 INSERT INTO m_user_roles (
                                             {nameof(m_user_role.user_cd)},
                                             {nameof(m_user_role.assign_code)},
                                             {nameof(m_user_role.priority)},
                                             {nameof(m_user_role.status)},
                                             {nameof(m_user_role.comments)},
                                             {nameof(m_user_role.updater)},
                                             {nameof(m_user_role.creator)})
                                      SELECT @{nameof(m_user_role.user_cd)}
                                            ,@{nameof(m_user_role.assign_code)}
                                            ,@{nameof(m_user_role.priority)}
                                            ,@{nameof(m_user_role.status)}
                                            ,@{nameof(m_user_role.comments)}
                                            ,@{nameof(m_user_role.updater)}
                                            ,@{nameof(m_user_role.creator)}
                                      WHERE NOT EXISTS(
                                         SELECT 1 FROM m_user_roles
                                         WHERE {nameof(m_user_role.user_cd)}=@{nameof(m_user_role.user_cd)}
                                         AND {nameof(m_user_role.assign_code)}=@{nameof(m_user_role.assign_code)}
                                      );";
                int result = 0;
                foreach (var item in command.Roles)
                {
                    Session.DbCommand.Transaction = Session.DbTransaction;
                    Session.DbCommand.CommandType = CommandType.Text;
                    Session.DbCommand.CommandText = sql;
                    Session.DbCommand.Parameters.Clear();
                   // Session.AddParameter(item);
                    Session.AddParameter(new
                    {
                        item.user_cd,
                        item.assign_code,
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
