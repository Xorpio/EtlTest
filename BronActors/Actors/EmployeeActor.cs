using System;
using System.Threading.Tasks;
using Bronsysteem;
using Bronsysteem.Actors;
using Dapr.Actors;
using Dapr.Actors.Runtime;
using Refit;

namespace BronActors.Actors
{
    public class EmployeeActor : Actor, IEmployeeActor
    {
        private const string stateName = "employee";
        private readonly IDaprPublishApi daprPublishApi;

        public EmployeeActor(ActorService actorService, ActorId actorId) : base(actorService, actorId)
        {
            this.daprPublishApi = RestService.For<IDaprPublishApi>("http://localhost:3500/v1.0");
        }

        public async Task<string> SetEmployeeAsync(Employee employee)
        {
            if (!(await StateManager.ContainsStateAsync(stateName)))
            {
                await daprPublishApi.PublishTopic("EmployeeEvent", new EmployeeEvent(employee.Guid, action.Add));
            }

            var tstate = this.StateManager.SetStateAsync(stateName, employee);

            //var tcollection = collectionActor.AddGuid(employee.Guid);

            await tstate;
            //await tcollection;

            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(employee));

            return "success";
        }

        public Task<Employee> GetEmployeeAsync()
        {
            return this.StateManager.GetStateAsync<Employee>(stateName);
        }
    }
}
