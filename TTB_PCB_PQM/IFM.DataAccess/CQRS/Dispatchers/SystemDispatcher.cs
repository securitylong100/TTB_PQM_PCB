using IFM.DataAccess.CQRS;
using IFM.DataAccess.CQRS.Commands;
using IFM.DataAccess.CQRS.Queries;
using IFM.DataAccess.Interfaces;
using IFM.DataAccess.CQRS.Queries.NIDEC.SMT;

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

            //NIDEC SMT TOOL
            Register(new SMTTool_GetMasterHandler(session));
            Register(new SMTTool_UpdateMasterHandler(session));
            Register(new SMTTool_DeleteMasterHandler(session));
            Register(new SMTToolGetDistinctModelHandler(session));

            //NIDEC SMT TOOL
            Register(new SMTModel_GetMasterHandler(session));
            Register(new SMTModel_UpdateMasterHandler(session));
            Register(new SMTModel_DeleteMasterHandler(session));


            //SMTMounter_DeleteMasterHandler
            Register(new SMTMounter_GetMasterHandler(session));
            Register(new SMTMounter_DeleteMasterHandler(session));
            Register(new SMTMounter_UpdateMasterHandler(session));
            Register(new SMTMounterGetDistinctModelHandler(session));
            //
        }
    }
}
