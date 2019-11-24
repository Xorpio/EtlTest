using System;
using System.Threading.Tasks;
using Bronsysteem;
using Bronsysteem.Actors;
using Bronsysteem.Events;
using Dapr.Actors;
using Dapr.Actors.Runtime;
using Refit;

namespace BronActors.Actors
{
    public class ContractActor : Actor, IContractActor
    {
        private const string stateName = "contract";
        private readonly IDaprPublishApi daprPublishApi;

        public ContractActor(ActorService actorService, ActorId actorId) : base(actorService, actorId)
        {
            this.daprPublishApi = RestService.For<IDaprPublishApi>("http://localhost:3500/v1.0");
        }

        public async Task<string> SetContractAsync(Contract contract)
        {
            if (!(await StateManager.ContainsStateAsync(stateName)))
            {
                await daprPublishApi.PublishTopic("ContractEvent", new ContractEvent(contract.Guid, action.Add));
            }

            await this.StateManager.SetStateAsync(stateName, contract);

            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(contract));

            return "success";
        }

        public Task<Contract> GetContractAsync()
        {
            return this.StateManager.GetStateAsync<Contract>(stateName);
        }
    }
}
