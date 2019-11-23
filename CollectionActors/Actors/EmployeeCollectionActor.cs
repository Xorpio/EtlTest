using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapr.Actors;
using Dapr.Actors.Runtime;

namespace CollectionActors.Actors
{
    public class EmployeeCollectionActor : Actor, IEmployeeCollectionActor
    {
        private readonly string stateKey = "EmployeeCollection";

        private IList<Guid>? list;

        public EmployeeCollectionActor(ActorService actorService, ActorId actorId) : base(actorService, actorId)
        {
        }

        public async Task<Guid> AddGuid(Guid guid)
        {
            list ??= await StateManager.GetOrAddStateAsync(stateKey, new List<Guid>());

            if (!list.Contains(guid))
            {
                list.Add(guid);
                await StateManager.SetStateAsync(stateKey, list);
            }

            return guid;
        }

        public async Task<Guid> DeleteGuid(Guid guid)
        {
            list ??= await StateManager.GetOrAddStateAsync(stateKey, new List<Guid>());

            if (list.Contains(guid))
            {
                list.Remove(guid);
                await StateManager.SetStateAsync(stateKey, list);
            }

            return guid;
        }

        public async Task<IList<Guid>> GetGuids()
        {
            return list ?? await StateManager.GetOrAddStateAsync(stateKey, new List<Guid>());
        }
    }
}
