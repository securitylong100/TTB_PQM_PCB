namespace IFM.DataAccess.Interfaces
{
    public abstract class DkCommandHandler<TCommand>
        : IDkHandler<TCommand, int> where TCommand : IDkCommand
    {
        protected readonly IDkSession Session;

        public DkCommandHandler(IDkSession session)
        {
            Session = session;
        }

        public abstract int Handle(TCommand command);
    }
}
