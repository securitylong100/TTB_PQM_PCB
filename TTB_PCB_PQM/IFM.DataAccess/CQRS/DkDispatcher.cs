using IFM.DataAccess.Interfaces;
using System;
using System.Collections.Generic;

namespace IFM.DataAccess.CQRS
{
    public class DkDispatcher : IDkDispatcher
    {
        protected readonly IDkSession Session;
        protected readonly Dictionary<Type, object> DictHandlers;

        public event EventHandler<Type> Executing;
        public event EventHandler<Type> Executed;

        public DkDispatcher(IDkSession session)
        {
            Session = session;
            DictHandlers = new Dictionary<Type, object>();
        }

        public int Execute(IDkCommand command)
        {
            try
            {
                Executing?.Invoke(this, command.GetType());
                Type type = command.GetType();
                if (DictHandlers.ContainsKey(type))
                {
                    var handler = DictHandlers[type];
                    var method = handler.GetType().GetMethod("Handle");
                    return (int)method.Invoke(handler, new object[] { command });
                }
                throw new KeyNotFoundException();
            }
            finally
            {
                Executed?.Invoke(this, command.GetType());
            }
        }

        public TOut Query<TOut>(IDkQuery<TOut> query)
        {
            try
            {
                Executing?.Invoke(this, query.GetType());

                Type type = query.GetType();
                if (DictHandlers.ContainsKey(type))
                {
                    var handler = DictHandlers[type];
                    var method = handler.GetType().GetMethod("Handle");
                    return (TOut)method.Invoke(handler, new object[] { query });
                }
                throw new KeyNotFoundException();
            }
            finally
            {
                Executed?.Invoke(this, query.GetType());
            }
        }

        public void Register<TIn, TOut>(IDkHandler<TIn, TOut> handler)
        {
            Type queryType = typeof(TIn);
            if (!DictHandlers.ContainsKey(queryType))
            {
                DictHandlers.Add(queryType, handler);
            }
        }
    }
}
