namespace IFM.DataAccess.Interfaces
{
    public interface IDkDispatcher
    {
        int Execute(IDkCommand command);
        TOut Query<TOut>(IDkQuery<TOut> query);
        void Register<TIn, TOut>(IDkHandler<TIn, TOut> handler);
    }
}