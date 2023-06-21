using IFM.DataAccess.Interfaces;
using IFM.DataAccess.Models.SYS;
using System;
using System.Data;

namespace IFM.DataAccess.CQRS.Commands
{
    public class SystemUpdateViewsCommand : IDkCommand
    {
        public Guid Guid { get; }
        public m_assignment[] Views { get; }

        public SystemUpdateViewsCommand(params m_assignment[] views)
        {
            Guid = Guid.NewGuid();
            Views = views;
        }
    }

    internal class SystemUpdateViewsHandler : DkCommandHandler<SystemUpdateViewsCommand>
    {
        public SystemUpdateViewsHandler(IDkSession session) : base(session)
        {
        }

        public override int Handle(SystemUpdateViewsCommand command)
        {
            try
            {
                string sql = $@"UPDATE m_assignments SET 
                                       {nameof(m_assignment.assign_name)}=@{nameof(m_assignment.assign_name)},
                                       {nameof(m_assignment.assign_name_vn)}=@{nameof(m_assignment.assign_name_vn)},
                                       {nameof(m_assignment.assign_view)}=@{nameof(m_assignment.assign_view)},
                                       {nameof(m_assignment.parent_code)}=@{nameof(m_assignment.parent_code)},
                                       {nameof(m_assignment.priority)}=@{nameof(m_assignment.priority)},
                                       {nameof(m_assignment.status)}= @{nameof(m_assignment.status)},
                                       {nameof(m_assignment.comments)}=@{nameof(m_assignment.comments)},
                                       {nameof(m_assignment.updater)}=@{nameof(m_assignment.updater)}
                                 WHERE {nameof(m_assignment.assign_code)}=@{nameof(m_assignment.assign_code)};
                                 INSERT INTO m_assignments(
                                             {nameof(m_assignment.assign_code)},
                                             {nameof(m_assignment.assign_name)},
                                             {nameof(m_assignment.assign_name_vn)},
                                             {nameof(m_assignment.assign_view)},
                                             {nameof(m_assignment.parent_code)},
                                             {nameof(m_assignment.priority)},
                                             {nameof(m_assignment.status)},
                                             {nameof(m_assignment.comments)},
                                             {nameof(m_assignment.updater)},
                                             {nameof(m_assignment.creator)})
                                      SELECT @{nameof(m_assignment.assign_code)}
                                            ,@{nameof(m_assignment.assign_name)}
                                            ,@{nameof(m_assignment.assign_name_vn)}
                                            ,@{nameof(m_assignment.assign_view)}
                                            ,@{nameof(m_assignment.parent_code)}
                                            ,@{nameof(m_assignment.priority)}
                                            ,'0'
                                            ,@{nameof(m_assignment.comments)}
                                            ,@{nameof(m_assignment.updater)}
                                            ,@{nameof(m_assignment.creator)}
                                      WHERE NOT EXISTS(
                                         SELECT 1 FROM m_assignments
                                         WHERE {nameof(m_assignment.assign_code)}=@{nameof(m_assignment.assign_code)}
                                      );";
                int result = 0;
                foreach (var item in command.Views)
                {
                    Session.DbCommand.Transaction = Session.DbTransaction;
                    Session.DbCommand.CommandType = CommandType.Text;
                    Session.DbCommand.CommandText = sql;
                    Session.DbCommand.Parameters.Clear();
                    Session.AddParameter(new { 
                    item.assign_code,
                    item.assign_name,
                    item.assign_name_vn,
                    item.assign_view,
                    item.parent_code,
                    item.priority,
                    item.status,
                    item.comments,
                    item.updater,
                    item.creator,
                    item.create_time,
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
