using IFM.DataAccess.Extensions;
using IFM.DataAccess.Interfaces;
using IFM.DataAccess.Models.SYS;
using System;
using System.Collections.Generic;
using System.Data;


namespace IFM.DataAccess.CQRS.Commands
{
    public class SystemUpdateUserCommand : IDkCommand
    {
        public Guid Guid { get; }
        public m_user[] User { get; }

        public SystemUpdateUserCommand(params m_user[] user)
        {
            Guid = Guid.NewGuid();
            User = user;
        }
    }

    internal class SystemUpdateUserHandler : DkCommandHandler<SystemUpdateUserCommand>
    {
        public SystemUpdateUserHandler(IDkSession session) : base(session)
        {
        }

        public override int Handle(SystemUpdateUserCommand command)
        {
            try
            {
                // user_cd,
                //user_name,
                //user_pass,
                //user_status,
                //user_comments,
                //user_role,
                //user_email,
                //user_permision,
                //user_lang
                string sql = $@"UPDATE m_user SET 
                                       {nameof(m_user.user_name)}=@{nameof(m_user.user_name)},
                                       {nameof(m_user.user_pass)}=@{nameof(m_user.user_pass)},
                                       {nameof(m_user.status)}= @{nameof(m_user.status)},
                                       {nameof(m_user.comments)}=@{nameof(m_user.comments)},
                                       {nameof(m_user.user_role)}=@{nameof(m_user.user_role)},
                                       {nameof(m_user.user_email)}=@{nameof(m_user.user_email)},
                                       {nameof(m_user.user_permision)}=@{nameof(m_user.user_permision)},
                                       {nameof(m_user.user_lang)}=@{nameof(m_user.user_lang)}
                                 WHERE   {nameof(m_user.user_cd)}=@{nameof(m_user.user_cd)};
                                 INSERT INTO m_user(
                                             {nameof(m_user.user_cd)},
                                             {nameof(m_user.user_name)},
                                             {nameof(m_user.user_pass)},
                                             {nameof(m_user.status)},
                                             {nameof(m_user.comments)},
                                             {nameof(m_user.user_role)},
                                             {nameof(m_user.user_email)},
                                             {nameof(m_user.user_permision)},
                                             {nameof(m_user.user_lang)})
                                           
                                      SELECT @{nameof(m_user.user_cd)}
                                            ,@{nameof(m_user.user_name)}
                                            ,'10RU1tABAT0='
                                            ,'0'
                                            ,@{nameof(m_user.comments)}
                                            ,@{nameof(m_user.user_role)}
                                            ,@{nameof(m_user.user_email)}
                                            ,@{nameof(m_user.user_permision)}
                                            ,@{nameof(m_user.user_lang)}
                                      WHERE NOT EXISTS(
                                         SELECT 1 FROM m_user
                                         WHERE {nameof(m_user.user_cd)}=@{nameof(m_user.user_cd)}
                                      );";
                int result = 0;
                foreach (var item in command.User)
                {
                    Session.DbCommand.Transaction = Session.DbTransaction;
                    Session.DbCommand.CommandType = CommandType.Text;
                    Session.DbCommand.CommandText = sql;
                    Session.DbCommand.Parameters.Clear();
                    Session.AddParameter(new
                    {
                        item.user_cd,
                        item.user_name,
                        item.user_pass,
                        item.status,
                        item.comments,
                        item.user_role,
                        item.user_email,
                        item.user_permision,
                        item.user_lang
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
