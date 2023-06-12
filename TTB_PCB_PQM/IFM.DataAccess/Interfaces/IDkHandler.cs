namespace IFM.DataAccess.Interfaces
{
    public interface IDkHandler<TIn, TOut>
    {
        TOut Handle(TIn input);
    }
}
