using IFM.DataAccess.Extensions;
using IFM.DataAccess.Interfaces;
using IFM.DataAccess.Models.SYS;
using System;
using System.Collections.Generic;
using System.Data;

namespace IFM.DataAccess.CQRS.Queries
{
    public class SystemLoginQuery : IDkQuery<IEnumerable<sp_user_login>>
    {
        public Guid Guid { get; }
        public string Password { get; }
        public string UserCode { get; }

        public SystemLoginQuery(string user, string password)
        {
            Guid = Guid.NewGuid();
            UserCode = user;
            Password = De_Encrypt.Encrypt(password);
        }
    }

    internal class SystemLoginHandler : DkQueryHandler<SystemLoginQuery, IEnumerable<sp_user_login>>
    {
        public SystemLoginHandler(IDkSession session) : base(session)
        {
        }

        public override IEnumerable<sp_user_login> Handle(SystemLoginQuery query)
        {
            try
            {
                string sql = @"	SELECT u.user_cd,u.user_name,r.assign_code,u.user_lang
	                            FROM m_user AS u
	                            JOIN m_user_roles AS r
	                            ON u.user_cd=r.user_cd
	                            WHERE 1=1
	                            AND u.user_cd=@UserCode
	                            AND u.user_pass=@Password;";
                Session.DbCommand.CommandText = sql;
                Session.DbCommand.CommandType = CommandType.Text;
                Session.AddParameter(new { query.UserCode, query.Password });
                return Session.DbCommand.ExecuteReader().MapToList<sp_user_login>();
            }
            finally
            {
                Session.Close();
            }
        }
    }

}
