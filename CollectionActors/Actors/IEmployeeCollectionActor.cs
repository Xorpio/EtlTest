using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapr.Actors;

namespace CollectionActors.Actors
{
    public interface IEmployeeCollectionActor : IActor
    {
        Task<Guid> AddGuid(Guid guid);
        Task<Guid> DeleteGuid(Guid guid);
        Task<IList<Guid>> GetGuids();
    }
}
