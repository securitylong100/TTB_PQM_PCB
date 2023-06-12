namespace IFM.DataAccess.Interfaces
{
    public abstract class DkQueryHandler<TQuery, TOut>
        : IDkHandler<TQuery, TOut> where TQuery : IDkQuery<TOut>
    {
        protected readonly IDkSession Session;

        public DkQueryHandler(IDkSession session)
        {
            Session = session;
        }

        public abstract TOut Handle(TQuery query);
    }
}
