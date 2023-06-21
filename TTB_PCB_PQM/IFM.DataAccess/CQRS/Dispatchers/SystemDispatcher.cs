using IFM.DataAccess.CQRS;
using IFM.DataAccess.CQRS.Commands;
using IFM.DataAccess.CQRS.Queries;
using IFM.DataAccess.Interfaces;

namespace IFM.Business.Dispatchers.SYS
{
    public class SystemDispatcher : DkDispatcher
    {
        public SystemDispatcher(IDkSession session) : base(session)
        {
            //m_login
            Register(new SystemLoginHandler(session));

            //m_assignment
            Register(new SystemGetViewsHandler(session));
            Register(new SystemDeleteViewHandler(session));
            Register(new SystemUpdateViewsHandler(session));
            
            //m_user
            Register(new SystemGetUserHandler(session));
            Register(new SystemDeleteUserHandler(session));
            Register(new SystemUpdateUserHandler(session));
            
            //m_user_role
            Register(new SystemGetUserRolesHandler(session));
            Register(new SystemUpdateUserRolesHandler(session));
            Register(new SystemGetDistinctUserHandler(session));
            Register(new SystemGetDistinctViewsHandler(session));

        }
    }
}
