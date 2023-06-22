using IFM.DataAccess.CQRS;
using IFM.DataAccess.CQRS.Commands;
using IFM.DataAccess.CQRS.Queries.NIDEC.SMT;
using IFM.DataAccess.Interfaces;
using IFM.DataAccess.CQRS.Queries;


namespace IFM.Business.Dispatchers.SYS
{
    public class SMTDispatcher : DkDispatcher
    {
        public SMTDispatcher(IDkSession session) : base(session)
        {
        //   Register(new SMTTool_GetMasterHandler(session));
        }
    }
}
