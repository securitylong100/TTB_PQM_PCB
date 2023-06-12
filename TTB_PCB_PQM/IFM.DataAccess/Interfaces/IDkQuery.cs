using System;

namespace IFM.DataAccess.Interfaces
{
    public interface IDkQuery<T>
    {
        Guid Guid { get; }
    }
}
