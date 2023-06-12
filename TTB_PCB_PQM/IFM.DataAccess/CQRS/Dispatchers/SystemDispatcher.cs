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
            Register(new SystemLoginHandler(session)); 
            Register(new SystemGetViewsHandler(session));
            Register(new SystemDeleteViewHandler(session));
            Register(new SystemUpdateViewsHandler(session));
            Register(new SystemGetUserRolesHandler(session));
            Register(new SystemUpdateUserRolesHandler(session));
        }
    }
}
