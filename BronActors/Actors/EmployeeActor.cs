using System;
using System.Threading.Tasks;
using Bronsysteem;
using Bronsysteem.Actors;
using Dapr.Actors;
using Dapr.Actors.Client;
using Dapr.Actors.Runtime;

namespace BronActors.Actors
{
    public class EmployeeActor : Actor, IEmployeeActor
    {
        //private IEmployeeCollectionActor? _collectionActor;
        //private IEmployeeCollectionActor collectionActor
        //{
        //    get
        //    {
        //        _collectionActor ??= ActorProxy.Create<IEmployeeCollectionActor>(new ActorId("collection"), "EmployeeCollectionActor");
        //        return _collectionActor;
        //    }
        //}

        public EmployeeActor(ActorService actorService, ActorId actorId) : base(actorService, actorId)
        {
        }

        public async Task<string> SetEmployeeAsync(Employee employee)
        {
            var tstate = this.StateManager.SetStateAsync("employee", employee);

            //var tcollection = collectionActor.AddGuid(employee.Guid);

            await tstate;
            //await tcollection;

            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(employee));

            return "success";
        }

        public Task<Employee> GetEmployeeAsync()
        {
            return this.StateManager.GetStateAsync<Employee>("employee");
        }
    }
}
